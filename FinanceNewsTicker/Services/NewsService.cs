using FinanceNewsTicker.Models;
using Newtonsoft.Json;

namespace FinanceNewsTicker.Services
{
    public class NewsService : INewsService
    {
        private readonly IConfiguration _configuration;
        public NewsService(IConfiguration configuration)
        {
            //dependecy injection
            _configuration = configuration;
        }

        public FinanceNews GetFinanceNews()
        {
            //Getting api key
            string apiKey = _configuration.GetValue<string>("API_KEY");
            //Getting api url
            string apiUrl = _configuration.GetValue<string>("API_URL");

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage response = client.GetAsync($"?apikey={apiKey}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<FinanceNews>(result);
                }
                else
                {
                    return new FinanceNews()
                    {
                        Data = new List<NewsArticle>(),
                        Pagination = new Pagination()
                    };
                }
            }
            
        }
    }
}
