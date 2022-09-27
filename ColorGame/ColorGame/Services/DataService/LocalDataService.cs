using ColorGame.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;

namespace ColorGame.Services
{
    public class LocalDataService : ILocalDataService
    {
        public User CurrentUser { get; private set; }

        private User _lastStoredUser = null;
        public User LastStoredUser
        {
            get
            {
                if (_lastStoredUser == null)
                {
                    if (Preferences.ContainsKey(nameof(_lastStoredUser)))
                    {
                        var lastOnlineString = Preferences.Get(nameof(_lastStoredUser), "");
                        if (!string.IsNullOrWhiteSpace(lastOnlineString))
                        {
                            _lastStoredUser = JsonConvert.DeserializeObject<User>(lastOnlineString);
                        }
                    }
                }

                return _lastStoredUser;
            }
            set
            {
                if (value == null) return;

                _lastStoredUser = value;

                if (Preferences.ContainsKey(nameof(_lastStoredUser)))
                {
                    Preferences.Remove(nameof(_lastStoredUser));
                }

                var dateString = JsonConvert.SerializeObject(value);
                Preferences.Set(nameof(_lastStoredUser), dateString);
            }
        }

        public List<ScoreCard> ActiveScoreCards { get; set; }
        public Dictionary<Guid, List<ScoreCard>> ScoreCardsFromAllTenant { get; private set; }


        public LocalDataService()
        {
            CurrentUser = LastStoredUser;

        }

        public void SetCurrentUser(User user)
        {
            LastStoredUser = user;
            CurrentUser = user;
        }

        public void LoadAllTenantData()
        {
            //TODO
        }


        public void StoreContext()
        {
            //TODO
        }

        public void SaveScoreCards()
        {
            if (ScoreCardsFromAllTenant == null)
                ScoreCardsFromAllTenant = new Dictionary<Guid, List<ScoreCard>>();

            if (ScoreCardsFromAllTenant.ContainsKey(CurrentUser.Id))
            {
                ScoreCardsFromAllTenant.Remove(CurrentUser.Id);
            }
            ScoreCardsFromAllTenant.Add(CurrentUser.Id, ActiveScoreCards);
        }

        public void LoadCurrentUserScoreCards()
        {

            if (ScoreCardsFromAllTenant.ContainsKey(CurrentUser.Id))
            {
                ScoreCardsFromAllTenant.TryGetValue(CurrentUser.Id, out var scoreCards);
                ActiveScoreCards = scoreCards;
            }
        }
    }
}
