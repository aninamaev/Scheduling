using Android.Graphics;
using QqInfoProject.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button), typeof(ButtonFontRenderer))]
namespace QqInfoProject.Droid
{
    public class ButtonFontRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
                Control.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets, SetFont.ReturnFont());
        }
    }

    public class SetFont
    {
        public static string ReturnFont()
        {
            return "ionicons.ttf";
        }
    }
}