using ColorGame.Services;
using ColorGame.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ColorGame
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            DependencyService.RegisterSingleton<IErrorManagementService>(new ErrorManagementService());
            DependencyService.RegisterSingleton<INavigationService>(new NavigationService());
            DependencyService.RegisterSingleton<ILocalDataService>(new LocalDataService());
            DependencyService.RegisterSingleton<IColorGameService>(new ColorGameService());

            MainPage = new AppShell();
        }

    }
}
