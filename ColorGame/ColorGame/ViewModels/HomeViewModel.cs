﻿using ColorGame.DTOs;
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

        public ObservableCollection<ScoreCard> ScoreCards { get; set; }

        public Command LoadScoreCardsCommand { get; }
        public Command<ScoreCard> ScoreCardTapped { get; }


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

        private readonly ILocalDataService _localDataService;
        public HomeViewModel()
        {
            _localDataService = DependencyService.Resolve<ILocalDataService>();


            LoadScoreCardsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ScoreCardTapped = new Command<ScoreCard>(OnSelected);

            ScoreCards = new ObservableCollection<ScoreCard>(_localDataService.ScoreCards);
        }

        private async void OnSelected(ScoreCard scoreCard)
        {
            if (scoreCard == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(GameDetailsPage)}?{nameof(GameDetailsViewModels.ScoreCardId)}={scoreCard.Id}");
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                ScoreCards.Clear();
                //var items = await _localDataService.GetItemsAsync(true);
                foreach (var card in _localDataService.ScoreCards)
                {
                    ScoreCards.Add(card);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
