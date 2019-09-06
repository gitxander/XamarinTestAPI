using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using TestWebAPI.Data;
using TestWebAPI.Model;

namespace TestWebAPI.ViewModel
{
    public class UserViewModel:INotifyPropertyChanged
    {
        UserData userData = new UserData();
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<User> _userList;

        public ObservableCollection<User> UserList
        {
            get { return _userList; }
            set
            {
                _userList = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("UserList"));
                }
            }
        }

        public async Task FetchDataAsync()
        {
            var list = await userData.GetDataAsync();
            UserList = new ObservableCollection<User>(list);
        }

        public UserViewModel()
        {
            _ = FetchDataAsync();
        }
    }
}
