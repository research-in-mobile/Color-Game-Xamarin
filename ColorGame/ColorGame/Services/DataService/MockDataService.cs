using ColorGame.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.Services
{
    public class MockDataService : ILocalDataService
    {
        public User CurrentUser { get; private set; }
        public List<ScoreCard> ActiveScoreCards { get; set; }


        public ILocalDataService SetCurrentUser(User user)
        {
            throw new NotImplementedException();
        }

        public ILocalDataService StoreContext()
        {
            throw new NotImplementedException();
        }

        public ILocalDataService SaveContext()
        {
            throw new NotImplementedException();
        }

        public void LoadCurrentUserScoreCards()
        {
            throw new NotImplementedException();
        }

        public User TryGetUser(string name)
        {
            throw new NotImplementedException();
        }

        public MockDataService()
        {
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
    }
}
