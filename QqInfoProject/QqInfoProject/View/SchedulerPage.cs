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
    public class SchedulerPage : ContentPage
    {
        public Order Order;

        Dictionary<int, TaskDetailsPage> taskPagesDictionary = new Dictionary<int, TaskDetailsPage>();

        public SchedulerPage(Order order)
        {
            Title = order.Name;
            Order = order;

            #region stages and tasks for current order
            var fakeInfo = FakeInfo.Instance;
            var stages = fakeInfo.ReturnStagesForOrder(order.Id);
            var tasksNumberForThisOrder = 0;

            foreach (var stage in stages)
            {
                var currentTasks = fakeInfo.ReturnTasksForStage(stage.Id);
                for (var i = 0; i < currentTasks.Count; i++)
                {
                    tasksNumberForThisOrder++;
                }
            }
            #endregion

            #region grid creation + columns and rows def
            var grid = new Grid() { BackgroundColor = QqinfoAppSettings.GrayColor, RowSpacing = 2, ColumnSpacing = 2 };
            foreach (var s in stages)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            grid.RowDefinitions.Add(new RowDefinition());
            for (var i = 0; i < tasksNumberForThisOrder; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            #endregion

            #region color each entry
            for (var i = 0; i < tasksNumberForThisOrder + 1; i++)
            {
                for (var j = 0; j < stages.Count; j++)
                {
                    grid.Children.Add(new StackLayout() { BackgroundColor = QqinfoAppSettings.WhiteColor, HeightRequest = 75 }, j, i);
                }
            }
            #endregion

            #region create header grid
            for (var i = 0; i < stages.Count; i++)
                grid.Children.Add(new Label()
                {
                    Text = stages[i].Name,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = QqinfoAppSettings.TextFontSize,
                    BackgroundColor = QqinfoAppSettings.WhiteColor,
                    TextColor = QqinfoAppSettings.BlueColor
                }, i, 0);
            #endregion

            #region set colors for tasks
            foreach (var s in stages)
            {
                var stageTasks = fakeInfo.ReturnTasksForStage(s.Id);
                for (var i = 0; i < stageTasks.Count; i++)
                {
                    stageTasks[i].TaskColor = QqinfoAppSettings.TasksColor[i];
                }
            }
            #endregion

            #region populate grid with tasks
            List<Button> buttonsList = new List<Button>();

            var count = 0;
            for (var i = 0; i < stages.Count; i++)
            {
                var currentsTasks = fakeInfo.ReturnTasksForStage(stages[i].Id);
                for (var j = 0; j < currentsTasks.Count; j++)
                {
                    var button = new Button()
                    {
                        //Text = currentsTasks[j].TaskStatus.ToString().Substring(0,1) + " - " + currentsTasks[j].Name,
                        Text = FontIoniconsUsage.ReturnFontsForStatus(currentsTasks[j].TaskStatus) + " - " + currentsTasks[j].Name,
                        BackgroundColor = currentsTasks[j].TaskColor,
                        TextColor = QqinfoAppSettings.BlueColor,
                        BorderColor = QqinfoAppSettings.BlueColor,
                        BorderWidth = 1,
                        FontSize = 15,
                        FontFamily="Ionicons",
                        CommandParameter = currentsTasks[j].Id
                    };
                    buttonsList.Add(button);

                    var j1 = j;
                    var i1 = i;
                    button.Clicked += (s, e) =>
                    {
                        TaskDetailsPage currentTaskDetailPage;

                        if (taskPagesDictionary.ContainsKey(currentsTasks[j1].Id))
                        {
                            currentTaskDetailPage = taskPagesDictionary[currentsTasks[j1].Id];
                        }
                        else
                        {
                            currentTaskDetailPage = new TaskDetailsPage(currentsTasks[j1], stages[i1].Id);
                            taskPagesDictionary.Add(currentsTasks[j1].Id, currentTaskDetailPage);
                        }

                        Navigation.PushAsync(currentTaskDetailPage);
                    };
                    grid.Children.Add(button, i, i + j + 1 + count);
                }
                count += currentsTasks.Count - 1;
            }
            #endregion

            fakeInfo.ModifyStatusButtonAction += (taskId) =>
            {
                var btn = buttonsList.FirstOrDefault(b => (int)b.CommandParameter == taskId);
                if (btn != null)
                {
                    var task = fakeInfo.ReturnTaskById(taskId);
                    btn.Text = FontIoniconsUsage.ReturnFontsForStatus(task.TaskStatus) + " - " + task.Name;
                }
            };

            Content = new ScrollView() { Content = grid, Padding = new Thickness(3, 4, 3, 0), BackgroundColor = QqinfoAppSettings.GrayColor };
        }
    }

    public class SchedulerTabbedPage : TabbedPage
    {
        public SchedulerTabbedPage(List<Order> orders, int orderId, User user)
        {
            Title = user.Name;
            foreach (var order in orders)
            {
                Children.Add(new SchedulerPage(order));
            }

            var currentOrder = orders.FirstOrDefault(o => o.Id == orderId);
            SelectedItem = Children.FirstOrDefault(s => (s as SchedulerPage)?.Order == currentOrder);
        }
    }
}
