using ColorGame.DTOs;
using ColorGame.Services;
using ColorGame.Views;
using System;
using System.Collections.Generic;
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


        private readonly ILocalDataService _localDataService;
        public GameDetailsViewModels()
        {
            _localDataService = DependencyService.Resolve<ILocalDataService>();
            SelectedScoreCard = _navigationService.GetNavigationItem<ScoreCard>();


        }


    }
}
