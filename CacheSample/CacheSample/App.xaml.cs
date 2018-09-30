using System;
using MonkeyCache.FileStore;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CacheSample
{
    public partial class App : Application
    {
        public static Service apiServices = new Service();
        public App()
        {
            InitializeComponent();

            Barrel.ApplicationId = "CacheSample" + DateTime.Now;

            MainPage = new View.CurrencyPage();
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
