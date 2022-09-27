using ColorGame.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.Services
{
    public interface ILocalDataService
    {
        User CurrentUser { get; }
        ILocalDataService SetCurrentUser(User user);

        ILocalDataService StoreContext();
        ILocalDataService SaveContext();
        void LoadCurrentUserScoreCards();

        List<ScoreCard> ActiveScoreCards { get; set; }
    }
}
