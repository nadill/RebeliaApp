using System;
using AutoMapper;
using RebeliaApp.Web.Dto.AuthService.Request;
using RebeliaApp.Web.Dto.AuthService.Response;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Mapper
{
    public class AuthMapper:Profile
    {
        public AuthMapper()
        {
            CreateMap<UserLoginRequest, Player>();
            CreateMap<Player, UserLoginResponse>();
            CreateMap<RegisterNewUserAccountRequest, Player>();
            CreateMap<Player, RegisterNewUserAccountRespose>();



        }
    }
}
