using System;
using System.Collections.Generic;
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
    public partial class PasswordLoginPage : ContentPage
    {
        private readonly User user;

        public PasswordLoginPage(User user)
        {
            Title = user.Name;

            InitializeComponent();
            BindingContext = new PasswordLoginViewModel() {UserImageSource = user.Photo};

            this.user = user;
        }

        public void OnLoginButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrdersPage(user));
        }
    }
}
