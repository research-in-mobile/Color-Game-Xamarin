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
        string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        int? _age;
        public int? Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }

        private User _lastLoggedUser;

        public Command LoginCommand { get; }
        public LoginViewModel()
        {
            _lastLoggedUser = _localDataService.CurrentUser;

            if (_lastLoggedUser != null)
            {
                Name = _lastLoggedUser.Name;
                Age = _lastLoggedUser.Age.Value;
            }

            LoginCommand = new Command(OnLogin);
        }

        private async void OnLogin()
        {
            if (string.IsNullOrEmpty(Name))
            {
                Name = string.Empty;

                await App.Current.MainPage.DisplayAlert("Sorry", "We need a name!", "Ok"); //TODO:Get from localization text resources 
                return;
            }

            //This is where usually a call is made to the Auth Service and a successful retrun will log user in.
            if (_lastLoggedUser != null && _lastLoggedUser.Name == Name)
            {
                _localDataService.SetCurrentUser(_lastLoggedUser);

            }
            else
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = Name,
                    Age = Age
                };

                _localDataService.SetCurrentUser(user);
            }

            GoTo("//" + nameof(HomePage));
        }
    }
}
