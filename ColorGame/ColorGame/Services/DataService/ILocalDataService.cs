using ColorGame.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.Services
{
    public interface ILocalDataService
    {
        User CurrentUser { get; }
        void SetUser(User user);


        List<ScoreCard> ScoreCards { get; set; }
    }
}
