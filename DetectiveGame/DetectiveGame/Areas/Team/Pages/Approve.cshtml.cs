using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Entities.Team;
using DetectiveGame.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DetectiveGame.Areas.Team.Pages
{
	public class ApproveModel : TeamPageModel
	{
		protected override Breadcrumb ChildPage => CreateChildBreadcrumb("Approve Team Member", "Approve");

		[BindProperty]
		public bool IsApproved { get; set; }

		[BindProperty]
		public Detective ApproveDetective { get; private set; }

		public ApproveModel(
			ISiteUserService siteUserService,
			IDetectiveTeamService detectiveTeamService)
			: base(siteUserService, detectiveTeamService)
		{
		}

		public void OnGet(int Id)
		{
			ApproveDetective = _detectiveTeamService.GetDetective(Id);
			if (ApproveDetective == null)
			{
				ModelState.AddModelError("Detective", $"Can't find a detective with number {Id}");
			}
		}

		public IActionResult OnPost(Detective detective)
		{
			detective = _detectiveTeamService.GetDetective(detective.Id);

			if (CurrentDetective.IsOwner && CurrentDetective.TeamId == detective.TeamId)
			{
				var result = _detectiveTeamService.ApproveDetective(detective);
				IsApproved = result.IsSuccess;

				if (!IsApproved)
				{
					ModelState.AddModelError("Team", result.Message);
				}
			}
			else 
			{
				ModelState.AddModelError("Team", "Permission denied.");
			}

			return IsApproved
				? RedirectToPage("./Index")
				: Page();
		}
	}
}
