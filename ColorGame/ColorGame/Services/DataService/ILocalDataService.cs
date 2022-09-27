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
        User TryGetUser(string name);

        ILocalDataService SetCurrentUser(User user);
        ILocalDataService StoreContext();
        ILocalDataService SaveContext();
        void LoadCurrentUserScoreCards();
    }
}
