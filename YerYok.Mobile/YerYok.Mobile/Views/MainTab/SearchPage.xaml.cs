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
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();

            //TbSearch.Text.Length>0 //eğer büyük ise içine string.empty
            //var asas = TbSearch.Text;
            //TbSearch.Text = string.Empty;
            //TbSearch.Text = "";
        }

        private async void buGiveUp_Tapped(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbSearch.Text))
            {
                await Navigation.PopAsync();
            }
            else
            {
                if (TbSearch.Text.Length > 0)
                {
                    TbSearch.Text = string.Empty;
                }
                else
                {
                    await Navigation.PopAsync();
                }
            }
        }
    }
}