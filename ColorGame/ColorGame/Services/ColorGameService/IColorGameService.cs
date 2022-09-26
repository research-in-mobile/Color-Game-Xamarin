using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.Services
{
    public interface IColorGameService
    {
        void StartNewGame();
        int GetNextColor();
        void SaveGameResults();
    }
}
