using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.Services
{
    public interface INotificationService
    {
        void Show(string title, string body, int id = 0);
        void Show(string title, string body, int id, DateTime notifyTime);
        void Cancel(int id);
    }
}
