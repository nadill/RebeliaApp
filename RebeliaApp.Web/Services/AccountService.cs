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

        public async Task<LogInUserResponse> LoginToUserAccount(LogInUserRequest request) {
            var requestMapped = mapper.Map<Player>(request);

            bool accountExists = await dbContext.Players.Where(p => p.Email == requestMapped.Email && p.Password == requestMapped.Password).AnyAsync();
            if (accountExists) {
                var response = await dbContext.Players.Where(p => p.Email == requestMapped.Email && p.Password == requestMapped.Password).SingleAsync();
                var responseMapped = mapper.Map<LogInUserResponse>(response);
                responseMapped.ResponseCode = RESPONSE_CODE.SUCCESS;
                responseMapped.Message = "Login succesfull";
                responseMapped.Account = new UserAccount {
                    PlayerID = response.PlayerID,
                    FirstName = response.FirstName,
                    LastName = response.LastName,
                    Nick = response.Nick
                };
                return responseMapped;
            }
            else {
                var responseMapped = new LogInUserResponse {
                    ResponseCode = RESPONSE_CODE.VALIDATION_ERROR,
                    Message = "Incorrect email or password",
                    Account = null
                };
                return responseMapped;
            }
        }

        public async Task<RegisterNewUserAccountRespose> RegisterNewUserAccount(RegisterNewUserAccountRequest request) {
            var requestMapped = mapper.Map<Player>(request);
            bool accountExists = await dbContext.Players.Where(x => x.Email == requestMapped.Email).AnyAsync();

            if (accountExists) {
                var responseMapped = new RegisterNewUserAccountRespose { Message = "Account already exists", ResponseCode = RESPONSE_CODE.VALIDATION_ERROR };
                return responseMapped;
            }
            else {
                var response = await dbContext.Players.AddAsync(requestMapped);
                var responseMapped = mapper.Map<RegisterNewUserAccountRespose>(response);
                responseMapped.Message = "Account created";
                responseMapped.ResponseCode = RESPONSE_CODE.SUCCESS;
                return responseMapped;
            }

        }
    }
}
