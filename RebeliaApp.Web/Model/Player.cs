using System;
using System.ComponentModel.DataAnnotations;

namespace RebeliaApp.Web.Model
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Nick { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
