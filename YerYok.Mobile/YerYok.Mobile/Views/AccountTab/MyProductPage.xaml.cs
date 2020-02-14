using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YerYok.Mobile.Views.ProductPages;
using YerYok.Shared.Entities;

namespace YerYok.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProductPage : ContentPage
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
        public MyProductPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            MyProducts = new List<Product>();
            MyProducts.Add(new Product { Name = "Test Ürünü Falan", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 682, Price = 350 });
            MyProducts.Add(new Product { Name = "Test Deneme Falan2", CoverImg = "ic_tabak", IsFavori = false, OldPrice = 672, Price = 350 });
            MyProducts.Add(new Product { Name = "Test Ürünü Falan3", CoverImg = "ic_tabak", IsFavori = false, OldPrice = 672, Price = 350 });
            MyProducts.Add(new Product { Name = "Test Deneme Falan4", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 632, Price = 350 });
        }     

        private List<Product> myProducts;

        public List<Product> MyProducts
        {
            get { return myProducts; }
            set
            {
                myProducts = value;
                OnPropertyChanged();
            }
        }

        private async void BuItemSelect_Tapped(object sender, System.EventArgs e)
        {
            Grid selectedGrid = (Grid)sender;
            TapGestureRecognizer buItemSelect = (TapGestureRecognizer)selectedGrid.GestureRecognizers.First();
            Product selectedItem = (Product)buItemSelect.CommandParameter;
            //await Application.Current.MainPage.DisplayAlert("Seçildi", selectedItem.Name, "Tamam");
            await Navigation.PushAsync(new ProductDetailPage(selectedItem));
        }



    }
}