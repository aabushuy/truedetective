using DetectiveGame.Domain.Interfaces.BusinessLogic.Services;

namespace DetectiveGame.Areas.Team.Pages
{
	public class IndexModel : TeamPageModel
	{
		public IndexModel(IDetectiveTeamService detectiveTeamService, IGameUserService gameUserService) 
			: base(detectiveTeamService, gameUserService)
		{
		}

		public void OnGet()
		{
		}
	}
}
