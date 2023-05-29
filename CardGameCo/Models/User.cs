using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CardGameCo.Models
{
    [Table("AspNetUsers")]
	public class User : IdentityUser
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
            PasswordHash = Password; //Hashing.SHA256(Cleared(pass));
        }

        [Required]
        [StringLength(50,MinimumLength = 10, ErrorMessage ="Username must be atleast 10 characters long!")]
        public override string UserName { get; set; }

        [Required]
        [EmailAddress]
        public override string Email { get; set; }

        public override bool EmailConfirmed { get; set; } = false;

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[~!@#$%^&*()_+`\-={}\[\]:"";'<>?,./])[A-Za-z\d~!@#$%^&*()_+`\-={}\[\]:"";'<>?,./]{8,}$",
            ErrorMessage = "The password must be at least 8 characters long and contain at least one letter, one digit, and one special character.")]
        [NotMapped]
        public string Password { get { return PasswordHash; } set { PasswordHash = value; } }

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

