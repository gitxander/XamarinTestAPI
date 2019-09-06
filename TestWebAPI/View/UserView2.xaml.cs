using System;
using System.Collections.Generic;
using TestWebAPI.ViewModel;   

using Xamarin.Forms;

namespace TestWebAPI.View
{
    public partial class UserView : ContentPage
    {
        public UserViewModel ViewModel { get; }

        public UserView()
        {
            InitializeComponent();
            BindingContext = ViewModel = new UserViewModel();
        }
    }
}
