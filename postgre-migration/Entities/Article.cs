using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace postgre_migration.Entities
{
	public class Article
	{
		[Key]
		public int Id { get; set; }

		public int UserId { get; set; }
		public string Title { get; set; }
		public string Summary { get; set; }
		public string Description { get; set; }
		public DateTime DatePublished { get; set; }
		public DateTime DateCreated { get; set; } = DateTime.UtcNow;
		public DateTime DateUpdated { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;

		[ForeignKey("UserId")]
		public virtual User User { get; set; }
	}
}
