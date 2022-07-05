using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Entities.Team;
using DetectiveGame.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DetectiveGame.Areas.Team.Pages
{
	public abstract class TeamPageModel : PageModel
	{
		protected readonly ISiteUserService _siteUserService;
		protected readonly IDetectiveTeamService _detectiveTeamService;

		protected abstract Breadcrumb ChildPage { get; }

		[BindProperty]
		public List<Breadcrumb> Breadcrumbs => GetBreadcrumbs();

		public Detective CurrentDetective
		{ 
			get 
			{
				var user = _siteUserService.GetCurrentUser(User);
				return _detectiveTeamService.GetDetective(user); 
			} 
		}

		public TeamPageModel(ISiteUserService siteUserService, IDetectiveTeamService detectiveTeamService)
		{
			_siteUserService = siteUserService;
			_detectiveTeamService = detectiveTeamService;
		}

		protected List<Breadcrumb> GetBreadcrumbs()
		{
			var breadcrumbs = new List<Breadcrumb>()
			{
				new Breadcrumb(){ AspArea ="Team", AspPage="./Index", LinkName="Team"}
			};

			if (ChildPage != null)
			{
				breadcrumbs.ForEach(b => b.IsActive = false);
				breadcrumbs.Add(ChildPage);
			}

			return breadcrumbs;
		}

		protected Breadcrumb CreateChildBreadcrumb(string linkName, string aspPage)
		{
			return new Breadcrumb() { AspArea = "Team", AspPage = $"./{aspPage}", LinkName = linkName, IsActive = true };
		}
	}
}
