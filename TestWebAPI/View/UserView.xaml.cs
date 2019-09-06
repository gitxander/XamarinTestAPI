using System;
using System.Collections.Generic;
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

        /* TRIGGER AFTER ADD/UPDATE/DELETE DATA. REFRESH TABLE ROW */
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            UserData userData = new UserData();
            ListView.ItemsSource = await userData.GetDataAsync();
        }

        /* TRIGGER WHEN ADD NEW USER BUTTON IS CLICKED */
        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserAdd
            {
                BindingContext = new User()
            });
        }

        /* TRIGGER WHEN AN ITEM IS SELECTED FROM TABLE ROW */
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
