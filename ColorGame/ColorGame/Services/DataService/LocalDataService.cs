using ColorGame.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ColorGame.Services
{
    public class LocalDataService : ILocalDataService
    {
        public User CurrentUser { get; private set; }
        public List<ScoreCard> ScoreCards { get; set; }

        public LocalDataService()
        {
            ScoreCards = new List<ScoreCard>()
            {
                new ScoreCard(){Id = Guid.NewGuid(), User = new User("Ajay A"), AverageReactionTime = new DateTime(100000000)},
                new ScoreCard(){Id = Guid.NewGuid(), User = new User( "Ajay B"), AverageReactionTime = new DateTime(20000000000)},
                new ScoreCard(){Id = Guid.NewGuid(), User = new User( "Ajay C"), AverageReactionTime = new DateTime(3000000000)},
                new ScoreCard(){Id = Guid.NewGuid(), User = new User( "Ajay D"), AverageReactionTime = new DateTime(400000000)},
                new ScoreCard(){Id = Guid.NewGuid(), User = new User( "Ajay E"), AverageReactionTime = new DateTime(5000000000)},
                new ScoreCard(){Id = Guid.NewGuid(), User = new User( "Ajay F"), AverageReactionTime = new DateTime(100000000000)},
                new ScoreCard(){Id = Guid.NewGuid(), User = new User( "Ajay G"), AverageReactionTime = new DateTime(70000000000)},
                new ScoreCard(){Id = Guid.NewGuid(), User = new User( "Ajay H"), AverageReactionTime = new DateTime(6000000000)},
            };
        }

        public void SetUser(User user)
        {
            CurrentUser = user;
        }
        public void LoadLastUser()
        {
            //CurrentUser = user;
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
