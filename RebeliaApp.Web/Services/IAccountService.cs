using System.Collections.Generic;
using System.Threading.Tasks;
using RebeliaApp.Web.Dto.AccountService.Request;
using RebeliaApp.Web.Dto.AccountService.Response;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Services
{
    public interface IAccountService
    {
        Task<GetUserAccountResponse> GetAccountById(int accountId);
        Task<GetAllUserAccountsResponse> GetAllAccounts();
        Task<GetAllUserAccountsResponse> GetAllAccountsExceptLoggedUser(int userId);


    }
}