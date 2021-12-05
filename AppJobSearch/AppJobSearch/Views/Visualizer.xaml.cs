using AppJobSearch.Models;
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
        protected override void OnAppearing()
        {
            base.OnAppearing();

            Job job = ((Job)BindingContext);

            if (string.IsNullOrEmpty(job.CompanyDescription))
            {
                HeaderCompanyDescription.IsVisible = false;
                TextCompanyDescription.IsVisible = false;
            }

            if (string.IsNullOrEmpty(job.JobDescription))
            {
                HeaderJobDescription.IsVisible = false;
                TextJobDescription.IsVisible = false;
            }

            if (string.IsNullOrEmpty(job.Benefits))
            {
                HeaderBenefits.IsVisible = false;
                TextBenefits.IsVisible = false;
            }
        }
    }
}