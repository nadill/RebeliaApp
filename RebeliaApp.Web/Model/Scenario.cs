using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RebeliaApp.Web.Model
{
    public class Scenario
    {
        [Key]
        public int ScenarioID { get; set; }
        public int SystemID { get; set; }
        [MaxLength(100)]
        public string ScenarioName { get; set; }
        [ForeignKey("ScenarioID")]
        public virtual List<MapFormat> ScenarioFormats { get; set; }

    }
}
