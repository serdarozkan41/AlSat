using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YerYok.Shared.Entities;

namespace YerYok.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SamplePagexaml : ContentPage
    {
        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }
        public SamplePagexaml()
        {
            InitializeComponent();
            this.BindingContext = this;
            MyFavorites = new List<Product>();
            MyFavorites.Add(new Product { Name = "Test Ürünü Falan", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 682, Price = 350 });
            MyFavorites.Add(new Product { Name = "Test Ürünü Falan", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 682, Price = 350 });
        }
        private List<Product> myFavorites;

        public List<Product> MyFavorites
        {
            get { return myFavorites; }
            set
            {
                myFavorites = value;
                OnPropertyChanged();
            }
        }

        private async void BuTeklif_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GiveOfferPage());
        }
    }
}