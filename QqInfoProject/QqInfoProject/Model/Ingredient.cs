using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QqInfoProject.Model
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Grammage { get; set; }
        public bool HasDetails { get; set; }

        // for interface, to be optimised
        public Color BackgroundColor { get; set; } = QqinfoAppSettings.WhiteColor;
        public Color TextColor { get; set; } = QqinfoAppSettings.BlueColor;
    }
}
