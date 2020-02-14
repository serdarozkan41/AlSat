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
    public partial class CategoriesPage : ContentPage
    {
        public CategoriesPage()
        {
            InitializeComponent();

            List<Category> categories = new List<Category>();
            categories.Add(new Category { CategoryName = "Yemek Tabağı" });
            categories.Add(new Category { CategoryName = "Yemek Tabağı", IsType = true });
            categories.Add(new Category { CategoryName = "Yemek Tabağı" });
            categories.Add(new Category { CategoryName = "Yemek Tabağı", IsType = true });
            categories.Add(new Category { CategoryName = "Yemek Tabağı" });
            categories.Add(new Category { CategoryName = "Yemek Tabağı", IsType = true });
            categories.Add(new Category { CategoryName = "Yemek Tabağı" });
            categories.Add(new Category { CategoryName = "Yemek Tabağı", IsType = true });
            categories.Add(new Category { CategoryName = "Yemek Tabağı" });
            categories.Add(new Category { CategoryName = "Tümünü Göster", IsType = true });

            LvCategories.ItemsSource = categories;
        }

        private async void LvCategories_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var category = e.SelectedItem as Category;

            if (category.CategoryName == "Tümünü Göster")
            {
                //a sayfasına git
                await Navigation.PushAsync(new CategorySelectionPage());
            }
            else
            {
                await DisplayAlert("Uyarı", "Henüz tamamlanmadı", "TAmam");
            }
        }
    }
}