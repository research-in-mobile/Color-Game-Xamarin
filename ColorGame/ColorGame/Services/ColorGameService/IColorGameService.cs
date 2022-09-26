using ColorGame.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.Services
{
    public interface IColorGameService
    {
        ColorGameService StartNewGame();
        ColorGameService StoreUserSelection(ColorIndex index, TimeSpan deltaTimeSpan);
        ColorGameService SaveGameResults();

        ColorIndex? GetNextColorIndex();

    }
}
