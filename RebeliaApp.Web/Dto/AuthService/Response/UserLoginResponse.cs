using RebeliaApp.Web.Dto.Shared;

namespace RebeliaApp.Web.Dto.AuthService.Response
{
    public class UserLoginResponse : ResponseBase
    {
        public string tokenString { get; set; }
    }
}
