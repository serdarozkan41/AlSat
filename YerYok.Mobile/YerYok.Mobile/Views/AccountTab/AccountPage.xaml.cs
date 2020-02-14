using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YerYok.Mobile.Views.ProductPages;
using YerYok.Mobile.Views.WelcomePages;
using YerYok.Shared.Entities;

namespace YerYok.Mobile.Views.AccountTab
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentView
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
        private int _selectedViewModelIndex = 0;

        public int SelectedViewModelIndex
        {
            get { return _selectedViewModelIndex; }
            set
            {
                _selectedViewModelIndex = value;
                OnPropertyChanged();
            }
        }
        public AccountPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            Products = new  List<Product>();

            //Products.Add(new Product { Name = "Test Ürünü Falan", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 682, Price = 350 });
            //Products.Add(new Product { Name = "Test Ürünü Falan", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 682, Price = 350 });
            //Products.Add(new Product { Name = "Test Ürünü Falan", CoverImg = "ic_mavitabak", IsFavori = true, OldPrice = 682, Price = 350 });
            //Products.Add(new Product { Name = "Test Ürünü Falan", CoverImg = "ic_mavitabak", IsFavori = true, OldPrice = 682, Price = 350 });
            //Products.Add(new Product { Name = "Test Ürünü Falan", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 682, Price = 350 });

            SellingProducts = new List<Product>();
            //SellingProducts.Add(new Product { Name = "Test Ürünü Falan", CoverImg = "ic_tabak", IsFavori = false, OldPrice = 682, Price = 350 });
            //SellingProducts.Add(new Product { Name = "Test Ürünü Falan", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 682, Price = 350 });
            //SellingProducts.Add(new Product { Name = "Test Ürünü Falan", CoverImg = "ic_mavitabak", IsFavori = true, OldPrice = 682, Price = 350 });
            //SellingProducts.Add(new Product { Name = "Test Ürünü Falan", CoverImg = "ic_mavitabak", IsFavori = true, OldPrice = 682, Price = 350 });
            //SellingProducts.Add(new Product { Name = "Test Ürünü Falan", CoverImg = "ic_tabak", IsFavori = true, OldPrice = 682, Price = 350 });

            Menus = new List<Shared.Entities.Menu>();
            Menus.Add(new Shared.Entities.Menu { Icon= "ic_circle",CategoryName="Ürünlerime Git",MenuStatus= Shared.Enums.MenuStatus.URUNLER});
            Menus.Add(new Shared.Entities.Menu { Icon = "ic_teklif", CategoryName = "Tekliflerim",MenuStatus= Shared.Enums.MenuStatus.TEKLİFLER });
            Menus.Add(new Shared.Entities.Menu { Icon = "ic_kupon", CategoryName = "Kuponlarım",MenuStatus= Shared.Enums.MenuStatus.KUPONLAR});
            Menus.Add(new Shared.Entities.Menu { Icon = "ic_songez", CategoryName = "Son Gezdiklerim",MenuStatus= Shared.Enums.MenuStatus.SONGEZİLEN});
            Menus.Add(new Shared.Entities.Menu { Icon = "ic_ayarlar", CategoryName = "Ayarlarım",MenuStatus= Shared.Enums.MenuStatus.AYARLAR});
            Menus.Add(new Shared.Entities.Menu { Icon = "ic_destek", CategoryName = "Destek",MenuStatus= Shared.Enums.MenuStatus.DESTEK});
            Menus.Add(new Shared.Entities.Menu { Icon = "ic_cikis", CategoryName = "Çıkış Yap",MenuStatus= Shared.Enums.MenuStatus.CİKİS});

            LvMenu.ItemsSource = menus;

        }
        private List<Product> products;

        public List<Product> Products
        {
            get { return products; }
            set {
                products = value;
                OnPropertyChanged();
            }
        }

        private List<Shared.Entities.Menu> menus;

        public List<Shared.Entities.Menu> Menus
        {
            get { return menus; }
            set { 
                menus = value;
                OnPropertyChanged();
            }
        }

        private List<Product> sellingProducts;

        public List<Product> SellingProducts
        {
            get { return sellingProducts; }
            set
            {
                sellingProducts = value;
                OnPropertyChanged();
            }
        }

        //private async void BuProduct_Tapped(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new MyProductPage());
        //}

        //private async void BuOffer_Tapped(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new MyOffersPage());
        //}

        private async void BuCoupon_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyCouponPage());
        }

        private async void BuSettigs_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MySettingsPage());
        }

        private async void BuSupport_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SupportPage());
        }

        private async void BuPen_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfilePage());
        }


        private async void BuProductBut_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyProductPage());
        }

        private async void BuPerson_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SellerProfilePage());
        }

        private async void BuFollow_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SellerProfilePage());
        }
        private async void BuItemSelect_Tapped(object sender, System.EventArgs e)
        {
            Grid selectedGrid = (Grid)sender; // seçili grid 
            TapGestureRecognizer buItemSelect = (TapGestureRecognizer)selectedGrid.GestureRecognizers.First(); // seçili gridin ilk algıladığını tapgest e çevir 
            Product selectedItem = (Product)buItemSelect.CommandParameter; // çevrileni product a ekliyoruz
            //await Application.Current.MainPage.DisplayAlert("Seçildi", selectedItem.Name, "Tamam");
            await Navigation.PushAsync(new ProductDetailPage(selectedItem));
        }

        private async void LvMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Shared.Entities.Menu;
            if(menu.MenuStatus== Shared.Enums.MenuStatus.URUNLER)
            {
                await Navigation.PushAsync(new MyProductPage());
            }
            if (menu.MenuStatus == Shared.Enums.MenuStatus.TEKLİFLER)
            {
                await Navigation.PushAsync(new MyOffersPage());
            }
            if (menu.MenuStatus == Shared.Enums.MenuStatus.KUPONLAR)
            {
                await Navigation.PushAsync(new MyCouponPage());
            }
          
            if (menu.MenuStatus == Shared.Enums.MenuStatus.AYARLAR)
            {
                await Navigation.PushAsync(new MySettingsPage());
            }
            if (menu.MenuStatus == Shared.Enums.MenuStatus.DESTEK)
            {
                await Navigation.PushAsync(new SupportPage());
            }
            if (menu.MenuStatus == Shared.Enums.MenuStatus.CİKİS)
            {
                await Navigation.PushAsync(new WelcomePage());
            }
        }

       
    }
}