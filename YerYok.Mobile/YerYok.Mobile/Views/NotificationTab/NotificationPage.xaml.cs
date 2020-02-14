using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YerYok.Mobile.Views.NotificationTab
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationPage : ContentView
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
        public NotificationPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
    }
}