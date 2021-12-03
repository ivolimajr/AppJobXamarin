using AppJobSearch.Views;
using Xamarin.Forms;

namespace AppJobSearch
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //ClearCurrentProperties();
            Login();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        private async void ClearCurrentProperties()
        {
            App.Current.Properties.Remove("User");
            await App.Current.SavePropertiesAsync();
            MainPage = new NavigationPage(new Login());
        }
        private void Login()
        {
            if (App.Current.Properties.ContainsKey("User"))
            {
                MainPage = new NavigationPage(new Start());
            }
            else
            {
                MainPage = new NavigationPage(new Login());
            }
        }
    }
}
