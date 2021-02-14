﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RebeliaApp.Web.Model.Enums;

namespace RebeliaApp.Web.Model
{
    public class TournamentSoloGameResult
    {
        [Key]
        public int GameID { get; set; }
        public int BattleID { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("PlayerID")]
        public virtual Player Player { get; set; }
        public int TournamentPoints { get; set; }
        public int ObjectivePoints { get; set; }
        public int ArmyPoints { get; set; }
        public int PointSize { get; set; }
        public int Rounds { get; set; }
        public WinCondition DefetedBy { get; set; }
        [ForeignKey("SystemID")]
        public virtual GameSystem System { get; set; }
        [ForeignKey("ArmyID")]
        public virtual Army Army { get; set; }
        [ForeignKey("ThemeID")]
        public virtual Theme Theme { get; set; }
        [MaxLength(100)]
        public string ScenarioName { get; set; }
        public BattleResult BattleResult { get; set; }
        public bool Bye { get; set; }
    }
}