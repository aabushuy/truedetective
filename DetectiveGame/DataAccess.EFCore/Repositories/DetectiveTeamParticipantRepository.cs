using DetectiveGame.Domain.Entities.Team;
using DetectiveGame.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.EFCore.Repositories
{
	public class DetectiveTeamParticipantRepository : GenericRepository<DetectiveTeamParticipant>, IDetectiveTeamParticipantRepository
	{
		public DetectiveTeamParticipantRepository(ApplicationContext context) : base(context)
		{
		}

		public override DetectiveTeamParticipant GetById(int id)
		{
			return Find(p => p.Id == id).FirstOrDefault();
		}

		public override IEnumerable<DetectiveTeamParticipant> Find(Expression<Func<DetectiveTeamParticipant, bool>> expression)
		{
			return _context.Set<DetectiveTeamParticipant>()
				.Where(expression)
				.Include(tp => tp.DetectiveTeamRole)
				.Include(tp => tp.DetectiveGameUser)
				.Include(tp => tp.DetectiveTeam);
		}
	}
}
