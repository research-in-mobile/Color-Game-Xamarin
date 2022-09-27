using ColorGame.DTOs;
using ColorGame.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;

namespace ColorGame.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public ColorIndex CurrentShowingColor
        {
            get => _colorShowingIndex;
            set => SetProperty(ref _colorShowingIndex, value);
        }
        public bool HasGameStarted
        {
            get => _hasGameStarted;
            set => SetProperty(ref _hasGameStarted, value);
        }

        private bool _hasGameStarted;
        private bool _isGameOver;
        private Stopwatch _gameTimer;
        private ColorIndex _colorShowingIndex;

        public ICommand StartNewGameCommand { get; set; }
        public ICommand UserColorSelectionCommand { get; set; }

        private readonly IColorGameService _colorGameService;
        public GameViewModel()
        {
            _isGameOver = false;
            HasGameStarted = false;

            _colorGameService = DependencyService.Resolve<IColorGameService>();
            _gameTimer = new Stopwatch();

            CurrentShowingColor = ColorIndex.Yellow;

            StartNewGameCommand = new Command(StartNewGame);
            UserColorSelectionCommand = new Command<object>(RecieveUserResponse);
        }

        private void StartNewGame()
        {

            CurrentShowingColor = _colorGameService
                .StartNewGame()
                .GetNextColorIndex()
                .Value;

            HasGameStarted = true;
            _isGameOver = false;
            _gameTimer.Restart();
        }
        private void RecieveUserResponse(object selectionObj)
        {
            _gameTimer.Stop();

            int.TryParse(selectionObj.ToString(), out int index);

            _colorGameService.StoreUserSelection((ColorIndex)index, _gameTimer.Elapsed);

            ShowNextColor();
        }
        private void ShowNextColor()
        {
            if (_isGameOver) return;

            var colorIndex = _colorGameService.GetNextColorIndex();
            if (colorIndex.HasValue)
            {
                CurrentShowingColor = colorIndex.Value;
                _gameTimer.Restart();
            }
            else
            {
                HasGameStarted = false;
                _isGameOver = true;

                var result = _colorGameService.GetCurrentScoreCard(_localDataService.CurrentUser);
                _colorGameService.SaveGameResults(result);

                App.Current.MainPage.DisplayAlert("Game Over", JsonConvert.SerializeObject(result), "Ok");
            }

        }

    }
}
