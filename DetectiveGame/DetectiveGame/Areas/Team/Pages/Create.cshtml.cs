using DetectiveGame.Domain.Interfaces.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace DetectiveGame.Areas.Team.Pages
{
	public class CreateModel : TeamPageModel
	{
		public CreateModel(IDetectiveTeamService detectiveTeamService, IGameUserService gameUserService)
			: base(detectiveTeamService, gameUserService)
		{
		}

		public void OnGet()
		{
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_detectiveTeamService.CreateTeam(Team, CurrentUser, out var result);
			if (!result.IsSuccess)
			{
				ModelState.AddModelError("Team", result.Message);
				return Page();
			}

			return RedirectToPage("./Index");
		}
	}
}
