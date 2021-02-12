using System.Collections.Generic;
using System.Threading.Tasks;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Services
{
    public interface IInfinityService
    {
        Task<List<Theme>> GetInfinityThemes();
        Task<List<Army>> GetInfinityArmies();
        Task<List<Scenario>> GetInfinityScenarios();
    }
}