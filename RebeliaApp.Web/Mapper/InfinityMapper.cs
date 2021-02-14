﻿using System;
using RebeliaApp.Web.Dto.InfinityService.Request;
using RebeliaApp.Web.Dto.InfinityService.Response;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Mapper
{
    public class InfinityMapper: AutoMapper.Profile
    {
        public InfinityMapper()
        {
            CreateMap<FriendlyGameResultRequest, FriendlyGameResult>();
            CreateMap<FriendlyGameResult, FriendlyGameResultResponse>();

        }
    }
}