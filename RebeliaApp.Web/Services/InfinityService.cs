using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Services
{
    public class InfinityService : IInfinityService
    {
        public InfinityService()
        {
            
        }

        public async Task<List<Theme>> GetInfinityThemes() {
            return null;
        }
        public async Task<List<Army>> GetInfinityArmies() {
            return null;
        }
        public async Task<List<Scenario>> GetInfinityScenarios() {
            return null;
        }
    }
}
