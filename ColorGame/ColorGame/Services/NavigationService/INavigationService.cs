using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.Services
{
    public interface INavigationService
    {
        void StoreNavigationItem(object item);
        T GetNavigationItem<T>();
        void ClearNavigationItem();
    }
}
