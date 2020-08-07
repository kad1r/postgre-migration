using Microsoft.EntityFrameworkCore;
using postgre_migration.Entities;
using System.Linq;

namespace postgre_migration.Context
{
	public partial class BlogContext : DbContext
	{
		public BlogContext()
		{
		}

		public BlogContext(DbContextOptions<BlogContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var foreignKeys = modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys());

			foreach (var relationShip in foreignKeys)
			{
				relationShip.DeleteBehavior = DeleteBehavior.Restrict;
			}

			modelBuilder.Entity<User>()
				.Property(x => x.DateCreated)
				.HasColumnType("timestamp");
			modelBuilder.Entity<User>()
				.Property(x => x.DateUpdated)
				.HasColumnType("timestamp");
			modelBuilder.Entity<Article>()
				.Property(x => x.DateCreated)
				.HasColumnType("timestamp");
			modelBuilder.Entity<Article>()
				.Property(x => x.DateUpdated)
				.HasColumnType("timestamp");
			modelBuilder.Entity<Article>()
				.Property(x => x.DatePublished)
				.HasColumnType("timestamp");

			//foreach (var item in modelBuilder.Model.GetEntityTypes())
			//{
			//    if (item.FindDeclaredProperty("Id") != null)
			//    {
			//        item.FindDeclaredProperty("Id").ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;
			//    }
			//}

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
		public virtual DbSet<Article> Articles { get; set; }
		public virtual DbSet<User> Users { get; set; }
	}
}
