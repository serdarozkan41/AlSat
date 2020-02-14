using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yeryok.Shared.Model.RequestModels;
using YerYok.Mobile.Views.WelcomePages;

namespace YerYok.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterDetailsPage : ContentPage
    {
        HttpClient _client;
        public RegisterDetailsPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            _client = new HttpClient();
        }

        private async void BuRegister_Clicked(object sender, EventArgs e)
        {
            IsBusy = true;
            if (CBSözleşme.IsChecked)
            {
                var uri = new Uri(string.Format(Constants.BASEURI + "Auth/Register", string.Empty));
                var json = JsonConvert.SerializeObject(new RegisterRequestModel
                {
                    Email = TBEmail.Text,
                    Name = TBAd.Text,
                    SurName = TBSoyad.Text,
                    PhoneNumber = TBPhoneNumber.Text,                   
                    Password = TBSifre.Text,
                    CheckContract = CBHaber.IsChecked,
                    CheckNotification=CBSözleşme.IsChecked                  
                });
                /////post et
                var content = new StringContent(json, Encoding.UTF8, "application/json"); 
                HttpResponseMessage response = await _client.PostAsync(uri, content);
                await Navigation.PushAsync(new WelcomePage());
            }
            else
            {
                //seçmen laızm secçemenden olma
                await DisplayAlert("Hata","Lütfen Eksik Bilgi Girmeyiniz", "Tamam");
            }
            IsBusy = false;
        }

        private async void buLogin_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
      
    }
}