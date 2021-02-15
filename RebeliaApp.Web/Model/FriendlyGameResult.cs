﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RebeliaApp.Web.Model.Enums;

namespace RebeliaApp.Web.Model
{
    public class FriendlyGameResult
    {
        [Key]
        public int GameID { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("GameID")]
        public virtual List<PlayerScore> PlayerList { get; set; }
        public int? WinnerID { get; set; }
        public BattleResult BattleResult { get; set; }
        public int SystemID { get; set; }
        public int ScenarioID { get; set; }
        public int Rounds { get; set; }
        public int PointFormat { get; set; }



    }
}