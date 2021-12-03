using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppJobSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Start : ContentPage
    {
        public Start()
        {
            InitializeComponent();
        }

        private void btnAddJob(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterJob());
        }

        private void btnSearch(object sender, System.EventArgs e)
        {

        }

        private void btnVisualizerPage(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Visualizer());
        }

        private void btnFocusPesquisa(object sender, System.EventArgs e)
        {
            txtPesquisa.Focus();
        }

        private void btnFocusCidadeEstado(object sender, System.EventArgs e)
        {
            txtCidadeEstado.Focus();
        }

        private async void btnLogout(object sender, System.EventArgs e)
        {
            App.Current.Properties.Remove("User");
            await App.Current.SavePropertiesAsync();
            App.Current.MainPage = new Login();
        }
    }
}