using System.Net.Http;
using System.Threading.Tasks;

namespace Mmt.Shop.Console.Strategies
{
    public class ListFeaturedProductsStrategy : IDemoProgramStrategy
    {
        private IHttpClientFactory _clientFactory;

        public ListFeaturedProductsStrategy(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task Execute()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Strings.ApiProductsFeatured);
            var client = _clientFactory.CreateClient(Strings.DemoClient);
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                System.Console.WriteLine(responseStream.ReadAllText());
            }
            else
            {
                System.Console.WriteLine($"An error occurred while calling the get featured products endpoint: {response.ReasonPhrase}");
            }
        }
    }
}
