using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RebeliaApp.Web.Dto.InfinityService.Request;
using RebeliaApp.Web.Dto.InfinityService.Response;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Services
{
    public class WarmachineService : IWarmachineService, IBattleService
    {
        public WarmachineService()
        {
        }

        public async Task<List<Army>> GetWarmachineArmies() {
            return null;
        }
        public async Task<List<Scenario>> GetWarmachineScenarios() {
            return null;
        }

        public async Task<FriendlyGameResultResponse> SubmitFriendlyGameResult(FriendlyGameResultRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FriendlyGameResultResponse>> GetAllFriendlyBattleResults()
        {
            throw new NotImplementedException();
        }

        public async Task<FriendlyGameResultResponse> GetFriendlyBattleResultByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
