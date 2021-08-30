using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EnglishTime.WebBlazor.Pages.Tip.Shared
{
    public class TipServiceApiRest : ITipService
    {
        private HttpClient _httpClient;

        public TipServiceApiRest(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TipDto[]> GetAllTips()
        {
            return await _httpClient.GetFromJsonAsync<TipDto[]>("Tip");
        }
    }
}