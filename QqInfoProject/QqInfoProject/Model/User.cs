using Xamarin.Forms;

namespace QqInfoProject.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }

        public bool IsWorkingToday { get; set; }
        public string Availability => IsWorkingToday ? "Disponibil" : "Indisponibil";
        public Color TextColor => IsWorkingToday ? QqinfoAppSettings.BlueColor : QqinfoAppSettings.GrayColor;
    }
}