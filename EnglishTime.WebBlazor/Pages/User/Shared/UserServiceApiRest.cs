using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EnglishTime.WebBlazor.Pages.User.Shared
{
    public class UserServiceApiRest : IUserService
    {
        private HttpClient _httpClient;

        public UserServiceApiRest(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDto[]> GetAllUsers()
        {
            return await _httpClient.GetFromJsonAsync<UserDto[]>("User");
        }
    }
}