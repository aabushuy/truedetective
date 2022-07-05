using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Entities.Team;
using DetectiveGame.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DetectiveGame.Areas.Team.Pages
{
	public class IndexModel : TeamPageModel
	{
		protected override Breadcrumb ChildPage => null;

		[BindProperty]
		public DetectiveTeam? Team { get; set; }

		[BindProperty]
		public IList<DetectiveTeam> Teams => _detectiveTeamService.Teams;

		public IndexModel(ISiteUserService siteUserService,IDetectiveTeamService detectiveTeamService)
			: base(siteUserService, detectiveTeamService)
		{
		}

		public void OnGet()
		{
			if (CurrentDetective != null && CurrentDetective.Team != null)
			{
				Team = _detectiveTeamService.GetTeam(CurrentDetective.Team.Id);
			}
		}
	}
}
