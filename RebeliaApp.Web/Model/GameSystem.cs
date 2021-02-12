using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RebeliaApp.Web.Model
{
    public class GameSystem
    {
        [Key]
        public int SystemID { get; set; }
        [MaxLength(100)]
        public string SystemName { get; set; }
        [ForeignKey("SystemID")]
        public virtual List<Army> SystemArmies { get; set; }
        [MaxLength(100)]
        public string SystemImage { get; set; }
        [ForeignKey("SystemID")]
        public virtual List<Scenario> SystemScenarios { get; set; }
    }
}
