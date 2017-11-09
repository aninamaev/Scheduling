using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using QqInfoProject.Model;
using QqInfoProject.ViewModel;
using Xamarin.Forms;

namespace QqInfoProject.View
{
    public partial class UserLoginPage : ContentPage
    {
        public UserLoginPage()
        {
            var fakeInfo = FakeInfo.Instance;

            InitializeComponent();
            BindingContext = new UserLoginViewModel() {UsersList = new ObservableCollection<User>(fakeInfo.ReturnUsersList()) };
        }

        public void UserSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var user = e.SelectedItem as User;
            Navigation.PushAsync(new PasswordLoginPage(user));
        }
    }
}
