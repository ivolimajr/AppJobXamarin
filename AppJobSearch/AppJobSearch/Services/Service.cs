using System.Net.Http;

namespace AppJobSearch.Services
{
    public abstract class Service
    {
        protected HttpClient _client;
        protected string BaseApiUrl = "https://xamarinforms2020api.azurewebsites.net/";

        public Service()
        {
            _client = new HttpClient();
        }
    }
}
