using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QqInfoProject.Enums;
using QqInfoProject.Model;
using Xamarin.Forms;

namespace QqInfoProject.View
{
    public partial class TaskDetailsPage : ContentPage
    {
        private readonly FakeInfo fakeInfo;
        private readonly StTask task;

        public TaskDetailsPage(StTask task, int stageId)
        {
            this.task = task;

            InitializeComponent();
            fakeInfo = FakeInfo.Instance;

            var taskDetailsViewModel = new TaskDetailsViewModel()
            {
                TaskDetailsTitle = $"Detalii",
                TaskName = $"{task.Name}",
                EquipmentName = $"Echipament: {fakeInfo.ReturnStageById(stageId).Equipment}",
                HasIngredients = task.HasIngredients
            };

            if (task.HasIngredients)
                taskDetailsViewModel.IngredientsCollection = new ObservableCollection<Ingredient>(fakeInfo.ReturnIngredientsForTask(task.Id));

            BindingContext = taskDetailsViewModel;
        }

        public void LotButtonClicked(object sender, EventArgs e)
        {
            var ingredientId = (sender as Button)?.CommandParameter;

            Navigation.PushAsync(new IngredientDetailsPage());
        }

        #region buttons
        public void OnStartButtonClicked(object sender, EventArgs e)
        {
            fakeInfo.ModifyTaskStatus(task.Id, Status.Progress);

            StartButton.IsEnabled = false;
            HoldButton.IsEnabled = true;
            CancelButton.IsEnabled = true;
            FinalizeButton.IsEnabled = true;

            Navigation.PopAsync();
        }

        public void OnHoldButtonClicked(object sender, EventArgs e)
        {
            fakeInfo.ModifyTaskStatus(task.Id, Status.Hold);

            StartButton.IsEnabled = true;
            HoldButton.IsEnabled = false;
            CancelButton.IsEnabled = true;
            FinalizeButton.IsEnabled = false;

            Navigation.PopAsync();
        }

        public void OnCancelButtonClicked(object sender, EventArgs e)
        {
            fakeInfo.ModifyTaskStatus(task.Id, Status.Canceled);

            StartButton.IsEnabled = true;
            HoldButton.IsEnabled = false;
            CancelButton.IsEnabled = false;
            FinalizeButton.IsEnabled = false;

            Navigation.PopAsync();
        }

        public void OnFinalizeButtonClicked(object sender, EventArgs e)
        {
            fakeInfo.ModifyTaskStatus(task.Id, Status.Done);

            StartButton.IsEnabled = false;
            HoldButton.IsEnabled = false;
            CancelButton.IsEnabled = false;
            FinalizeButton.IsEnabled = true;

            Navigation.PushAsync(new FinalizeTaskPage(task));
        }
        #endregion
    }

    public class TaskDetailsViewModel
    {
        public Color BackgroundColor { get; set; } = QqinfoAppSettings.WhiteColor;
        public Color TextColor { get; set; } = QqinfoAppSettings.BlueColor;

        public string TaskDetailsTitle { get; set; }

        public string TaskName { get; set; }

        public string EquipmentName { get; set; }

        public ObservableCollection<Ingredient> IngredientsCollection { get; set; }// = new ObservableCollection<Ingredient>(FakeInfo.ReturnIngredientsForStep(1));

        public bool HasIngredients { get; set; }
    }
}
