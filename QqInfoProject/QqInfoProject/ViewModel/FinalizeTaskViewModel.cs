using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using QqInfoProject.Model;
using QqInfoProject.View;
using Xamarin.Forms;

namespace QqInfoProject.ViewModel
{
    public class FinalizeTaskViewModel : INotifyPropertyChanged
    {
        public Color BackgroundColor { get; set; } = QqinfoAppSettings.WhiteColor;
        public Color TextColor { get; set; } = QqinfoAppSettings.BlueColor;

        public string FinalizeTaskTitle { get; set; } = "Evaluare rezultate";
        public string TaskName { get; set; }
        public decimal NumberOfPieces { get; set; }

        private int result;
        public string Result
        {
            get { return $"Au iesit {result} bucati bune si {50 - result} nereusite."; }
            set
            {
                int.TryParse(value, out result);
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Reason> UnsuccesResultsCollection { get; set; } = new ObservableCollection<Reason>()
        {
            new Reason() {Name = "Ars", number = 0},
            new Reason() {Name = "Necopt", number = 0},
            new Reason() {Name = "Impur", number = 0},
            new Reason() {Name = "Rupt", number = 0},
        };

        #region implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}