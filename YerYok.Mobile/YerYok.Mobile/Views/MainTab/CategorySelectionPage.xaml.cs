using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YerYok.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategorySelectionPage : ContentPage
    {
        public CategorySelectionPage()
        {
            InitializeComponent();
        }

        private async void cancel_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}