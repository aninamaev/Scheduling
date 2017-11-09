using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QqInfoProject.Model;
using QqInfoProject.ViewModel;
using Xamarin.Forms;

namespace QqInfoProject.View
{
    public partial class FinalizeTaskPage : ContentPage
    {
        private readonly FinalizeTaskViewModel finalizeTaskViewModel;
        private readonly StTask task;

        public FinalizeTaskPage(StTask task)
        {
            InitializeComponent();

            task.NumberOfPieces = 50;
            finalizeTaskViewModel = new FinalizeTaskViewModel { TaskName = $"Scop: realizare 50 de chifle albe", NumberOfPieces = task.NumberOfPieces, Result = "0" };
            this.task = task;

            BindingContext = finalizeTaskViewModel;
        }

        public void ValueChangedFromSlider(object sender, ValueChangedEventArgs e)
        {
            var slider = sender as Slider;
            if (slider != null)
            {
                VaueEntry.Text = ((int)slider.Value).ToString();
                finalizeTaskViewModel.Result = ((int)slider.Value).ToString();
            }
        }

        public void EntryUnfocusd(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;
            if (entry != null)
            {
                var entryValue = int.Parse(entry.Text);
                if ((entryValue <= task.NumberOfPieces) && (entryValue > 0))
                    GoodPiecesSlider.Value = entryValue;
                else
                {
                    DisplayAlert("Eroare", $"Nu poti introduce valoare mai mare de {task.NumberOfPieces}", "Reincercare");
                    GoodPiecesSlider.Value = 50;
                    GoodPiecesSlider.Value = 0;
                }
            }
        }

        

        public void OnOkButtonClicked(object sender, EventArgs e)
        {
            DisplayAlert("Succes", "Operatiune finalizata", "Ok");
            Navigation.PopAsync();
        }

        public void OnCancelButtonClicked(object sender, EventArgs e)
        {
            DisplayAlert("Error", "Operatiune nefinalizata", "Ok");
            Navigation.PopAsync();
        }

        private void IsReasonClicked(object sender, ToggledEventArgs e)
        {
            
        }

        private void ReasonSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var reason = e.SelectedItem as Reason;
            if (reason != null)
            {
                reason.IsReason = true;
                reason.Number = (50 - int.Parse(VaueEntry.Text)).ToString();
            }

            ReasonsListview.SelectedItem = null;
        }
    }
}
