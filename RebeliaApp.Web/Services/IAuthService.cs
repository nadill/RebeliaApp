using System.Threading.Tasks;
using RebeliaApp.Web.Dto.AuthService.Request;
using RebeliaApp.Web.Dto.AuthService.Response;

namespace RebeliaApp.Web.Services
{
    public interface IAuthService
    {
        public Task<UserLoginResponse> Login(UserLoginRequest request);
    }
}
