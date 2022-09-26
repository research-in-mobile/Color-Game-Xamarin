using ColorGame.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.Services
{
    public interface ILocalDataService
    {
        User CurrentUser { get; set; }
        List<ScoreCard> ScoreCards { get; set; }
    }
}
