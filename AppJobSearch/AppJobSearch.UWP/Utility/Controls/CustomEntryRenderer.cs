using AppJobSearch.UWP.Utility.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace AppJobSearch.UWP.Utility.Controls
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer()
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
                Control.BorderThickness = new Windows.UI.Xaml.Thickness(0);
        }
    }
}
