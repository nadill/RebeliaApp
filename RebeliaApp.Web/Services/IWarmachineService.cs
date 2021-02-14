using System.Collections.Generic;
using System.Threading.Tasks;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Services
{
    public interface IWarmachineService
    {
        Task<List<Army>> GetWarmachineArmies();
        Task<List<Scenario>> GetWarmachineScenarios();

    }
}