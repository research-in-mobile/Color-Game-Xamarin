using ColorGame.DTOs;
using ColorGame.Services;
using ColorGame.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ColorGame.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private ScoreCard _selectedScoreCard;
        public ScoreCard SelectedScoreCard
        {
            get => _selectedScoreCard;
            set
            {
                SetProperty(ref _selectedScoreCard, value);
                OnSelected(value);
            }
        }

        public ObservableCollection<ScoreCard> ScoreCards { get; set; }

        public Command LoadScoreCardsCommand { get; }
        public Command<ScoreCard> ScoreCardTapped { get; }

        public HomeViewModel()
        {
            LoadScoreCardsCommand = new Command(ExecuteLoadItemsCommand);
            ScoreCardTapped = new Command<ScoreCard>(OnSelected);

            ScoreCards = new ObservableCollection<ScoreCard>(_localDataService.ActiveScoreCards);
        }

        private void OnSelected(ScoreCard scoreCard)
        {
            if (scoreCard == null)
                return;

            _navigationService.StoreNavigationItem(scoreCard);
            GoTo($"{nameof(GameDetailsPage)}", true);
        }

        private void ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                ScoreCards.Clear();

                foreach (var card in _localDataService.ActiveScoreCards)
                {
                    ScoreCards.Add(card);
                }
            }
            catch (Exception ex)
            {
                _errorManagementService.HandleError(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        internal void OnPageAppearing()
        {
            ExecuteLoadItemsCommand();
        }
    }
}
