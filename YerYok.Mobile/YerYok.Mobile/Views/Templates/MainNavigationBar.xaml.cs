using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YerYok.Mobile.Views.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainNavigationBar : Grid
    {
        public MainNavigationBar()
        {
            InitializeComponent();
        }

        public async void BuCategories_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoriesPage());
        }

        private async void buSearchButton_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }
    }
}