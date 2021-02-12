using System.Collections.Generic;
using System.Threading.Tasks;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Services
{
    public interface IBattleService
    {

        Task<FriendlyGameResult> AddFriendlyBattleResult();
        Task<List<FriendlyGameResult>> GetFriendlyBattleResults();
        Task<FriendlyGameResult> GetFriendlyBattleResult();
    }
}