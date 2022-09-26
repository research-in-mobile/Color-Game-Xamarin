using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.DTOs
{
    public class UserSelection
    {
        public ColorIndex DisplayiedColorIndex { get; set; }
        public ColorIndex ResponseColorIndex { get; set; }
        public TimeSpan ResponseTime { get; set; }

    }
}
