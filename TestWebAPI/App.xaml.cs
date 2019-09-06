using System;
using System.Diagnostics;
using TestWebAPI.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestWebAPI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new UserView());
        }

        protected override void OnStart()
        { 
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
