using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.PlatformConfiguration;


[assembly: ExportRenderer(typeof(Xamarin.Forms.SearchBar), typeof(ExpressDelivery.Droid.Renderers.SearchBarIconColorCustomRenderer))]
namespace ExpressDelivery.Droid.Renderers
{
    public class SearchBarIconColorCustomRenderer : SearchBarRenderer
    {
        public SearchBarIconColorCustomRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            var icon = Control?.FindViewById(Context.Resources.GetIdentifier("android:id/search_mag_icon", null, null));
            int nResId = Resource.Color.colorPrimary;
            (icon as ImageView)?.SetColorFilter(color: Context.Resources.GetColor(nResId, null));
        }
    }
}