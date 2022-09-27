using ColorGame.DTOs;
using ColorGame.Services;
using ColorGame.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ColorGame.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private bool _isLeaderBoardAsc = true;

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

        private ObservableCollection<ScoreCard> _filteredScoreCards;
        public ObservableCollection<ScoreCard> FilteredScoreCards
        {
            get => _filteredScoreCards;
            set => SetProperty(ref _filteredScoreCards, value);
        }
        public ObservableCollection<ScoreCard> ScoreCards { get; set; }

        public Command ToggleLeaderboardCommand { get; }
        public Command LoadScoreCardsCommand { get; }
        public Command<ScoreCard> GotoScoreCardCommand { get; }
        public Command<string> SearchCommand { get; }

        public HomeViewModel()
        {
            LoadScoreCardsCommand = new Command(OnLoadScoreCards);
            GotoScoreCardCommand = new Command<ScoreCard>(OnSelected);
            SearchCommand = new Command<string>(OnSearch);

            FilteredScoreCards = ScoreCards = new ObservableCollection<ScoreCard>(_localDataService.ActiveScoreCards);
            ToggleLeaderboardCommand = new Command(ToggleSortLeaderboard);
        }

        private void OnSelected(ScoreCard scoreCard)
        {
            if (scoreCard == null)
                return;

            _navigationService.StoreNavigationItem(scoreCard);
            GoTo($"{nameof(GameDetailsPage)}", true);
        }
        private void OnLoadScoreCards()
        {
            IsBusy = true;

            try
            {
                ScoreCards.Clear();

                foreach (var card in _localDataService.ActiveScoreCards)
                {
                    ScoreCards.Add(card);
                }

                FilteredScoreCards = new ObservableCollection<ScoreCard>(ScoreCards);
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
        private void ToggleSortLeaderboard()
        {
            _isLeaderBoardAsc = !_isLeaderBoardAsc;

            if(_isLeaderBoardAsc)
            {
                var filtered = ScoreCards.OrderBy(sc => sc.AverageReactionTime.Ticks);
                FilteredScoreCards = new ObservableCollection<ScoreCard>(filtered);
            }
            else
            {
                var filtered = ScoreCards.OrderByDescending(sc => sc.AverageReactionTime.Ticks);
                FilteredScoreCards = new ObservableCollection<ScoreCard>(filtered);
            }
            
        }

        internal void OnPageAppearing()
        {
            OnLoadScoreCards();
        }
        internal void OnSearch(string search)
        {
            if (ScoreCards == null)
                return;

            if (string.IsNullOrWhiteSpace(search))
                FilteredScoreCards = ScoreCards;
            else
            {
                var filtered = ScoreCards.Where(sc => sc.User.Name.ToLower().Contains(search.ToLower()));
                FilteredScoreCards = new ObservableCollection<ScoreCard>(filtered);
            }

        }
    }
}
