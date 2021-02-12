using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RebeliaApp.Web.Model
{
    public class Army
    {
        [Key]
        public int ArmyID { get; set; }
        public int SystemID { get; set; }
        [Required]
        [MaxLength(100)]
        public string ArmyName { get; set; }
        [ForeignKey("ArmyID")]
        public virtual List<Theme> ArmyThemes { get; set; }
        [MaxLength(100)]
        public string ArmyImage { get; set; }
        [ForeignKey("ArmyID")]
        public List<Caster> CasterList { get; set; }
    }
}
