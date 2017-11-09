using System.Collections.Generic;
using Xamarin.Forms;

namespace QqInfoProject
{
    public class QqinfoAppSettings
    {
        public static Color GrayColor { get; set; } = Color.FromRgb(204, 204, 204);
        public static Color BlueColor { get; set; } = Color.FromRgb(0, 51, 102);
        public static Color WhiteColor { get; set; } = Color.FromRgb(255, 255, 255);
        public static Color YellowGreenColor { get; set; } = Color.FromRgb(204, 204, 153);

        //public static List<Color> TasksColor { get; set; } = new List<Color>() { Color.FromRgb(153, 102, 153), Color.FromRgb(204, 255, 51),
        //                                                                         Color.FromRgb(0, 255, 153), Color.FromRgb(204, 204, 153)};

        //public static List<Color> TasksColor { get; set; } = new List<Color>() { Color.FromRgb(51, 153, 255), Color.FromRgb(255, 153, 102), Color.FromRgb(204, 204, 153)};
        public static List<Color> TasksColor { get; set; } = new List<Color>() { Color.FromRgb(204, 204, 204), Color.FromRgb(177, 189, 205), Color.FromRgb(204, 204, 153)};

        public static double TextFontSize { get; set; } = 17;
    }
}