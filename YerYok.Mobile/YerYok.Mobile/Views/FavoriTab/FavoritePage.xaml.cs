
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YerYok.Mobile.Views.ProductPages;
using YerYok.Shared.Entities;

namespace YerYok.Mobile.Views.FavoriTab
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritePage : ContentView
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
        public ObservableCollection<Product> MyFavorites;

        public FavoritePage()
        {
            InitializeComponent();
            this.BindingContext = this;

            Products = new List<Product>();
            //Products.Add(new Product { Name = "Test Ürünü Falan", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 632, Price = 350 });
            //Products.Add(new Product { Name = "Test Ürünü Falan 2", CoverImg = "ic_tabak", IsFavori = false, OldPrice = 632, Price = 350 });
            //Products.Add(new Product { Name = "Test Ürünü Falan 3", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 632, Price = 350 });
            //Products.Add(new Product { Name = "Test Ürünü Falan 4", CoverImg = "ic_tabak", IsFavori = false, OldPrice = 632, Price = 350 });
        }
        private List<Product> products;

        public List<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        private async void BuItemSelect_Tapped(object sender, System.EventArgs e)
        {
            Grid selectedGrid = (Grid)sender; // seçili grid 
            TapGestureRecognizer buItemSelect = (TapGestureRecognizer)selectedGrid.GestureRecognizers.First(); // seçili gridin ilk algıladığını tapgest e çevir 
            Product selectedItem = (Product)buItemSelect.CommandParameter; // çevrileni product a ekliyoruz
            //await Application.Current.MainPage.DisplayAlert("Seçildi", selectedItem.Name, "Tamam");
            await Navigation.PushAsync(new ProductDetailPage(selectedItem));
        }
    }
}