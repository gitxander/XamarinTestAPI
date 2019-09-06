using System;
using System.Collections.Generic;
using TestWebAPI.Model;
using TestWebAPI.Data;
using Xamarin.Forms;

namespace TestWebAPI.View
{
    public partial class UserViewDetails : ContentPage
    {
        public UserViewDetails()
        {
            InitializeComponent();
        }

        /* TRIGGER TO SAVE UPDATED USER INFO */
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            User user = (User)BindingContext;

            user.Id = Convert.ToInt32(Id.Text);
            user.Last_Name = Last_Name.Text;
            user.First_Name = First_Name.Text;
            user.Email = Email.Text;

            UserData userData = new UserData();
            var data = await userData.PutDataAsync(user);
            
            await DisplayAlert("Success", "Your data has been updated", "OK");

            await Navigation.PopAsync(); 
        }

        /* TRIGGER TO DELETE USER */
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            User user = (User)BindingContext;

            user.Id = Convert.ToInt32(Id.Text);
            UserData userData = new UserData();
            var data = await userData.DeleteDataAsync(user);

            await DisplayAlert("Success", "Deleted!", "OK");

            await Navigation.PopAsync();
        }
    }
}