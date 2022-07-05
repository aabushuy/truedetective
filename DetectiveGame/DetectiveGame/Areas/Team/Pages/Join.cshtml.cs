using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Entities.Team;
using DetectiveGame.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DetectiveGame.Areas.Team.Pages
{
	public class JoinModel : TeamPageModel
	{
		protected override Breadcrumb ChildPage => CreateChildBreadcrumb("Join Team", "Join");

		public JoinModel(ISiteUserService siteUserService, IDetectiveTeamService detectiveTeamService)
			: base(siteUserService, detectiveTeamService)
		{
		}

		[BindProperty]
		public DetectiveTeam Team => CurrentDetective.Team;

		[BindProperty]
		public OperationResult Result { get; private set; }

		public IActionResult OnGet(int id)
		{
			Result = _detectiveTeamService.JoinTeam(id, CurrentDetective);

			return Result.IsSuccess
				? RedirectToPage("./Index")
				: Page();
		}
	}
}
