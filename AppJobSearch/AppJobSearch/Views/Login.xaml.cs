
using AppJobSearch.Models;
using AppJobSearch.Services;
using AppJobSearch.Utility.Load;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppJobSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private UserService _service;
        public Login()
        {
            InitializeComponent();

            _service = new UserService();
        }

        private void btnRegisterPage(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }

        private async void btnStartPage(object sender, System.EventArgs e)
        {
            await Navigation.PushPopupAsync(new Loading());

            var email = Email.Text;
            var password = Password.Text;
            ResponseService<User> result = await _service.GetUser(email, password);

            if (!result.IsSuccess)
                await DisplayAlert("Não foi possível entrar", "Dados Inválidos", "Ok");

            if (result.IsSuccess)
            {
                App.Current.Properties.Add("User", JsonConvert.SerializeObject(result.Data));
                await App.Current.SavePropertiesAsync();
                App.Current.MainPage = new NavigationPage(new Start());
            }

            await Navigation.PopAllPopupAsync();
        }
    }
}