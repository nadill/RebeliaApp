using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RebeliaApp.Web.Dto.AccountService.Request;
using RebeliaApp.Web.Dto.AccountService.Response;
using RebeliaApp.Web.Dto.Shared;
using RebeliaApp.Web.Model;
using static RebeliaApp.Web.Model.Enums;

namespace RebeliaApp.Web.Services
{
    public class AccountService : IAccountService
    {
        RebeliaDBContext dbContext;
        IMapper mapper;

        public AccountService(RebeliaDBContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public async Task<GetUserAccountResponse> GetAccountById(int accountId) {
            var response = await dbContext.Players.Where(x => x.PlayerID == accountId).SingleAsync();
            var responseMapped = mapper.Map<GetUserAccountResponse>(response);
            return responseMapped;
        }

        public async Task<GetAllUserAccountsResponse> GetAllAccounts() {
            var response = await dbContext.Players.ToListAsync();
            var responseMapped = mapper.Map<GetAllUserAccountsResponse>(response);
            return responseMapped;
        }

        public async Task<GetAllUserAccountsResponse> GetAllAccountsExceptLoggedUser(int accountId) {
            var response = await dbContext.Players.Where(x => x.PlayerID != accountId).ToListAsync();
            var responseMapped = mapper.Map<GetAllUserAccountsResponse>(response);
            return responseMapped;
        }
    }
}
