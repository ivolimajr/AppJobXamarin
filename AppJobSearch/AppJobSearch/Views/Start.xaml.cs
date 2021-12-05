using AppJobSearch.Models;
using AppJobSearch.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppJobSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Start : ContentPage
    {
        private JobService _service;
        private ObservableCollection<Job> _listOfJobs;
        private SearchParams _searchParams;
        private int _listOfJobsFirstRequest;

        public Start()
        {
            InitializeComponent();
            _service = new JobService();
        }

        private void btnAddJob(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterJob());
        }

        private async void btnSearch(object sender, System.EventArgs e)
        {
            TxtResultsCount.Text = String.Empty;
            Loading.IsVisible = true;
            Loading.IsRunning = true;
            NoResult.IsVisible = false;

            string word = TxtWord.Text;
            string cityState = TxtCityState.Text;

            _searchParams = new SearchParams() { Word = word, CityState = cityState, NumberOfPage = 1 };

            ResponseService<List<Job>> responseService = await _service.GetJobs(_searchParams.Word, _searchParams.CityState, _searchParams.NumberOfPage);

            if (responseService.IsSuccess)
            {
                _listOfJobs = new ObservableCollection<Job>(responseService.Data);
                _listOfJobsFirstRequest = _listOfJobs.Count();
                ListOfJobs.ItemsSource = _listOfJobs;
                ListOfJobs.RemainingItemsThreshold = 1;

                TxtResultsCount.Text = $"{responseService.Pagination.TotalItems} resultado(s).";
            }
            else
            {
                await DisplayAlert("Erro!", "Oops! Ocorreu um erro inesperado! Tente novamente mais tarde.", "OK");
            }
            if (_listOfJobs.Count == 0)
            {
                NoResult.IsVisible = true;
            }
            else
            {
                NoResult.IsVisible = false;
            }
            Loading.IsVisible = false;
            Loading.IsRunning = false;
        }

        private void btnVisualizerPage(object sender, System.EventArgs e)
        {
            var eventArgs = (TappedEventArgs)e;

            var page = new Visualizer();
            page.BindingContext = eventArgs.Parameter;

            Navigation.PushAsync(page);
        }

        private void btnFocusPesquisa(object sender, System.EventArgs e)
        {
            TxtWord.Focus();
        }

        private void btnFocusCidadeEstado(object sender, System.EventArgs e)
        {
            TxtCityState.Focus();
        }

        private async void btnLogout(object sender, System.EventArgs e)
        {
            App.Current.Properties.Remove("User");
            await App.Current.SavePropertiesAsync();
            App.Current.MainPage = new Login();
        }

        private async void InfinitySearch(object sender, System.EventArgs e)
        {
            ListOfJobs.RemainingItemsThreshold = -1;
            _searchParams.NumberOfPage++;

            ResponseService<List<Job>> responseService = await _service.GetJobs(_searchParams.Word, _searchParams.CityState, _searchParams.NumberOfPage);

            if (responseService.IsSuccess)
            {
                var listOfJobsFromService = responseService.Data;
                foreach (var item in listOfJobsFromService)
                {
                    _listOfJobs.Add(item);
                }
                if (_listOfJobsFirstRequest == listOfJobsFromService.Count)
                {
                    ListOfJobs.RemainingItemsThreshold = 1;
                }
                else
                {
                    ListOfJobs.RemainingItemsThreshold = -1;
                }
            }
            else
            {
                await DisplayAlert("Erro!", "Oops! Ocorreu um erro inesperado! Tente novamente mais tarde.", "OK");
                ListOfJobs.RemainingItemsThreshold = 0;
            }
        }
    }
}