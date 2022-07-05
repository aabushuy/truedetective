using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Entities.Team;
using DetectiveGame.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DetectiveGame.Areas.Team.Pages
{
	public class ExcludeModel : TeamPageModel
	{
		protected override Breadcrumb ChildPage => CreateChildBreadcrumb("Exclude Team Member", "Exclude");

		public ExcludeModel(ISiteUserService siteUserService, IDetectiveTeamService detectiveTeamService)
			: base(siteUserService, detectiveTeamService)
		{
		}

		[BindProperty]
		public bool IsExcluded{ get; private set; }

		[BindProperty]
		public Detective ExcludedDetective { get; set; }

		public void OnGet(int id)
		{
			ExcludedDetective = _detectiveTeamService.GetDetective(id);
			if (ExcludedDetective == null)
			{
				ModelState.AddModelError("Detective", $"No such detective.");
			}
		}

		public IActionResult OnPost()
		{
			var detective = _detectiveTeamService.GetDetective(ExcludedDetective.Id);

			if (CurrentDetective.IsOwner && CurrentDetective.TeamId == detective.TeamId)
			{
				var result = _detectiveTeamService.LeaveTeam(detective);
				IsExcluded = result.IsSuccess;

				if (!IsExcluded)
				{
					ModelState.AddModelError("Team", result.Message);
				}
			}
			else
			{
				ModelState.AddModelError("Team", "Permission denied.");
			}

			return IsExcluded
				? RedirectToPage("./Index")
				: Page();
		}
	}
}
