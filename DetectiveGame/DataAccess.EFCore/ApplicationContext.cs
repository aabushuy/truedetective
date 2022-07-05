using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Entities.Identity;
using DetectiveGame.Domain.Entities.Team;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(string connectionString) : base(GetOptions(connectionString))
		{
			Database.EnsureCreated();
		}

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public virtual DbSet<SiteUser> SiteUsers { get; set; }

		public virtual DbSet<Detective> Detectives { get; set; }

		public virtual DbSet<DetectiveTeam> DetectiveTeams { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("SiteIdentityUserClaim").HasKey(p => new { p.Id });
			modelBuilder.Entity<IdentityUserToken<string>>().ToTable("SiteIdentityUserToken").HasKey(p => new { p.UserId });
		}

		private static DbContextOptions GetOptions(string connectionString)
		{
			return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
		}
	}
}
