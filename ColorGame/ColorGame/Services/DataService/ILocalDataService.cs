using ColorGame.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.Services
{
    public interface ILocalDataService
    {
        User CurrentUser { get; }
        LocalDataService SetCurrentUser(User user);

        LocalDataService StoreContext();
        LocalDataService SaveContext();
        void LoadCurrentUserScoreCards();

        List<ScoreCard> ActiveScoreCards { get; set; }
    }
}
