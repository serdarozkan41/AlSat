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

namespace YerYok.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemindMyPasswordPage : ContentPage
    {
        HttpClient _client;
        public RemindMyPasswordPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            _client = new HttpClient();
        }

        private async void buBack_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BuConfirm_Clicked(object sender, EventArgs e)
        {
            IsBusy = true;
            var uri = new Uri(string.Format(Constants.BASEURI + "Auth/ForgotPassword", string.Empty));
            var json = JsonConvert.SerializeObject(new ForgotPasswordRequestModel
            {
                Email = TBEmail.Text
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(uri, content);
            await Navigation.PopAsync();
            IsBusy = false;
        }
    }
}