using System;
using AutoMapper;
using RebeliaApp.Web.Dto.AccountService.Request;
using RebeliaApp.Web.Dto.AccountService.Response;
using RebeliaApp.Web.Dto.AuthService.Request;
using RebeliaApp.Web.Dto.AuthService.Response;
using RebeliaApp.Web.Dto.Shared;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Mapper
{
    public class AccountMapper : Profile
    {
        public AccountMapper()
        {
            CreateMap<UserLoginRequest, Player>();
            CreateMap<Player, UserLoginResponse>();
            CreateMap<Player, UserAccount>();
            CreateMap<UserAccount, Player> ();
        }
    }
}
