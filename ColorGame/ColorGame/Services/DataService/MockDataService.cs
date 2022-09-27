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

        public LocalDataService LoadCurrentUserScoreCards()
        {
            throw new NotImplementedException();
        }

        public LocalDataService SaveContext()
        {
            throw new NotImplementedException();
        }

        public void SetCurrentUser(User user)
        {
            throw new NotImplementedException();
        }

        LocalDataService ILocalDataService.SetCurrentUser(User user)
        {
            throw new NotImplementedException();
        }

        public LocalDataService StoreContext()
        {
            throw new NotImplementedException();
        }

        void ILocalDataService.LoadCurrentUserScoreCards()
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
