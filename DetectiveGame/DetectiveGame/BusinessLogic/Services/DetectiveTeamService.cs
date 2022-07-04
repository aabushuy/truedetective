using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Entities.Team;
using DetectiveGame.Domain.Interfaces.BusinessLogic.Services;
using DetectiveGame.Domain.Interfaces.Repositories;

namespace DetectiveGame.BusinessLogic.Services
{
	public class DetectiveTeamService : IDetectiveTeamService
	{
		private readonly IDetectiveTeamRepository _detectiveTeamRepository;
		private readonly IDetectiveTeamParticipantRepository _detectiveTeamParticipantRepository;

		public DetectiveTeamService(
			IDetectiveTeamRepository detectiveTeamRepository,
			IDetectiveTeamParticipantRepository detectiveTeamParticipantRepository)
		{
			_detectiveTeamRepository = detectiveTeamRepository;
			_detectiveTeamParticipantRepository = detectiveTeamParticipantRepository;
		}

		public void CreateTeam(DetectiveTeam team, DetectiveGameUser user, out OperationResult result)
		{
			var exsistingTeam = _detectiveTeamRepository
				.Find(t => t.Name == team.Name)
				.FirstOrDefault();

			if (exsistingTeam != null)
			{
				result = OperationResult.Fail($"[{team.Name}] already exists. Please choose another name and try again.");
				return;
			}

			_detectiveTeamRepository.Add(team);
			_detectiveTeamRepository.Save();

			AddParticipant(team.Id, user, TeamRole.Owner, out result);
		}

		public void AddParticipant(int teamId, int participantId, TeamRole teamRole, out OperationResult result)
		{
			var user = _detectiveTeamParticipantRepository.GetById(participantId).DetectiveGameUser;
			AddParticipant(teamId, user, teamRole, out result);
		}

		public void AddParticipant(int teamId, DetectiveGameUser user, TeamRole teamRole, out OperationResult result)
		{
			var team = _detectiveTeamRepository.GetById(teamId);
			if (team == null)
			{
				result = OperationResult.Fail($"No such team [{teamId}]");
				return;
			}

			var participant =  team.DetectiveTeamParticipants.FirstOrDefault(p => p.DetectiveGameUserId == user.Id);
			if (participant != null)
			{
				if (participant.DetectiveTeamRole.Id == (int)TeamRole.Pending)
				{
					participant.DetectiveTeamRoleId = (int)TeamRole.Detective;

					_detectiveTeamParticipantRepository.Update(participant);
					_detectiveTeamParticipantRepository.Save();

					result = OperationResult.Success();
					return;
				}

				result = OperationResult.Fail($"Such member [{user.UserName}] is already in the team [{teamId}]");
				return;
			}

			participant = new DetectiveTeamParticipant()
			{
				DetectiveGameUserId = user.Id,
				DetectiveTeamId = team.Id,
				DetectiveTeamRoleId = (int)teamRole
			};
			_detectiveTeamParticipantRepository.Add(participant);
			_detectiveTeamParticipantRepository.Save();

			result = OperationResult.Success();
		}

		public DetectiveTeam? GetUserTeam(DetectiveGameUser user)
		{
			var participant = _detectiveTeamParticipantRepository
				.Find(p => p.DetectiveGameUser.Equals(user))
				.FirstOrDefault();
			
			return participant != null
				? _detectiveTeamRepository.GetById(participant.DetectiveTeam.Id)
				: null;
		}

		public void RemoveTeam(int teamId, out OperationResult result)
		{
			throw new NotImplementedException();
		}

		public void RemoveParticipant(int teamId, DetectiveGameUser user, out OperationResult result)
		{
			throw new NotImplementedException();
		}
	}
}
