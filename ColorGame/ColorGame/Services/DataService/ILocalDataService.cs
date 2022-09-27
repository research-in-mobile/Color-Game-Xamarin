using ColorGame.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.Services
{
    public interface ILocalDataService
    {
        User CurrentUser { get; }
        List<ScoreCard> ActiveScoreCards { get; set; }

        ILocalDataService SetCurrentUser(User user);
        ILocalDataService StoreContext();
        ILocalDataService SaveContext();
        void LoadCurrentUserScoreCards();
    }
}
