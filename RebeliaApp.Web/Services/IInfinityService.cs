using System.Collections.Generic;
using System.Threading.Tasks;
using RebeliaApp.Web.Dto.InfinityService.Request;
using RebeliaApp.Web.Dto.InfinityService.Response;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Services
{
    public interface IInfinityService
    {
        Task<List<Army>> GetInfinityArmies();
        Task<List<Scenario>> GetInfinityScenarios();
        Task<FriendlyGameResultResponse> SubmitFriendlyGameResult(FriendlyGameResultRequest request);
        Task<List<FriendlyGameResultResponse>> GetAllFriendlyBattleResults();
        Task<FriendlyGameResultResponse> GetFriendlyBattleResultByID(int id);

    }
}