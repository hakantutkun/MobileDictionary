using Android.Graphics.Drawables;
using MobileDictionary.CustomRenderers;
using MobileDictionary.Droid.CustomRenderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TransparentEntry), typeof(TransparentEntryRendererAndroid))]
namespace MobileDictionary.Droid.CustomRenderers
{
    [Obsolete]
    class TransparentEntryRendererAndroid : EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(20f);
                //gradientDrawable.SetStroke(5, Android.Graphics.Color.LightGray);
                gradientDrawable.SetColor(Android.Graphics.Color.Transparent);
                Control.SetBackground(gradientDrawable);
                Control.SetPadding(0, 14, Control.PaddingRight, 4);
            }
        }
    }
}