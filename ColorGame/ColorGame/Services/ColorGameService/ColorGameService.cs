using ColorGame.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (_localDataService.ScoreCards == null)
            {
                _localDataService.ScoreCards = new List<ScoreCard>();
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

        public ColorGameService SaveGameResults()
        {
            if (_localDataService.ScoreCards == null)
            {
                _localDataService.ScoreCards = new List<ScoreCard>();
            }

            var scoreCard = new ScoreCard()
            {

            };

            _localDataService.ScoreCards.Add(scoreCard);
            _localDataService.SaveScoreCards();

            return this;
        }

        public ColorIndex? GetNextColorIndex()
        {
            _selectionCount++;
            Debug.WriteLine(_selectionCount);

            Random random = new Random();

            if (!IsGameOver())
                return _lastSentColorIndex = (ColorIndex)random.Next(0, _maxSupportedColorIndex);
            else
                return null;
        }

        private bool IsGameOver()
        {
            return _selectionCount > _maxResponseCountPerGame;
        }

    }
}
