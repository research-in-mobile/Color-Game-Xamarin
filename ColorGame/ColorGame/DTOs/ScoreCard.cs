using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.DTOs
{
    public class ScoreCard
    {

        public Guid Id { get; set; }

        public User User { get; set; }
        public DateTime GameDateTime { get; set; }

        public TimeSpan AverageReactionTime { get; set; }
        public List<UserSelection> UserSelections { get; set; } = new List<UserSelection>();

    }
}
