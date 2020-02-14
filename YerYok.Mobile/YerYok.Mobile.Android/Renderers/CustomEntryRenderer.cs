using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using YerYok.Mobile.Droid.Renderers;

#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace YerYok.Mobile.Droid.Renderers
{
    [System.Obsolete]
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = Android.App.Application.Context.GetDrawable(Resource.Drawable.RoundCornerbutton);
                Control.Gravity = GravityFlags.CenterVertical;
                Control.SetPadding(20, 0, 0, 0);
            }
        }
    }
}