using DetectiveGame.Domain.Entities.Team;
using DetectiveGame.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.EFCore.Repositories
{
	public class DetectiveRepository : GenericRepository<Detective>, IDetectiveRepository
	{
		public DetectiveRepository(ApplicationContext context) : base(context)
		{
		}

		public override IEnumerable<Detective> Find(Expression<Func<Detective, bool>> expression)
		{
			return _context.Set<Detective>()
				.Where(expression)
				.Include(d => d.Team)
				.Include(d => d.User);
		}
	}
}
