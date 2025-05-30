using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; } 

        [Required]
        [StringLength(50)]
        [Column("Username", TypeName = "varchar")]
        public string Username { get; set; }

        [Required]
        [Column("Password", TypeName = "varchar")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [Column("Email", TypeName = "varchar")]
        [EmailAddress] 
        [StringLength(355)]
        public string Email { get; set; }

        [Column("TrackingNumber", TypeName = "varchar")]
        [StringLength(355)]
        public string? TrackingNumber { get; set; }

        [Column("CreatedOn", TypeName = "timestamptz")]

        public DateTime CreatedOn { get; set; }

        [Column("LastLogin", TypeName = "timestamptz")]
        public DateTime? LastLogin { get; set; }
    }
}
