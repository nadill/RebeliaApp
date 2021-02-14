using System;
using System.Collections.Generic;
using RebeliaApp.Web.Dto.Shared;
using static RebeliaApp.Web.Model.Enums;

namespace RebeliaApp.Web.Dto.InfinityService.Request
{
    public class FriendlyGameResultRequest
    {
        public List<PlayerResult> PlayerList { get; set; }
        public int? WinnerID { get; set; }
        public BattleResult BattleResult { get; set; }
        public DateTime Date { get; set; }
        public int SystemID { get; set; }
        public int ScenarioID { get; set; }
        public int Rounds { get; set; }
        public int PointFormat { get; set; }

    }
}
