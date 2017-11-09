using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QqInfoProject.Enums;
using Xamarin.Forms;

namespace QqInfoProject.Model
{
    public class StTask
    {
        public int Id { get; set; }
        public int StageId { get; set; }
        public string Name { get; set; }
        public bool HasIngredients { get; set; } = false;

        public int NumberOfPieces { get; set; }

        public Status TaskStatus { get; set; }
        public Color TaskColor { get; set; }
    }
}
