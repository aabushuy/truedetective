using DetectiveGame.Domain.Entities.Team;
using DetectiveGame.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.EFCore.Repositories
{
	public class DetectiveTeamRepository : GenericRepository<DetectiveTeam>, IDetectiveTeamRepository
	{
		public DetectiveTeamRepository(ApplicationContext context) : base(context)
		{
		}

		public override IEnumerable<DetectiveTeam> Find(Expression<Func<DetectiveTeam, bool>> expression)
		{
			return _context.Set<DetectiveTeam>()
				.Where(expression)
				.Include(d => d.Detectives);
		}

		public DetectiveTeam GetFullTeamInfo(DetectiveTeam detectiveTeam)
		{
			detectiveTeam.Detectives = _context.Set<Detective>()
				.Where(d => d.TeamId == detectiveTeam.Id)
				.Include(d => d.Team)
				.Include(d => d.User)
				.ToList();

			return detectiveTeam;
		}
	}
}
