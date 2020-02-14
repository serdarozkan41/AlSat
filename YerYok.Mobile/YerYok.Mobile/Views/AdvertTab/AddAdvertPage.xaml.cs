using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YerYok.Mobile.Views.AdvertTab
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAdvertPage : ContentPage
    {
        public AddAdvertPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private async void BuAddPhoto_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPhotoPage());
        }
    }
}