using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Entities.Team;
using DetectiveGame.Domain.Interfaces.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DetectiveGame.Areas.Team.Pages
{
	public class TeamPageModel : PageModel
	{
		protected readonly IDetectiveTeamService _detectiveTeamService;
		protected readonly IGameUserService _gameUserService;

		[BindProperty]
		public DetectiveGameUser CurrentUser => _gameUserService.GetUser(User);

		[BindProperty]
		public bool IsCurrentUserOwner => Team.DetectiveTeamParticipants
			.Where(p => p.DetectiveTeamRole.Id == (int)TeamRole.Owner)
			.Any(p => p.DetectiveGameUser.Equals(CurrentUser));

		[BindProperty]
		public DetectiveTeam Team => _detectiveTeamService.GetUserTeam(CurrentUser);

		public TeamPageModel(
			IDetectiveTeamService detectiveTeamService,
			IGameUserService gameUserService)
		{
			_detectiveTeamService = detectiveTeamService;
			_gameUserService = gameUserService;
		}
	}
}
