using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RebeliaApp.Web.Model
{
    public class FriendlyGameResult
    {
        [Key]
        public int GameID { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("GameID")]
        public virtual List<PlayerScore> Players { get; set; }
        public int PointFormat { get; set; }
        public int Rounds { get; set; }
        public int SystemID { get; set; }
        public int ScenarioID { get; set; }
        public int WinnerID { get; set; }
        public bool CastrKill { get; set; }
        public bool DeathClock { get; set; }


    }
}
