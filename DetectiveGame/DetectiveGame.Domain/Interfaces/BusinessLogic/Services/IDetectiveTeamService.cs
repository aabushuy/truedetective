using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Entities.Team;

namespace DetectiveGame.Domain.Interfaces.BusinessLogic.Services
{
	public interface IDetectiveTeamService
	{
		void CreateTeam(DetectiveTeam team, DetectiveGameUser user, out OperationResult result);

		void AddParticipant(int teamId, int participantId, TeamRole teamRole, out OperationResult result);

		void AddParticipant(int teamId, DetectiveGameUser user, TeamRole teamRole, out OperationResult result);

		void RemoveParticipant(int teamId, DetectiveGameUser user, out OperationResult result);

		void RemoveTeam(int teamId, out OperationResult result);

		DetectiveTeam? GetUserTeam(DetectiveGameUser user);
	}
}
