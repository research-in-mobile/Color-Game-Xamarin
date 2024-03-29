﻿using ColorGame.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms.Internals;

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
                        var stringData = Preferences.Get(nameof(_lastStoredUser), "");
                        if (!string.IsNullOrWhiteSpace(stringData))
                        {
                            _lastStoredUser = JsonConvert.DeserializeObject<User>(stringData);
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
            LoadAllTenantData();            
        }

        public ILocalDataService SetCurrentUser(User user)
        {
            LastStoredUser = user;
            CurrentUser = user;

            LoadCurrentUserScoreCards();
            return this;
        }
        public ILocalDataService StoreContext()
        {
            if (Preferences.ContainsKey(nameof(ScoreCardsFromAllTenant)))
            {
                Preferences.Remove(nameof(ScoreCardsFromAllTenant));
            }

            var dateString = JsonConvert.SerializeObject(ScoreCardsFromAllTenant);
            Preferences.Set(nameof(ScoreCardsFromAllTenant), dateString);

            return this;
        }
        public ILocalDataService SaveContext()
        {
            if (ScoreCardsFromAllTenant == null)
                ScoreCardsFromAllTenant = new Dictionary<Guid, List<ScoreCard>>();

            if (ScoreCardsFromAllTenant.ContainsKey(CurrentUser.Id))
            {
                ScoreCardsFromAllTenant.Remove(CurrentUser.Id);
            }
            ScoreCardsFromAllTenant.Add(CurrentUser.Id, ActiveScoreCards);

            return this;
        }

        public Dictionary<Guid, List<ScoreCard>> LoadAllTenantData()
        {

            if (Preferences.ContainsKey(nameof(ScoreCardsFromAllTenant)))
            {
                var stringData = Preferences.Get(nameof(ScoreCardsFromAllTenant), "");
                if (!string.IsNullOrWhiteSpace(stringData))
                {
                    ScoreCardsFromAllTenant = JsonConvert.DeserializeObject<Dictionary<Guid, List<ScoreCard>>>(stringData);
                }
            }
            if (ScoreCardsFromAllTenant == null)
                ScoreCardsFromAllTenant = new Dictionary<Guid, List<ScoreCard>>();

            return ScoreCardsFromAllTenant;
        }
        public void LoadCurrentUserScoreCards()
        {
            if (CurrentUser == null || ScoreCardsFromAllTenant == null) return;

            if (ScoreCardsFromAllTenant.ContainsKey(CurrentUser.Id))
            {
                ScoreCardsFromAllTenant.TryGetValue(CurrentUser.Id, out var scoreCards);
                ActiveScoreCards = scoreCards;
            }

            if (ActiveScoreCards == null)
                ActiveScoreCards = new List<ScoreCard>();
        }
        public User TryGetUser(string name)
        {
            try
            {
                var scoreCard = ScoreCardsFromAllTenant?.Values?.Select(sc =>
                sc?.FirstOrDefault(u =>
                u.User.Name.Contains(name)))
                    .FirstOrDefault();


                return scoreCard?.User;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
