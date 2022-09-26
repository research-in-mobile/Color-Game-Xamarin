using ColorGame.DTOs;
using ColorGame.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ColorGame.ViewModels
{
    [QueryProperty(nameof(ScoreCardId), nameof(ScoreCardId))]
    public class GameDetailsViewModels : BaseViewModel
    {
        private string _id;
        public string ScoreCardId
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                LoadScoreCard(value);
            }
        }

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

        }

        private void LoadScoreCard(string value)
        {
            var hasId = Guid.TryParse(value, out var id);
            //TODO
        }
    }
}
