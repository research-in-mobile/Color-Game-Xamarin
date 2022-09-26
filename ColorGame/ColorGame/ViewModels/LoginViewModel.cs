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

        int _age;
        public int Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }


        public Command LoginCommand { get; }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogin);
        }

        private async void OnLogin()
        {
            if (string.IsNullOrEmpty(Name))
            {
                Name = string.Empty;
                //TODO:Get from localization text resources 
                await App.Current.MainPage.DisplayAlert("Sorry", "We need a name!", "Ok");
                return;
            }

            //This is where usually a call is made to the Auth Service and a successful retrun will log user in.

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Age = Age
            };

            _localDataService.SetUser(user);

            GoTo("//" + nameof(HomePage));
        }
    }
}
