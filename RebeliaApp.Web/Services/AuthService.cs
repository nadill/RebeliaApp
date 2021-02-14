using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RebeliaApp.Web.Dto.AccountService.Request;
using RebeliaApp.Web.Dto.AccountService.Response;
using RebeliaApp.Web.Dto.AuthService.Request;
using RebeliaApp.Web.Dto.AuthService.Response;
using RebeliaApp.Web.Model;
using static RebeliaApp.Web.Model.Enums;

namespace RebeliaApp.Web.Services
{
    public class AuthService : IAuthService
    {
        RebeliaDBContext dbContext;
        IMapper mapper;

        public AuthService(RebeliaDBContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            if (request == null) return null;
            var requestMapped = mapper.Map<Player>(request);
            Player dbUser;
            try {
                dbUser = await dbContext.Players.Where(user => user.Email == requestMapped.Email && user.Password == requestMapped.Password).SingleAsync();
            } catch {
                dbUser = null;
            }

            if (dbUser != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("!decievingSecterKey!@#$5"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001/",
                    audience: "https://localhost:5001/",
                    expires: DateTime.Now.AddMonths(1),
                    signingCredentials: signingCredentials
                    );
                tokenOptions.Payload["FirstName"] = dbUser.FirstName;
                tokenOptions.Payload["LastName"] = dbUser.LastName;
                tokenOptions.Payload["Nick"] = dbUser.Nick;
                tokenOptions.Payload["PlayerID"] = dbUser.PlayerID;

                string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                var response = new UserLoginResponse {
                    ResponseCode = ResponseCode.SUCCESS,
                    Header = "Login successful",
                    Message = "",
                    tokenString = tokenString,
                    Success = true
                };
                return response;
            }
            else {
                var response = new UserLoginResponse
                {
                    ResponseCode = ResponseCode.VALIDATION_ERROR,
                    Header = "Invalid email or password",
                    tokenString = null,
                    Success = false
                };
                return response;
            }
        }

        public async Task<RegisterNewUserAccountRespose> Register(RegisterNewUserAccountRequest request)
        {
            var requestMapped = mapper.Map<Player>(request);
            bool accountExists = await dbContext.Players.Where(x => x.Email == requestMapped.Email).AnyAsync();

            if (accountExists)
            {
                var responseMapped = new RegisterNewUserAccountRespose { Message = "Account already exists", ResponseCode = ResponseCode.VALIDATION_ERROR };
                return responseMapped;
            }
            else
            {
                var response = await dbContext.Players.AddAsync(requestMapped);
                var responseMapped = mapper.Map<RegisterNewUserAccountRespose>(response);
                responseMapped.Message = "Account created";
                responseMapped.ResponseCode = ResponseCode.SUCCESS;
                return responseMapped;
            }

        }

    }
}
