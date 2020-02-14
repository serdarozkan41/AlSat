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
    public partial class SellerProfilePage : ContentPage
    {
        private int isBusy;

        public int IsBusy
        {
            get { return isBusy; }
            set { 
                isBusy = value;
                OnPropertyChanged();
                
            }
        }

        public SellerProfilePage()
        {
            InitializeComponent();
            this.BindingContext = this;
            SellerProducts = new List<Product>();
            SellerProducts.Add(new Product { Name = "Test Ürünü", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 900, Price = 480 });
            SellerProducts.Add(new Product { Name = "Test Ürünü", CoverImg = "ic_mavitabak", IsFavori = false, OldPrice = 900, Price = 580 });
            SellerProducts.Add(new Product { Name = "Test Ürünü", CoverImg = "ic_tabak", IsFavori = false, OldPrice = 800, Price = 480 });
            SellerProducts.Add(new Product { Name = "Test Ürünü", CoverImg = "ic_mavitabak", IsFavori = true, OldPrice = 900, Price = 480 });

        }
        private List<Product> sellerProducts;

        public List<Product>  SellerProducts
        {
            get { return sellerProducts; }
            set { 
                sellerProducts = value;
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