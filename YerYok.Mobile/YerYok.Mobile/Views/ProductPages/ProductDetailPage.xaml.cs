using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YerYok.Shared.Entities;

namespace YerYok.Mobile.Views.ProductPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        private Product product;

        public Product Product
        {
            get { return product; }
            set { product = value;
                OnPropertyChanged();
            }
        }


        public ProductDetailPage(Product _product)
        {
            InitializeComponent();
            this.BindingContext = this;            
            Product = _product;

            SimilarProducts = new List<Product>();
            SimilarProducts.Add(new Product { Name = "Test", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 900, Price = 600 });
            SimilarProducts.Add(new Product { Name = "Test", CoverImg = "ic_mavitabak", IsFavori = true, OldPrice = 900, Price = 600 });
            SimilarProducts.Add(new Product { Name = "Test", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 900, Price = 600 });
            SimilarProducts.Add(new Product { Name = "Test", CoverImg = "ic_tabak", IsFavori = false, OldPrice = 900, Price = 600 });
            SimilarProducts.Add(new Product { Name = "Test", CoverImg = "ic_mavitabak", IsFavori = true, OldPrice = 900, Price = 600 });
            SimilarProducts.Add(new Product { Name = "Test", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 900, Price = 600 });
            SimilarProducts.Add(new Product { Name = "Test", CoverImg = "ic_mavitabak", IsFavori = true, OldPrice = 900, Price = 600 });
            SimilarProducts.Add(new Product { Name = "Test", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 900, Price = 600 });

        }

        private async void BuTeklif_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GiveOfferPage());
        }

        private async void BuBack_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private List<Product> similarProducts;

        public List<Product> SimilarProducts
        {
            get { return similarProducts; }
            set
            {
                similarProducts = value;
                OnPropertyChanged();
            }
        }

        private async void BuRes_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SellerProfilePage());
        }

        private async void BuSeller_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SellerProfilePage());
        }

       
    }
}