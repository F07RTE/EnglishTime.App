using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

using EnglishTime.WebBlazor.Pages.User.Shared;

namespace EnglishTime.WebBlazor.Pages.User
{
    public partial class Users
    {
        [Inject]
        IUserService UserService { get; set; }
        
        public UserDto[] users { get; set; }

        protected override async Task OnInitializedAsync()
        {
            users = await UserService.GetAllUsers();
        }
    }
}