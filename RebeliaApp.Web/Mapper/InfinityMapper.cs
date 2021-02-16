using System;
using RebeliaApp.Web.Dto.Shared;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Mapper
{
    public class InfinityMapper: AutoMapper.Profile
    {
        public InfinityMapper()
        {
            CreateMap<FriendlyGameResultRequest, FriendlyGameResult>();
            CreateMap<FriendlyGameResult, FriendlyGameResultResponse>();
            CreateMap<PlayerResult, PlayerScore>();
            CreateMap<PlayerScore, PlayerResult >();


        }
    }
}
