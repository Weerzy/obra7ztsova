using System.ComponentModel.DataAnnotations;


namespace OrgManagmentApp.Models
{
    
    public class User
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string? MiddleName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [Phone]
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string Login { get; set; }

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}