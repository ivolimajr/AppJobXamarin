using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppJobSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterJob : ContentPage
    {
        public RegisterJob()
        {
            InitializeComponent();
        }

        private void btnStartPage(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void btnSaveJob(object sender, EventArgs e)
        {
            DisplayAlert("Salvo", "Registrado!", "Ok");
            Navigation.PopAsync();
        }
    }
}