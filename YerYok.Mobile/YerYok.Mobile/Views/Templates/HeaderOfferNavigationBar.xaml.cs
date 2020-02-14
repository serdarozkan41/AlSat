using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YerYok.Mobile.Views.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderOfferNavigationBar : Grid
    {
        private string newTitle;

        public string NewTitle
        {
            get { return newTitle; }
            set
            {
                newTitle = value;
                OnPropertyChanged();
            }
        }

        private bool isBack;

        public bool IsBack
        {
            get { return isBack; }
            set
            {
                isBack = value;
                OnPropertyChanged();
            }
        }

        public HeaderOfferNavigationBar()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        private async void BuBack_Tapped(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void BuQuestion_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HowTheOfferWorksPage());
        }
    }
}