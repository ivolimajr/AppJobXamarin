using AppJobSearch.Models;
using AppJobSearch.Services;
using AppJobSearch.Utility.Load;
using Rg.Plugins.Popup.Extensions;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppJobSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        private UserService _service;

        public Register()
        {
            InitializeComponent();
            _service = new UserService();
        }

        private async void btnSalvar(object sender, EventArgs e)
        {

            if (!validateField(txtName.Text, "Nome") ||
                !validateField(txtEmail.Text, "Email") ||
                !validateField(txtPassWord.Text, "Senha"))
                return;

            await Navigation.PushPopupAsync(new Loading());

            var user = new User
            {
                Email = txtEmail.Text,
                Name = txtName.Text,
                Password = txtPassWord.Text
            };

            ResponseService<User> result = await _service.AddUser(user);

            if (!result.IsSuccess)
                await DisplayAlert("Error ao cadastrar", "Verifque os dados", "OK");

            if (result.IsSuccess)
            {
                await Navigation.PopAllPopupAsync();
                await DisplayAlert("Cadastro realizado", "Faça Login para continuar", "OK");
                App.Current.MainPage = new NavigationPage(new Login());
            }
        }

        private void btnLoginPage(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private bool validateField(string value, string field)
        {
            lbErrorMessage.Text = string.Empty;
            lbErrorMessage.IsVisible = false;
            if (string.IsNullOrEmpty(value))
            {
                lbErrorMessage.Text = field + " requerido!";
                lbErrorMessage.IsVisible = true;
                return false;
            }
            if (value.Length <= 3)
            {
                lbErrorMessage.Text = field + " curto demais!";
                lbErrorMessage.IsVisible = true;
                return false;
            };
            return true;
        }
    }
}