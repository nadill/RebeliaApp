using System;
using RebeliaApp.Web.Dto.Shared;

namespace RebeliaApp.Web.Dto.AccountService.Response
{
    public class LogInUserResponse : ResponseBase
    {
        public UserAccount Account { get; set; }

    }
}
