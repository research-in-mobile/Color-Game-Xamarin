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

            ActiveScoreCards = new List<ScoreCard>()
            {
                new ScoreCard(){Id = Guid.NewGuid(), User = new User( "Ajay A"), AverageReactionTime = new TimeSpan(100000000)},
                new ScoreCard(){Id = Guid.NewGuid(), User = new User( "Ajay B"), AverageReactionTime = new TimeSpan(20000000000)},
                new ScoreCard(){Id = Guid.NewGuid(), User = new User( "Ajay C"), AverageReactionTime = new TimeSpan(3000000000)},
                new ScoreCard(){Id = Guid.NewGuid(), User = new User( "Ajay D"), AverageReactionTime = new TimeSpan(400000000)},
                new ScoreCard(){Id = Guid.NewGuid(), User = new User( "Ajay E"), AverageReactionTime = new TimeSpan(5000000000)},
                new ScoreCard(){Id = Guid.NewGuid(), User = new User( "Ajay F"), AverageReactionTime = new TimeSpan(100000000000)},
                new ScoreCard(){Id = Guid.NewGuid(), User = new User( "Ajay G"), AverageReactionTime = new TimeSpan(70000000000)},
                new ScoreCard(){Id = Guid.NewGuid(), User = new User( "Ajay H"), AverageReactionTime = new TimeSpan(6000000000)},
            };
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
        public void LoadLastUser()
        {
            //TODO
        }

        public void SaveScoreCards()
        {
            //TODO:
        }
        public void LoadScoreCards()
        {
            //TODO:
        }
    }
}
