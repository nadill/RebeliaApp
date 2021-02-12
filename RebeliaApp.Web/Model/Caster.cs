using System.ComponentModel.DataAnnotations;

namespace RebeliaApp.Web.Model
{
    public class Caster
    {
        [Key]
        public int CasterID { get; set; }
        public int ArmyID { get; set; }
        [MaxLength(100)]
        public string CasterName { get; set; }
        [MaxLength(100)]
        public string CasterImg { get; set; }
    }

}