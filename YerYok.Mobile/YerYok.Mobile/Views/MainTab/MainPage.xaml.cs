using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YerYok.Mobile.Views.ProductPages;
using YerYok.Shared.Entities;

namespace YerYok.Mobile.Views.MainTab
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentView
    {
        HttpClient _client;
        private bool isBusy;
        List<Yeryok.Shared.Entities.Slider> Packages = new List<Yeryok.Shared.Entities.Slider>();

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            
            _client = new HttpClient();

            initSlider();

            Products = new List<Product>();
            Products.Add(new Product { Name = "Test Ürünü Falan", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 632, Price = 350 });
            Products.Add(new Product { Name = "Test Ürünü Falan 2", CoverImg = "ic_tabak", IsFavori = false, OldPrice = 632, Price = 350 });
            Products.Add(new Product { Name = "Test Ürünü Falan 3", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 632, Price = 350 });
            Products.Add(new Product { Name = "Test Ürünü Falan 4", CoverImg = "ic_tabak", IsFavori = false, OldPrice = 632, Price = 350 });

            ProductContinues = new List<Product>();
            ProductContinues.Add(new Product { Name = "Deneme Ürünü", CoverImg = "ic_mavitabak", IsFavori = true, OldPrice = 680, Price = 380 });
            ProductContinues.Add(new Product { Name = "Deneme Ürünü 2", CoverImg = "ic_mavitabak", IsFavori = false, OldPrice = 680, Price = 380 });
            ProductContinues.Add(new Product { Name = "Deneme Ürünü 3", CoverImg = "ic_mavitabak", IsFavori = false, OldPrice = 680, Price = 380 });
            ProductContinues.Add(new Product { Name = "Deneme Ürünü 4", CoverImg = "ic_mavitabak", IsFavori = true, OldPrice = 680, Price = 380 });

            Sellers = new List<Seller>();
            Sellers.Add(new Seller { ProfilePhoto = "seller", Name = "Higashi Mako" });
            Sellers.Add(new Seller { ProfilePhoto = "sellerb", Name = "Sukhbirpal Dhalan" });
            Sellers.Add(new Seller { ProfilePhoto = "sellera", Name = "Chineze Afamefuna" });
            Sellers.Add(new Seller { ProfilePhoto = "sellerc", Name = "Dai Jiang" });

        }

        private async void initSlider()
        {
            IsBusy = true;
            var uri = new Uri(string.Format(Constants.BASEURI + "Slider/GetSliders", string.Empty));
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Sliders =
            }
        }
  

        private List<Seller> sellers;

        public List<Seller> Sellers
        {
            get { return sellers; }
            set { 
                sellers = value;
                OnPropertyChanged();
            }
        }



        private List<Product> products;

        public List<Product> Products
        {
            get { return products; }
            set { products = value;
                OnPropertyChanged();
            }
        }

        private List<Product> productContinues;

        public List<Product> ProductContinues
        {
            get { return productContinues; }
            set
            {
                productContinues = value;
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

        private async void BuSel_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SellerProfilePage());
        }
    }
}