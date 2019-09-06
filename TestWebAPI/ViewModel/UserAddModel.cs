using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using TestWebAPI.Data;
using TestWebAPI.Model;

namespace TestWebAPI.ViewModel
{
    public class UserAddModel : INotifyPropertyChanged
    {
        UserData userData;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<User> _userList;

        //public ObservableCollection<User> UserList
        //{
        //    get { return _userList; }
        //    set
        //    {
        //        _userList = value;
        //        if (PropertyChanged != null)
        //        {
        //            PropertyChanged(this, new PropertyChangedEventArgs("UserList"));
        //        }
        //    }
        //}

        public async Task PostDataAsync(User user)
        {
            var list = await userData.PostDataAsync(user);
            //UserList = new ObservableCollection<User>(list);
        }

        public UserAddModel(User user)
        {
            _ = PostDataAsync(user);
        }

        //private void save(object sender, EventArgs e)
        //{
        //    User user = new User()
        //    {
        //        First_Name = First_Name.text;
        //    };
        //}
    }
}
