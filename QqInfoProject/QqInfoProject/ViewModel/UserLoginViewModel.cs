using System.Collections.ObjectModel;
using QqInfoProject.Model;
using QqInfoProject.View;
using Xamarin.Forms;

namespace QqInfoProject.ViewModel
{
    public class UserLoginViewModel
    {
        public ObservableCollection<User> UsersList { get; set; }

        public Color TextColor { get; set; } = QqinfoAppSettings.BlueColor;
        public Color BackgroundColor { get; set; } = QqinfoAppSettings.WhiteColor;

        public string LoginTitle { get; set; } = "Autentificare";
    }
}