using System;
namespace RebeliaApp.Web.Dto.AuthService.Request
{
    public class RegisterNewUserAccountRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
