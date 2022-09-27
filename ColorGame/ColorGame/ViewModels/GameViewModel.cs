using ColorGame.DTOs;
using ColorGame.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        public bool CanShowNextColor
        {
            get => _canShowNextColor;
            set => SetProperty(ref _canShowNextColor, value);
        }

        private bool _hasGameStarted;
        private bool _canShowNextColor;
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
            CanShowNextColor = false;

            _colorGameService = DependencyService.Resolve<IColorGameService>();
            _gameTimer = new Stopwatch();

            CurrentShowingColor = ColorIndex.Yellow;

            StartNewGameCommand = new Command(StartNewGame);
            UserColorSelectionCommand = new Command<object>(RecieveUserResponse);
        }

        private void StartNewGame()
        {
            HasGameStarted = true;
            //CanShowNextColor = false;
            _isGameOver = false;

            _colorGameService.StartNewGame();

            ShowNextColor();

            _gameTimer.Restart();
        }
        private void RecieveUserResponse(object selectionObj)
        {
            _gameTimer.Stop();

            int.TryParse(selectionObj.ToString(), out int index);

            _colorGameService.StoreUserSelection((ColorIndex)index, _gameTimer.Elapsed);

            CanShowNextColor = false;

            ShowNextColor();
        }
        private async void ShowNextColor()
        {
            if (_isGameOver) return;

            CanShowNextColor = false;

            var colorIndex = _colorGameService.GetNextColorIndex();
            if (colorIndex.HasValue)
            {
                await Task.Delay(1000);
                CanShowNextColor = true;
                RaisePropertyChanged(nameof(CanShowNextColor));

                CurrentShowingColor = colorIndex.Value;
                _gameTimer.Restart();
            }
            else
            {
                HasGameStarted = false;
                _isGameOver = true;

                var result = _colorGameService.GetCurrentScoreCard(_localDataService.CurrentUser);
                _colorGameService.SaveGameResults(result);

                await App.Current.MainPage.DisplayAlert("Game Over", JsonConvert.SerializeObject(result), "Ok");
            }

        }

    }
}
