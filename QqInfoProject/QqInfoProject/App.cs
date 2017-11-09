using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QqInfoProject.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace QqInfoProject
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new UserLoginPage()) { BarBackgroundColor = QqinfoAppSettings.BlueColor, BarTextColor = QqinfoAppSettings.WhiteColor };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
