﻿using System.Collections.Generic;
using System.Threading.Tasks;
using RebeliaApp.Web.Dto.Shared;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Services
{
    public interface IInfinityService
    {
        Task<List<Army>> GetArmies();
        Task<List<Scenario>> GetScenarios();
        Task<FriendlyGameResultResponse> SubmitFriendlyGameResult(FriendlyGameResultRequest request);
        Task<List<FriendlyGameResultResponse>> GetAllFriendlyBattleResults();
        Task<FriendlyGameResultResponse> GetFriendlyBattleResultByID(int id);

    }
}