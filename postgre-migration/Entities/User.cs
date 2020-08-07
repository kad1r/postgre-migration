using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace postgre_migration.Entities
{
	public class User
	{
		public User()
		{
			Articles = new HashSet<Article>();
		}

		[Key]
		public int Id { get; set; }

		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime DateCreated { get; set; } = DateTime.UtcNow;
		public DateTime? DateUpdated { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;

		public ICollection<Article> Articles { get; set; }
	}
}
