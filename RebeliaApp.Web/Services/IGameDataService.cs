using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Services
{
    public interface IGameDataService
    {
        Task<List<Army>> GetInfinityArmies();
        Task<List<Army>> GetWarmachineHordesArmies();
        Task<List<GameSystem>> GetAllGameSystems();
        Task<List<Scenario>> GetInfinityScenarios();


        Task<List<Scenario>> AddInfinityMissions();
        Task<List<Theme>> AddInfinityThemes();
        Task<List<Army>> AddInfinityArmies();
        Task<List<MapFormat>> AddInfinityMapFormats();
    }
}
