using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RebeliaApp.Web.Dto.InfinityService.Request;
using RebeliaApp.Web.Dto.InfinityService.Response;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Services
{
    public class InfinityService : IInfinityService, IBattleService
    {
        RebeliaDBContext dbContext;
        IMapper mapper;
        public InfinityService(RebeliaDBContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public Task<List<FriendlyGameResultResponse>> GetAllFriendlyBattleResults()
        {
            throw new NotImplementedException();
        }

        public Task<FriendlyGameResultResponse> GetFriendlyBattleResultByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Army>> GetInfinityArmies()
        {
            List<Army> infinityArmies = await dbContext.Armies.Where(s => s.SystemID == 1).Include(t => t.ArmyThemes).ToListAsync();
            return infinityArmies;
        }
        public async Task<List<Scenario>> GetInfinityScenarios()
        {
            List<Scenario> scenarios = await dbContext.Scenario.Where(x => x.SystemID == 1).Include(t => t.ScenarioFormats).ToListAsync();
            return scenarios;
        }

        public async Task<FriendlyGameResultResponse> SubmitFriendlyGameResult(FriendlyGameResultRequest request)
        {
            var requestMapper = mapper.Map<FriendlyGameResult>(request);
            var response = await dbContext.FriendlyGameResults.AddAsync(requestMapper);
            var responseMapped = mapper.Map<FriendlyGameResultResponse>(response);

            return responseMapped;
            // test

        }
    }
}
