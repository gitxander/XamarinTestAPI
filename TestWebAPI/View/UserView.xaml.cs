using System;
using System.Collections.Generic;
using TestWebAPI.ViewModel;
using Xamarin.Forms;
using TestWebAPI.Model;
using TestWebAPI.Data;

namespace TestWebAPI.View
{
    public partial class UserView : ContentPage
    {
        //public UserViewModel ViewModel { get; }

        public UserView()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            UserData userData = new UserData();
            ListView.ItemsSource = await userData.GetDataAsync();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserAdd
            {
                BindingContext = new User()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new UserViewDetails
                {
                    BindingContext = e.SelectedItem as User
                });
            }
        }
    }
}
