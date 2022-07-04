using DetectiveGame.Domain.Interfaces.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DetectiveGame.Areas.Team.Pages
{
	public class ApproveModel : TeamPageModel
	{
		public ApproveModel(IDetectiveTeamService detectiveTeamService, IGameUserService gameUserService)
			: base(detectiveTeamService, gameUserService)
		{
		}

		public IActionResult OnGet(int id)
		{
			if (!IsCurrentUserOwner)
			{
				return RedirectToPage("./Index");
			}

			_detectiveTeamService.AddParticipant(Team.Id, id, Domain.Entities.Team.TeamRole.Detective, out var result);

			return result.IsSuccess
				? RedirectToPage("./Index")
				: Page();
		}
	}
}
