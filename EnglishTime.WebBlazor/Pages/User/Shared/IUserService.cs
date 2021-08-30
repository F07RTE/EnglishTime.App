using System.Threading.Tasks;

namespace EnglishTime.WebBlazor.Pages.User.Shared
{
    public interface IUserService
    {
        Task<UserDto[]> GetAllUsers();
    }
}