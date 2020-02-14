using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yeryok.Shared.Model.RequestModels;
using Yeryok.Shared.Model.ResponseModels;
using YerYok.Mobile.SettingService;

namespace YerYok.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        HttpClient _client;
        public ISettingsService SettingsService;
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            _client = new HttpClient(); //İstek 
            SettingsService = DependencyService.Get<ISettingsService>();
        }
         
        private async void BuBack_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void buPassword_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RemindMyPasswordPage());
        }             

        private async void BuLogin_Clicked(object sender, EventArgs e)
        {
            IsBusy = true;  // ortada dönen yuvarlak şey olsun diye
            var uri = new Uri(string.Format(Constants.BASEURI + "Auth/Login", string.Empty)); 
            var json = JsonConvert.SerializeObject(new LoginRequestModel   //Girilen email ve password json a çevrilsin
            {
                LoginKey = TBEmail.Text,
                Password = TBPassword.Text
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json"); 
            HttpResponseMessage response = await _client.PostAsync(uri, content); 
            //if (response.StatusCode == HttpStatusCode.Unauthorized)   // yetkisiz ise loginpage e dön
            //{
            //    Application.Current.MainPage = new NavigationPage(new LoginPage()); //login dedeğilk diğeri
            //}
            if (response.IsSuccessStatusCode)  //başarılıysa 
            {
                var cevapText = await response.Content.ReadAsStringAsync();
                LoginResponseModel responseResult = JsonConvert.DeserializeObject<LoginResponseModel>(cevapText);
                await Navigation.PushAsync(new MasterMainPage());
            }
            else
            {
                var cevapText = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Hata", cevapText, "Tamam");
                await Navigation.PopAsync();
            }

            IsBusy = false;

            //await Navigation.PushAsync(new MasterMainPage());
        }
    }
}