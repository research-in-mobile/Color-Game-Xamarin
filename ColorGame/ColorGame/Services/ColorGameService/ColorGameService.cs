using ColorGame.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ColorGame.Services
{
    public class ColorGameService : IColorGameService
    {
        //TODO: Get from App Settings
        private const int _maxSupportedColorIndex = 3;
        private const int _maxResponseCountPerGame = 5;

        private int _selectionCount;
        private ColorIndex _lastSentColorIndex;

        private Dictionary<int, UserSelection> _gameResults;

        private readonly ILocalDataService _localDataService;
        public ColorGameService()
        {
            _localDataService = DependencyService.Resolve<ILocalDataService>();
            if (_localDataService.ActiveScoreCards == null)
            {
                _localDataService.ActiveScoreCards = new List<ScoreCard>();
            }

        }

        public ColorGameService StartNewGame()
        {
            _selectionCount = 0;
            _gameResults = new Dictionary<int, UserSelection>();

            return this;
        }

        public ColorGameService StoreUserSelection(ColorIndex colorIndex, TimeSpan userRespnseTime)
        {
            _gameResults.Add(_selectionCount, new UserSelection()
            {
                DisplayiedColorIndex = _lastSentColorIndex,
                ResponseColorIndex = colorIndex,
                ResponseTime = userRespnseTime
            });

            return this;
        }

        public ColorGameService SaveGameResults(ScoreCard scoreCard)
        {
            if (_localDataService.ActiveScoreCards == null)
            {
                _localDataService.ActiveScoreCards = new List<ScoreCard>();
            }        

            _localDataService.ActiveScoreCards.Add(scoreCard);
            _localDataService.SaveScoreCards();

            return this;
        }

        public ColorIndex? GetNextColorIndex()
        {
            _selectionCount++;


            Random random = new Random();

            if (!IsGameOver())
            {
                Debug.WriteLine(_selectionCount);
                return _lastSentColorIndex = (ColorIndex)random.Next(0, _maxSupportedColorIndex);
            }
            else
                return null;
        }

        public ScoreCard GetCurrentScoreCard(User user)
        {
            long score = 0;
            foreach (var result in _gameResults)
            {
                score += result.Value.ResponseTime.Ticks;
            }

            return new ScoreCard()
            {
                Id = Guid.NewGuid(),
                AverageReactionTime = new TimeSpan((long)(score / _maxResponseCountPerGame)),
                GameDateTime = DateTime.Now,
                User = user,
                UserSelections = _gameResults.Select(gr => gr.Value).ToList()
            };
        }

        private bool IsGameOver()
        {
            return _selectionCount > _maxResponseCountPerGame;
        }

    }
}
