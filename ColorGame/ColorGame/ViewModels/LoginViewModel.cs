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
        public User CurrentUser
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
            if (CurrentUser == null || string.IsNullOrEmpty(CurrentUser.Name))
            {
                await App.Current.MainPage.DisplayAlert("Sorry", "We need a name!", "Ok");
                return;
            }

            //This is where usually a call is made to the Auth Service and a successful retrun will log user in.
            CurrentUser.Id = Guid.NewGuid();
            GoTo(nameof(HomePage));
        }
    }
}
