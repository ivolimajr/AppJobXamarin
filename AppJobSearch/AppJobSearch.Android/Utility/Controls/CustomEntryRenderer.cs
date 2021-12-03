﻿using Android.Content;
using AppJobSearch.Droid.Utility.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace AppJobSearch.Droid.Utility.Controls
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.Background = null;
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}