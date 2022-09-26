using ColorGame.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        private ColorIndex _colorShowingIndex;
        public ColorIndex CurrentShowingColor
        {
            get => _colorShowingIndex;
            set => SetProperty(ref _colorShowingIndex, value);
        }

        public GameViewModel()
        {
            CurrentShowingColor = ColorIndex.Yellow;
        }

    }
}
