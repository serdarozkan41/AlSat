using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace YerYok.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMainPage : ContentPage
    {
        private int _selectedViewModelIndex = 0;

        public int SelectedViewModelIndex
        {
            get { return _selectedViewModelIndex; }
            set { _selectedViewModelIndex = value;
                switch (_selectedViewModelIndex)
                {
                    case 0:
                        HNavBar.IsVisible = false;
                        MNavBar.IsVisible = true;
                        break;
                    case 1:
                        HNavBar.IsVisible = true;
                        MNavBar.IsVisible = false;
                        HNavBar.NewTitle = "Favorilerim";
                        break;
                    case 2:
                        HNavBar.IsVisible = true;
                        MNavBar.IsVisible = false;
                        HNavBar.NewTitle = "Bildirimlerim";
                        break;
                    case 3:
                        HNavBar.IsVisible = true;
                        MNavBar.IsVisible = false;
                        HNavBar.NewTitle = "Profilim";
                        break;
                }
                OnPropertyChanged();
            }
        }

        public MasterMainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeArea = On<iOS>().SafeAreaInsets();
            BottomSafeAreaDefinition.Height = safeArea.Bottom;
            Padding = 0;
        }

        private async void TabButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdvertTab.AddAdvertPage());
        }
    }
}