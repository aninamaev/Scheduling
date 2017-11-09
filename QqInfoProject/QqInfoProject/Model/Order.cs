using System.ComponentModel;
using System.Runtime.CompilerServices;
using QqInfoProject.Enums;
using QqInfoProject.ViewModel;
using Xamarin.Forms;

namespace QqInfoProject.Model
{
    public class Order : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        private Status currentOrderStatus;
        public Status CurrentOrderStatus
        {
            get { return currentOrderStatus; }
            set
            {
                currentOrderStatus = value;
                OnPropertyChanged("OrderStatus");
            }
        }
        
        public string OrderStatus => FontIoniconsUsage.ReturnFontsForStatus(CurrentOrderStatus);

        // for intreface, to be optimised
        public Color TextColor { get; set; } = QqinfoAppSettings.BlueColor;
        public Color ButtonBackgroundColor { get; set; } = QqinfoAppSettings.GrayColor;

        #region INPC implmentation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}