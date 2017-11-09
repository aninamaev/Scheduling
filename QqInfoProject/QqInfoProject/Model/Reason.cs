using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace QqInfoProject.Model
{
    public class Reason : INotifyPropertyChanged
    {
        public string Name { get; set; }

        public int number = 0;
        public string Number
        {
            get { return number.ToString(); }
            set
            {
                int.TryParse(value, out number);
                //number = int.Parse(value);
                OnPropertyChanged();
            }
        }

        private bool isReason;
        public bool IsReason
        {
            get { return isReason; }
            set
            {
                isReason = value;
                OnPropertyChanged();
            }
        }

        public Color TextColor { get; set; } = QqinfoAppSettings.BlueColor;

        #region implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}