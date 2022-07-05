using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DetectiveGame.Areas.Team.Pages
{
	public class LeaveModel : TeamPageModel
	{
		[BindProperty]
		public bool IsLeft { get; private set; }

		protected override Breadcrumb ChildPage => CreateChildBreadcrumb("Leave Team", "Leave");

		public LeaveModel(ISiteUserService siteUserService, IDetectiveTeamService detectiveTeamService)
			: base(siteUserService, detectiveTeamService)
		{
		}

		public void OnGet()
		{
		}
		public IActionResult OnPost()
		{
			var result = _detectiveTeamService.LeaveTeam(CurrentDetective);
			IsLeft = result.IsSuccess;

			if (!IsLeft)
			{
				ModelState.AddModelError("Detective", result.Message);
			}

			return IsLeft
				? RedirectToPage("./Index")
				: Page();
		}
	}
}
