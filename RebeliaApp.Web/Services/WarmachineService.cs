using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Services
{
    public class WarmachineService : IWarmachineService
    {
        public WarmachineService()
        {
        }

        public async Task<List<Theme>> GetWarmachineThemes() {
            return null;
        }
        public async Task<List<Army>> GetWarmachineArmies() {
            return null;
        }
        public async Task<List<Scenario>> GetWarmachineScenarios() {
            return null;
        }
    }
}
