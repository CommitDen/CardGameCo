using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardGameCo.Models
{
    [Table("AspNetUsers")]
	public class User
	{
        public User()
        {
        }

        public User(string id, string name, string email, string password)
        {
            Id = id;
            UserName = name;
            Email = email;
            Password = password;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Compare("Id")]
        public string Id { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 10, ErrorMessage ="Username must be atleast 10 characters long!")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
            ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; } = false;

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[~!@#$%^&*()_+`\-={}\[\]:"";'<>?,./])[A-Za-z\d~!@#$%^&*()_+`\-={}\[\]:"";'<>?,./]{8,}$",
            ErrorMessage = "The password must be at least 8 characters long and contain at least one letter, one digit, and one special character.")]
        public string Password { get; set; }

        [Required]
        [Compare("Email", ErrorMessage = "The email and email confirmation do not match.")]
        [NotMapped]
        public string EmailVerify { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The password and password confirmation do not match.")]
        [NotMapped]
        public string PasswordVerify { get; set; }

        [NotMapped]
        public string EmailState { get { return (EmailConfirmed) ? "Confirmed" : "Pending"; } }

	}
}

