using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YerYok.Mobile.Views.WelcomePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private async void BuSkip_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MasterMainPage());
        }

        private async void BuLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void BuRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterDetailsPage());
        }
    }
}