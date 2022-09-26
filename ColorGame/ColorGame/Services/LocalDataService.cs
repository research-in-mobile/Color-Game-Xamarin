using ColorGame.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ColorGame.Services
{
    public class LocalDataService : ILocalDataService
    {
        public User CurrentUser { get; set; }
        public List<ScoreCard> ScoreCards { get; set; }

        public LocalDataService()
        {
            ScoreCards = new List<ScoreCard>()
            {
                new ScoreCard(){Id = Guid.NewGuid(), Name = "Ajay A", AverageReactionTime = new DateTime(100000000)},
                new ScoreCard(){Id = Guid.NewGuid(), Name = "Ajay B", AverageReactionTime = new DateTime(20000000000)},
                new ScoreCard(){Id = Guid.NewGuid(), Name = "Ajay C", AverageReactionTime = new DateTime(3000000000)},
                new ScoreCard(){Id = Guid.NewGuid(), Name = "Ajay D", AverageReactionTime = new DateTime(400000000)},
                new ScoreCard(){Id = Guid.NewGuid(), Name = "Ajay E", AverageReactionTime = new DateTime(5000000000)},
                new ScoreCard(){Id = Guid.NewGuid(), Name = "Ajay F", AverageReactionTime = new DateTime(100000000000)},
                new ScoreCard(){Id = Guid.NewGuid(), Name = "Ajay G", AverageReactionTime = new DateTime(70000000000)},
                new ScoreCard(){Id = Guid.NewGuid(), Name = "Ajay H", AverageReactionTime = new DateTime(6000000000)},
            };
        }
    }
}
