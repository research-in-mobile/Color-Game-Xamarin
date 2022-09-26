using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ColorGame.Services
{
    public class NavigationService : INavigationService
    {
        protected readonly IErrorManagementService _errorManagementService;
        public NavigationService()
        {
            _errorManagementService = DependencyService.Resolve<IErrorManagementService>();
        }

        private string _navigationItemString;
        public void ClearNavigationItem()
        {
            _navigationItemString = string.Empty;
        }
        public T GetNavigationItem<T>()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_navigationItemString))
                {
                    return JsonConvert.DeserializeObject<T>(_navigationItemString);
                }
            }
            catch (Exception ex)
            {
                _errorManagementService.HandleError(ex);
            }
            return default(T);
        }
        public void StoreNavigationItem(object item)
        {
            if (item == null) return;
            _navigationItemString = JsonConvert.SerializeObject(item);
        }
    }
}
