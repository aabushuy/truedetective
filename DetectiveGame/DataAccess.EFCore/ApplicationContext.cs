using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Entities.Team;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(string connectionString) : base(GetOptions(connectionString))
		{
		}

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}

		public virtual DbSet<DetectiveGameUser> DetectiveGameUsers { get; set; }

		public virtual DbSet<DetectiveTeam> DetectiveTeams { get; set; }

		public virtual DbSet<DetectiveTeamRole> DetectiveTeamRoles { get; set; }

		public virtual DbSet<DetectiveTeamParticipant> DetectiveTeamParticipants { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("GameIdentityUserClaim").HasKey(p => new { p.Id });
			modelBuilder.Entity<IdentityUserToken<string>>().ToTable("GameIdentityUserToken").HasKey(p => new { p.UserId });

			modelBuilder.Entity<DetectiveTeamRole>().HasData(
				new DetectiveTeamRole() { Id = 1, Name = "owner" },
				new DetectiveTeamRole() { Id = 2, Name = "detective" },
				new DetectiveTeamRole() { Id = 3, Name = "pending" });
		}

		private static DbContextOptions GetOptions(string connectionString)
		{
			return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
		}
	}
}
