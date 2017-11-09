using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QqInfoProject.Enums;
using QqInfoProject.Model;
using QqInfoProject.View;

namespace QqInfoProject
{
    public class FakeInfo
    {
        #region listele de obiecte de interes

        readonly List<User> usersList = new List<User>();
        readonly List<Order> ordersList = new List<Order>();
        readonly List<Stage> stagesList = new List<Stage>();
        List<StTask> tasksList = new List<StTask>();
        readonly List<Ingredient> ingredientsList = new List<Ingredient>();
        #endregion

        #region singleton 
        static readonly object syncObject = new object();
        private static FakeInfo instance;

        private FakeInfo()
        {
            PopulateUsersList();
            PopulateOrdersList();
            PopulateStagesList();
            PopulateStTasksList();
            PopulateIngredientsList();
        }

        public static FakeInfo Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (instance == null)
                    {
                        instance = new FakeInfo();
                    }
                }
                return instance;
            }
        }
        #endregion

        #region private methods - introduce raw information

        void PopulateUsersList()
        {
            usersList.Add(new User() { Id = 1, Name = "Ionel", IsWorkingToday = true, Photo = "cook.jpg" });
            usersList.Add(new User() { Id = 2, Name = "Gigel", IsWorkingToday = true, Photo = "cook2.jpg" });
            usersList.Add(new User() { Id = 3, Name = "Lili", IsWorkingToday = true, Photo = "cook3.jpg" });
            usersList.Add(new User() { Id = 4, Name = "Viorel", IsWorkingToday = false, Photo = "cook1.jpg" });
        }

        void PopulateOrdersList()
        {
            ordersList.Add(new Order() { Id = 11, UserId = 1, Name = "Comanda speciala Ion", CurrentOrderStatus = Status.Waiting });
            ordersList.Add(new Order() { Id = 12, UserId = 1, Name = "Comanda Prajitura SA", CurrentOrderStatus = Status.Waiting });
            ordersList.Add(new Order() { Id = 13, UserId = 1, Name = "Comanda sat Duna", CurrentOrderStatus = Status.Waiting });

            ordersList.Add(new Order() { Id = 11, UserId = 2, Name = "Comanda speciala Pop", CurrentOrderStatus = Status.Waiting });
            ordersList.Add(new Order() { Id = 12, UserId = 2, Name = "Comanda Cornulet SA", CurrentOrderStatus = Status.Waiting });
            ordersList.Add(new Order() { Id = 13, UserId = 2, Name = "Comanda sat Tara", CurrentOrderStatus = Status.Waiting });

            ordersList.Add(new Order() { Id = 11, UserId = 3, Name = "Comanda speciala Nin", CurrentOrderStatus = Status.Waiting });
            ordersList.Add(new Order() { Id = 12, UserId = 3, Name = "Comanda Piscot SA", CurrentOrderStatus = Status.Waiting });
            ordersList.Add(new Order() { Id = 13, UserId = 3, Name = "Comanda sat Vala", CurrentOrderStatus = Status.Waiting });

        }

        void PopulateStagesList()
        {
            stagesList.Add(new Stage() { Id = 111, OrderId = 11, Name = "Preparare aluat", Equipment = "Malaxor"});
            stagesList.Add(new Stage() { Id = 112, OrderId = 11, Name = "Dospire", Equipment = "Dospitor"});
            stagesList.Add(new Stage() { Id = 113, OrderId = 11, Name = "Portionare", Equipment = "Portionator" });
            stagesList.Add(new Stage() { Id = 114, OrderId = 11, Name = "Coacere", Equipment = "Cuptor" });

            stagesList.Add(new Stage() { Id = 121, OrderId = 12, Name = "Preparare aluat", Equipment = "Malaxor" });
            stagesList.Add(new Stage() { Id = 122, OrderId = 12, Name = "Portionare", Equipment = "Portionator" });
            stagesList.Add(new Stage() { Id = 123, OrderId = 12, Name = "Coacere", Equipment = "Cuptor" });
            stagesList.Add(new Stage() { Id = 124, OrderId = 12, Name = "Preparare crema", Equipment = "Mixer" });
            stagesList.Add(new Stage() { Id = 125, OrderId = 12, Name = "Asamblare", Equipment = "Linie asamblare" });

            stagesList.Add(new Stage() { Id = 131, OrderId = 13, Name = "Preparare aluat", Equipment = "Malaxor" });
            stagesList.Add(new Stage() { Id = 132, OrderId = 13, Name = "Dospire", Equipment = "Dospitor" });
            stagesList.Add(new Stage() { Id = 133, OrderId = 13, Name = "Portionare", Equipment = "Portionator" });
            stagesList.Add(new Stage() { Id = 134, OrderId = 13, Name = "Condimentare", Equipment = "Linie asamblare" });
            stagesList.Add(new Stage() { Id = 135, OrderId = 13, Name = "Coacere", Equipment = "Cuptor" });
        }

        void PopulateStTasksList()
        {
            tasksList.Add(new StTask() { Id = 1111, StageId = 111, Name = "Preparare 20 kg aluat", HasIngredients = true });
            tasksList.Add(new StTask() { Id = 1122, StageId = 112, Name = "Dospire 20 kg aluat" });
            tasksList.Add(new StTask() { Id = 1133, StageId = 113, Name = "Paine alba, 20 buc" });
            tasksList.Add(new StTask() { Id = 1134, StageId = 113, Name = "Chifle albe, 50 buc" });
            tasksList.Add(new StTask() { Id = 1145, StageId = 114, Name = "Paine alba, 20 buc" });
            tasksList.Add(new StTask() { Id = 1146, StageId = 114, Name = "Chifle albe, 50 buc" });

            tasksList.Add(new StTask() { Id = 1211, StageId = 121, Name = "Preparare 16 kg aluat", HasIngredients = true });
            tasksList.Add(new StTask() { Id = 1222, StageId = 122, Name = "Portionare 16 kg aluat" });
            tasksList.Add(new StTask() { Id = 1233, StageId = 123, Name = "Coacere 16 kg aluat" });
            tasksList.Add(new StTask() { Id = 1244, StageId = 124, Name = "Creama Vanilie", HasIngredients = true });
            tasksList.Add(new StTask() { Id = 1245, StageId = 124, Name = "Crema Rom", HasIngredients = true });
            tasksList.Add(new StTask() { Id = 1246, StageId = 124, Name = "Crema Lamaie", HasIngredients = true });
            tasksList.Add(new StTask() { Id = 1257, StageId = 125, Name = "Fursecuri Crema Vanilie, 5 kg" });
            tasksList.Add(new StTask() { Id = 1258, StageId = 125, Name = "Fursecuri Crema Rom, 7 kg" });
            tasksList.Add(new StTask() { Id = 1259, StageId = 125, Name = "Fursecuri Crema Lamaie, 4 kg" });

            tasksList.Add(new StTask() { Id = 1311, StageId = 131, Name = "Preparare 19 kg aluat", HasIngredients = true });
            tasksList.Add(new StTask() { Id = 1322, StageId = 132, Name = "Dospire 20 kg aluat" });
            tasksList.Add(new StTask() { Id = 1333, StageId = 133, Name = "Saleuri chimen, 7 kg" });
            tasksList.Add(new StTask() { Id = 1334, StageId = 133, Name = "Saleuri mac, 12 kg" });
            tasksList.Add(new StTask() { Id = 1345, StageId = 134, Name = "Adaugare chimen", HasIngredients = true });
            tasksList.Add(new StTask() { Id = 1346, StageId = 134, Name = "Adaugare mac", HasIngredients = true });
            tasksList.Add(new StTask() { Id = 1357, StageId = 135, Name = "Saleuri chimen, 7 kg" });
            tasksList.Add(new StTask() { Id = 1358, StageId = 135, Name = "Saleuri mac, 12 kg" });

            foreach (var stTask in tasksList)
            {
                stTask.TaskStatus = Status.Waiting;
            }
        }

        void PopulateIngredientsList()
        {
            ingredientsList.Add(new Ingredient() { Id = 11111, TaskId = 1111, Name = "Făină", Grammage = "16 kg", HasDetails = true});
            ingredientsList.Add(new Ingredient() { Id = 11112, TaskId = 1111, Name = "Apa", Grammage = "5 L"});
            ingredientsList.Add(new Ingredient() { Id = 11113, TaskId = 1111, Name = "Drojdie", Grammage = "1 kg"});

            ingredientsList.Add(new Ingredient() { Id = 12114, TaskId = 1211, Name = "Făină", Grammage = "12 kg", HasDetails = true });
            ingredientsList.Add(new Ingredient() { Id = 12115, TaskId = 1211, Name = "Apa", Grammage = "1 L" });
            ingredientsList.Add(new Ingredient() { Id = 12116, TaskId = 1211, Name = "Oua", Grammage = "20 buc" });
            ingredientsList.Add(new Ingredient() { Id = 12117, TaskId = 1211, Name = "Lapte", Grammage = "3 L" });

            ingredientsList.Add(new Ingredient() { Id = 13118, TaskId = 1311, Name = "Făină", Grammage = "13 kg", HasDetails = true });
            ingredientsList.Add(new Ingredient() { Id = 13119, TaskId = 1311, Name = "Apa", Grammage = "3 L" });
            ingredientsList.Add(new Ingredient() { Id = 131110, TaskId = 1311, Name = "Lapte", Grammage = "4 L" });
            ingredientsList.Add(new Ingredient() { Id = 131111, TaskId = 1311, Name = "Drojdie", Grammage = "1 kg" });

            ingredientsList.Add(new Ingredient() { Id = 124412, TaskId = 1244, Name = "Praf crema vanilie", Grammage = "2 kg", HasDetails = true });
            ingredientsList.Add(new Ingredient() { Id = 124413, TaskId = 1244, Name = "Lapte", Grammage = "3 L", HasDetails = true});

            ingredientsList.Add(new Ingredient() { Id = 124414, TaskId = 1245, Name = "Praf crema rom", Grammage = "2 kg", HasDetails = true });
            ingredientsList.Add(new Ingredient() { Id = 124415, TaskId = 1245, Name = "Lapte", Grammage = "3 L", HasDetails = true});

            ingredientsList.Add(new Ingredient() { Id = 124416, TaskId = 1246, Name = "Praf crema lamaie", Grammage = "2 kg", HasDetails = true });
            ingredientsList.Add(new Ingredient() { Id = 124417, TaskId = 1244, Name = "Lapte", Grammage = "3 L", HasDetails = true});
        }
        #endregion

        #region public methods
        public List<User> ReturnUsersList()
        {
            return usersList;
        }

        public List<Order> ReturnOrdersListForUser(int userId)
        {
            return ordersList.Where(o => o.UserId == userId).ToList();
        }

        public List<Stage> ReturnStagesForOrder(int orderId)
        {
            return stagesList.Where(s => s.OrderId == orderId).ToList();
        }

        public List<StTask> ReturnTasksForStage(int stageId)
        {
            return tasksList.Where(t => t.StageId == stageId).ToList();
        }

        public List<Ingredient> ReturnIngredientsForTask(int taskId)
        {
            return ingredientsList.Where(i => i.TaskId == taskId).ToList();
        }



        public Stage ReturnStageById(int stageId)
        {
            return stagesList.FirstOrDefault(s => s.Id == stageId);
        }

        public StTask ReturnTaskById(int taskId)
        {
            return tasksList.FirstOrDefault(t => t.Id == taskId);
        }

        public static List<IngredientBatch> ReturnIngredientBatchForIngredient(int ingredientId)
        {
            var ingredientBatch = new List<IngredientBatch>
            {
                new IngredientBatch {Id = 1, Name = "Dobrogea 10kg", Batch = "025", ExpirationDate = "08.2017"},
                new IngredientBatch {Id = 2, Name = "Dobrogea 10kg", Batch = "043", ExpirationDate = "11.2017"},
                new IngredientBatch {Id = 3, Name = "Titan 8kg", Batch = "138", ExpirationDate = "02.2018"},
                new IngredientBatch {Id = 4, Name = "Titan 8kg", Batch = "187", ExpirationDate = "10.2018"},
                new IngredientBatch {Id = 5, Name = "Titan 12kg", Batch = "124", ExpirationDate = "12.2018"}
            };

            return ingredientBatch;
        }


        public Action<int> ModifyStatusButtonAction;
        public void ModifyTaskStatus(int taskId, Status newStatus)
        {
            var nTask = tasksList.FirstOrDefault(t => t.Id == taskId);
            if (nTask != null)
            {
                tasksList.Remove(nTask);
                nTask.TaskStatus = newStatus;
                tasksList.Add(nTask);

                ModifyStatusButtonAction(taskId);
            }
        }

        public Order ReturnOrderByTask(int taskId)
        {
            var stageId = tasksList.FirstOrDefault(t => t.Id == taskId).StageId;
            var orderId = stagesList.FirstOrDefault(s => s.Id == stageId).OrderId;

            return ordersList.FirstOrDefault(o => o.Id == orderId);
        }
        #endregion
    }
}
