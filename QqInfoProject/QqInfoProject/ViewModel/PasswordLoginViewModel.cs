using QqInfoProject.Enums;
using Xamarin.Forms;

namespace QqInfoProject.ViewModel
{
    public class PasswordLoginViewModel
    {
        public Color BackgroundColor { get; set; } = QqinfoAppSettings.WhiteColor;
        public Color TextColor { get; set; } = QqinfoAppSettings.BlueColor;
        public Color ButtonBackgroundColor { get; set; } = QqinfoAppSettings.GrayColor;

        public string UserImageSource { get; set; }

        //public string t { get; set; } = "\uf359";
    }

    public class FontIoniconsUsage
    {
        public static string ReturnFontsForStatus(Status status)
        {
            switch (status)
            {
                case Status.Waiting:
                    return "\uf403";
                case Status.Progress:
                    return "\uf362";
                case Status.Done:
                    return "\uf120";
                case Status.Canceled:
                    return "\uf406";
                default:
                    return "\uf400";
            }
        }
    }
}