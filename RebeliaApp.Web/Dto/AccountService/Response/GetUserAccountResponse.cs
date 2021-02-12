using System;
using RebeliaApp.Web.Dto.Shared;

namespace RebeliaApp.Web.Dto.AccountService.Response
{
    public class GetUserAccountResponse : ResponseBase
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nick { get; set; }

    }
}
