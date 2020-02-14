using Foundation;
using Sharpnado.Presentation.Forms.iOS;
using UIKit;

namespace YerYok.Mobile.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();
            SharpnadoInitializer.Initialize(enableInternalLogger: true);
            LoadApplication(new App());
            Plugin.InputKit.Platforms.iOS.Config.Init();
            return base.FinishedLaunching(app, options);
        }
    }
}
