using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DetectiveGame.Areas.Team.Pages
{
	public class CreateModel : TeamPageModel
	{
		protected override Breadcrumb ChildPage => CreateChildBreadcrumb("Create Team", "Create");

		public CreateModel(ISiteUserService siteUserService, IDetectiveTeamService detectiveTeamService)
			: base(siteUserService, detectiveTeamService)
		{
		}

		[BindProperty]
		public InputModel Input { get; set; }

		public class InputModel
		{
			[Required]
			public string TeamName { get; set; }
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

			var result = _detectiveTeamService.CreateTeam(Input.TeamName, CurrentDetective);
			if (!result.IsSuccess)
			{
				ModelState.AddModelError("Team", result.Message);
			}

			return result.IsSuccess
				? RedirectToPage("./Index")
				: Page();
		}
	}
}
