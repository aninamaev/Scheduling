using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QqInfoProject.Enums;
using QqInfoProject.Model;
using QqInfoProject.ViewModel;
using Xamarin.Forms;

namespace QqInfoProject.View
{
    public partial class OrdersPage : ContentPage
    {
        private readonly List<Order> ordersList;
        private readonly User user;

        public OrdersPage(User user)
        {
            InitializeComponent();

            var fakeInfo = FakeInfo.Instance;
            ordersList = fakeInfo.ReturnOrdersListForUser(user.Id);

            this.user = user;

            fakeInfo.ModifyStatusButtonAction += (taskId) =>
            {
                var currentOrder = fakeInfo.ReturnOrderByTask(taskId);
                var currentTask = fakeInfo.ReturnTaskById(taskId);

                currentOrder.CurrentOrderStatus = currentTask.TaskStatus;
            };

            BindingContext = new OrdersViewModel
            {
                OrdersTitle = user.Name,
                LabelText = $"Comenzi din data de {DateTime.Now.ToString("d")}",
                OrdersCollection = new ObservableCollection<Order>(ordersList)
            };
        }

        public void OrderSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;

            var currentOrder = e.SelectedItem as Order;
            if (currentOrder != null)
            {
                Navigation.PushAsync(new SchedulerTabbedPage(ordersList, currentOrder.Id, user));
            }
        }

        public void OrderStatusButtonClicked(object sender, EventArgs e)
        {
            //var orderId = (sender as Button)?.CommandParameter;
            //if (orderId != null)
            //{
            //    var currentOrder = ordersList.FirstOrDefault(o => o.Id == (int)orderId);
            //    currentOrder.CurrentOrderStatus = Status.Done;
            //}
        }
    }
}
