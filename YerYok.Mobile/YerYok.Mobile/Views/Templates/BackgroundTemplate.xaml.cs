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
    public partial class BackgroundTemplate : Image
    {
        private string backgroundImage;

        public string BackgroundImage
        {
            get { return backgroundImage; }
            set { backgroundImage = value; }
        }
        public BackgroundTemplate()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
    }
}