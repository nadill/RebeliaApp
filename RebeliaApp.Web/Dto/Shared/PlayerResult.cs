using System;
using static RebeliaApp.Web.Model.Enums;

namespace RebeliaApp.Web.Dto.Shared
{
    public class PlayerResult
    {
        public int PlayerID { get; set; }
        public int ArmyID { get; set; }
        public int? ThemeID { get; set; }
        public int? CasterID { get; set; }
        public WinCondition WinCondition { get; set; }
        public BattleResult BattleResult { get; set; }
        public int ObjectivePoints { get; set; }
        public int ArmyPoints { get; set; }
    }
}
