using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class User
    {
        // Primary Key
        [Key]
        public int UserId { get; set; }  // Use 'UserId' for better readability

        [Required]
        [StringLength(50)]
        [Column("username", TypeName = "varchar")]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [EmailAddress] // This ensures the value is a valid email format
        [StringLength(355)]
        public string Email { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } // Use DateTime for timestamp

        public DateTime? LastLogin { get; set; } // Nullable to allow no last login value
    }
}
