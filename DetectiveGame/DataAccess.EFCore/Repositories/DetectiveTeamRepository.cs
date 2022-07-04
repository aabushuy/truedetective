using DetectiveGame.Domain.Entities.Team;
using DetectiveGame.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore.Repositories
{
	public class DetectiveTeamRepository : GenericRepository<DetectiveTeam>, IDetectiveTeamRepository
	{
		public DetectiveTeamRepository(ApplicationContext context) : base(context)
		{
		}

		public override DetectiveTeam GetById(int id)
		{
			return _context.Set<DetectiveTeam>()
				.Where(dt => dt.Id == id)
				.Include(dt => dt.DetectiveTeamParticipants)
				.ThenInclude(tp => tp.DetectiveTeamRole)
				.Include(tp => tp.DetectiveTeamParticipants)
				.ThenInclude(dt => dt.DetectiveGameUser)
				.First();
		}
	}
}
