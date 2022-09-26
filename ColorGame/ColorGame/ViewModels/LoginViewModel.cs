using ColorGame.DTOs;
using ColorGame.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ColorGame.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private User _user = new User();
        public User CurrectUser
        {
            get => _user;
            set
            {
                SetProperty(ref _user, value);
            }
        }

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogin);
        }

        private async void OnLogin()
        {
            if (CurrectUser == null || string.IsNullOrEmpty(CurrectUser.Name))
            {
                await App.Current.MainPage.DisplayAlert("Sorry", "We need a name!", "Ok");
                return;
            }

            GoTo(nameof(HomePage));
        }
    }
}
