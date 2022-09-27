using ColorGame.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.Services
{
    public interface ILocalDataService
    {
        User CurrentUser { get; }
        void SetCurrentUser(User user);

        void SaveScoreCards();
        void LoadCurrentUserScoreCards();

        List<ScoreCard> ActiveScoreCards { get; set; }
    }
}
