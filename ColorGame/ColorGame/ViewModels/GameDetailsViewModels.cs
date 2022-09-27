using ColorGame.DTOs;
using ColorGame.Services;
using ColorGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ColorGame.ViewModels
{
    public class GameDetailsViewModels : BaseViewModel
    {
        private ScoreCard _selectedScoreCard;
        public ScoreCard SelectedScoreCard
        {
            get => _selectedScoreCard;
            set
            {
                SetProperty(ref _selectedScoreCard, value);
            }
        }

        public Command SaveCommand { get; set; }
        public GameDetailsViewModels()
        {
            SelectedScoreCard = _navigationService.GetNavigationItem<ScoreCard>();
            SaveCommand = new Command(Save);
        }

        public void Save()
        {
            var originalCard = _navigationService.GetNavigationItem<ScoreCard>();

            int index = _localDataService.ActiveScoreCards.FindIndex(sc => sc.Id == originalCard.Id);
            if (index != -1)
                _localDataService.ActiveScoreCards[index] = SelectedScoreCard;

        }

    }
}
