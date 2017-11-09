using System.Collections.ObjectModel;
using QqInfoProject.Model;
using Xamarin.Forms;

namespace QqInfoProject.ViewModel
{
    public class OrdersViewModel
    {
        public Color BackgroundColor { get; set; } = QqinfoAppSettings.WhiteColor;
        public Color TextColor { get; set; } = QqinfoAppSettings.BlueColor;
        public double TextFont { get; set; } = QqinfoAppSettings.TextFontSize;

        public string OrdersTitle { get; set; }
        public string LabelText { get; set; }

        public ObservableCollection<Order> OrdersCollection { get; set; }
    }
}