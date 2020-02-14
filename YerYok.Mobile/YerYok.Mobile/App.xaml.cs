using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YerYok.Mobile.SettingService;
using YerYok.Mobile.Views;
using YerYok.Mobile.Views.MainTab;

namespace YerYok.Mobile
{
   
   
    public partial class App : Application
    {
        public ISettingsService SettingsService;
        public App()
        {
            InitializeComponent();
            DependencyService.Register<SettingsService>();
            SettingsService = DependencyService.Get<ISettingsService>();

            //if (SettingsService.GetValueOrDefault("IsLogin", false))
            //{
            //    using (HttpClient client = new HttpClient())
            //    {
            //        MainPage = new NavigationPage(new MasterMainPage());
            //    }
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new LoginPage());
            //}


            MainPage = new NavigationPage(new Views.WelcomePages.WelcomePage());
            //MainPage = new NavigationPage(new SellerProfilePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
