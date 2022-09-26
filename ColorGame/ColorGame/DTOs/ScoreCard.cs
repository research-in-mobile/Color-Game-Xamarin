using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.DTOs
{
    public class ScoreCard
    {
        public Guid Id { get; set; }

        public User User { get; set; }
        public string Name => User.Name;
        public DateTime GameDateTime { get; set; }

        public DateTime AverageReactionTime { get; set; }
        public List<DateTime> ReactionTimes { get; set; } = new List<DateTime>();

    }
}
