using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QqInfoProject.Model;
using Xamarin.Forms;

namespace QqInfoProject.View
{
    public partial class IngredientDetailsPage : ContentPage
    {
        private bool lotSelected;

        public IngredientDetailsPage()
        {
            InitializeComponent();
            BindingContext = new IngredientDetailsViewModel();
        }

        public void OnOkButtonClicked(object sender, EventArgs e)
        {
            if (lotSelected)
                DisplayAlert("Succes", "Selectie loturi pentru ingredient finalizata.", "Ok");
            else
                DisplayAlert("Eroare", "Va trebui sa selectezi lotul/loturile pe care le vei folosi.", "Ok");

            Navigation.PopAsync();
        }

        public void OnCancelButtonClicked(object sender, EventArgs e)
        {
            DisplayAlert("Eroare", "Va trebui sa selectezi lotul/loturile pe care le vei folosi.", "Ok");
            Navigation.PopAsync();
        }

        private void SwitchToggled(object sender, ToggledEventArgs e)
        {
            if (!lotSelected)
                lotSelected = true;
        }
    }

    public class IngredientDetailsViewModel
    {
        public Color BackgroundColor { get; set; } = QqinfoAppSettings.WhiteColor;
        public Color TextColor { get; set; } = QqinfoAppSettings.BlueColor;

        public string IngredientDetailsTitle { get; set; } = "Făină albă";

        public ObservableCollection<IngredientBatch> BatchCollection { get; set; } = new ObservableCollection<IngredientBatch>(FakeInfo.ReturnIngredientBatchForIngredient(1));
    }
}
