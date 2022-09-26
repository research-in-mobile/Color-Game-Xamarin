using ColorGame.ViewModels;
using ColorGame.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ColorGame
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(GamePage), typeof(GamePage));
            Routing.RegisterRoute(nameof(GameDetailsPage), typeof(GameDetailsPage));

        }

    }
}
