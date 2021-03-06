﻿using System.ComponentModel.DataAnnotations;

namespace RebeliaApp.Web.Model
{
    public class PlayerScore
    {
        [Key]
        public int PlayerID { get; set; }
        public int GameID { get; set; }
        public int ArmyID { get; set; }
        public int ThemeID { get; set; }
        public int CasterID { get; set; }
        public int ObjectivePoints { get; set; }
        public int ArmyPoints { get; set; }
    }
}