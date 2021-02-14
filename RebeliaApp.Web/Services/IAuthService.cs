using System.Threading.Tasks;
using RebeliaApp.Web.Dto.AccountService.Request;
using RebeliaApp.Web.Dto.AccountService.Response;
using RebeliaApp.Web.Dto.AuthService.Request;
using RebeliaApp.Web.Dto.AuthService.Response;

namespace RebeliaApp.Web.Services
{
    public interface IAuthService
    {
        Task<UserLoginResponse> Login(UserLoginRequest request);
        Task<RegisterNewUserAccountRespose> Register(RegisterNewUserAccountRequest request);

    }
}
