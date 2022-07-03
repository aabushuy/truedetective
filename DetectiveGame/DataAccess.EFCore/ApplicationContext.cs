using DetectiveGame.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}

		public virtual DbSet<DetectiveGameUser> DetectiveGameUsers { get; set; }
	}
}
