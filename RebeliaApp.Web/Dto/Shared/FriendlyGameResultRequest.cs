using System;
using System.Collections.Generic;

namespace RebeliaApp.Web.Dto.Shared
{
    public class FriendlyGameResultRequest
    {
        public List<PlayerResult> PlayerList { get; set; }
        public int? WinnerID { get; set; }
        public DateTime Date { get; set; }
        public int SystemID { get; set; }
        public int ScenarioID { get; set; }
        public int Rounds { get; set; }
        public int PointFormat { get; set; }

    }
}
