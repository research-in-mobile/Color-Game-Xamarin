using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.Views
{
    public interface IAnimation<T>
    {
        void Start(Action<T> onValueCallback, Action onComplete = null);
    }
}

