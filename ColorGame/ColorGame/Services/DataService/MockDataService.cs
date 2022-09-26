using ColorGame.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.Services
{
    public class MockDataService : ILocalDataService
    {
        public User CurrentUser => throw new NotImplementedException();

        public List<ScoreCard> ActiveScoreCards { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void LoadScoreCards()
        {
            throw new NotImplementedException();
        }

        public void SaveScoreCards()
        {
            throw new NotImplementedException();
        }

        public void SetCurrentUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
