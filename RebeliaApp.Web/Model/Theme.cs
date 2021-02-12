using System;
using System.ComponentModel.DataAnnotations;

namespace RebeliaApp.Web.Model
{
    public class Theme
    {
        [Key]
        public int ThemeID { get; set; }
        public int ArmyID { get; set; }
        public int SystemID { get; set; }
        [MaxLength(100)]
        public string ThemeName { get; set; }
        [MaxLength(100)]
        public string ThemeImage { get; set; }

    }
}
