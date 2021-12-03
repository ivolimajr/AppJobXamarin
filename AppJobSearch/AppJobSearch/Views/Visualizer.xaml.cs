using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppJobSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Visualizer : ContentPage
    {
        public Visualizer()
        {
            InitializeComponent();
        }

        private void btnStartPage(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}