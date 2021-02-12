using System;
using System.ComponentModel.DataAnnotations;

namespace RebeliaApp.Web.Model
{
    public class MapFormat
    {
        [Key]
        public int MapID { get; set; }
        public int ScenarioID { get; set; }
        public int SystemID { get; set; }
        [MaxLength(100)]
        public string SmallFormat { get; set; }
        [MaxLength(100)]
        public string MediumFormat { get; set; }
        [MaxLength(100)]
        public string StandardFormat { get; set; }

    }
}
