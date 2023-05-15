using System;

namespace CardGameCo.Models
{
	public class User
	{
		public User()
		{
		}

        public User(long id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }


        public Int64 Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

	}
}

