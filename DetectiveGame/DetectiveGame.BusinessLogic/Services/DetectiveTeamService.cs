using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Entities.Identity;
using DetectiveGame.Domain.Entities.Team;
using DetectiveGame.Domain.Interfaces.Repositories;
using DetectiveGame.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectiveGame.BusinessLogic.Services
{
	public class DetectiveTeamService : ServiceBase, IDetectiveTeamService
	{
		private readonly IDetectiveRepository _detectiveRepository;
		private readonly IDetectiveTeamRepository _detectiveTeamRepository;

		public IList<DetectiveTeam> Teams => _detectiveTeamRepository.GetAll().OrderBy(t => t.Name).ToList();

		public DetectiveTeamService(IDetectiveRepository detectiveRepository, IDetectiveTeamRepository detectiveTeamRepository)
		{
			_detectiveRepository = detectiveRepository;
			_detectiveTeamRepository = detectiveTeamRepository;
		}

		public Detective GetDetective(SiteUser siteUser)
		{
			var detective = _detectiveRepository
				.Find(d => d.SiteUserId == siteUser.Id)
				.FirstOrDefault();

			if (detective == null)
			{
				detective = new Detective()
				{
					User = siteUser
				};

				_detectiveRepository.Add(detective);
				_detectiveRepository.Save();

				return GetDetective(siteUser);
			}

			return detective;
		}

		public Detective? GetDetective(int detectiveId)
		{
			return _detectiveRepository
				.Find(d => d.Id == detectiveId)
				.FirstOrDefault();
		}

		public DetectiveTeam GetTeam(int teamId)
		{
			var team = _detectiveTeamRepository.GetById(teamId);

			return _detectiveTeamRepository.GetFullTeamInfo(team);
		}

		public OperationResult CreateTeam(string teamName, Detective owner)
		{
			var isExisting = _detectiveTeamRepository
				.Find(dt => dt.Name == teamName)
				.Any();

			if (isExisting)
			{
				return OperationResult.Fail($"The team [{teamName}] exists. Please use another name");
			}

			var team = new DetectiveTeam()
			{
				Name = teamName,
				Detectives = new List<Detective>() { owner }
			};

			owner.Team = team;
			owner.IsOwner = true;

			try
			{
				_detectiveTeamRepository.Add(team);
				_detectiveRepository.Update(owner);

				_detectiveTeamRepository.Save();
				_detectiveRepository.Save();

				return OperationResult.Success();
			}
			catch (Exception ex)
			{
				return OperationResult.Fail(ex.Message);
			}
		}

		public OperationResult JoinTeam(int teamId, Detective detective)
		{
			if (detective.Team != null && _detectiveTeamRepository.Find(dt => dt.Detectives.Contains(detective)).Any())
			{
				return OperationResult.Fail($"{detective.User.UserName} is already in the team.");
			}

			var team = _detectiveTeamRepository.Find(dt => dt.Id == teamId).FirstOrDefault();
			if (team == null)
			{
				return OperationResult.Fail($"Team [{teamId}] is not found.");
			}

			detective.Team = team;
			detective.IsOwner = !_detectiveRepository
					.Find(d => d.TeamId == teamId)
					.Any();
			detective.IsAwaiting = !detective.IsOwner;

			_detectiveRepository.Update(detective);
			_detectiveRepository.Save();

			return OperationResult.Success();
		}

		public OperationResult ApproveDetective(Detective detective)
		{
			detective.IsAwaiting = false;
			
			_detectiveRepository.Update(detective);
			_detectiveRepository.Save();

			return OperationResult.Success();
		}

		public OperationResult LeaveTeam(Detective detective)
		{
			if (detective.IsOwner)
			{
				if (_detectiveRepository
					.Find(d => d.TeamId == detective.TeamId.Value && d.Id != detective.Id)
					.Any())
				{
					return OperationResult.Fail("A captain will be the last person to leave a ship alive before its sinking or utter destruction");
				}
			}

			detective.Team = null;
			
			_detectiveRepository.Update(detective);
			_detectiveRepository.Save();

			return OperationResult.Success();
		}
	}
}
