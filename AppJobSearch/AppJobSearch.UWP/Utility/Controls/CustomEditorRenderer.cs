using AppJobSearch.UWP.Utility.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Editor), typeof(CustomEditorRenderer))]
namespace AppJobSearch.UWP.Utility.Controls
{
    public class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer()
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
                Control.BorderThickness = new Windows.UI.Xaml.Thickness(0);
        }
    }
}
