using DetectiveGame.Domain.Entities.Identity;
using DetectiveGame.Domain.Interfaces.Repositories;

namespace DataAccess.EFCore.Repositories
{
	public class SiteUserRepository : GenericRepository<SiteUser>, ISiteUserRepository
	{
		public SiteUserRepository(ApplicationContext context) : base(context)
		{
		}
	}
}
