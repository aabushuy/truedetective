using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Entities.Identity;
using DetectiveGame.Domain.Entities.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectiveGame.Domain.Interfaces.Services
{
	public interface IDetectiveTeamService
	{
		IList<DetectiveTeam> Teams { get; }

		Detective GetDetective(SiteUser siteUser);

		Detective? GetDetective(int detectiveId);

		DetectiveTeam GetTeam(int teamId);

		OperationResult CreateTeam(string teamName, Detective owner);

		OperationResult JoinTeam(int teamId, Detective detective);

		OperationResult ApproveDetective(Detective detective);

		OperationResult LeaveTeam(Detective detective);
	}
}
