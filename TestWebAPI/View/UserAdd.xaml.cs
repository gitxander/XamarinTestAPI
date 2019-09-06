using System;
using System.Collections.Generic;
using TestWebAPI.Model;
using TestWebAPI.ViewModel;
using Xamarin.Forms;

using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using TestWebAPI.Data;

namespace TestWebAPI.View
{
    public partial class UserAdd : ContentPage
    {
        public UserAdd()
        {
            InitializeComponent();
        }

        private async void save(object sender, EventArgs e)
        {
            User user = new User();

            user.Last_Name = Last_Name.Text;
            user.First_Name = First_Name.Text;
            user.Email = Email.Text;

            UserData userData = new UserData();
            var data = await userData.PostDataAsync(user);

            await DisplayAlert("Success", "Your data has been added", "OK");

            await Navigation.PopAsync();

        }
    }
}
