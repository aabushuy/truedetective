using DataAccess.EFCore.Repositories;
using DetectiveGame.BusinessLogic.Services;
using DetectiveGame.Domain.Interfaces.BusinessLogic.Services;
using DetectiveGame.Domain.Interfaces.Repositories;

namespace DetectiveGame.Helpers
{
	public class DIHelper
	{
		public static void RegisterDependecy(WebApplicationBuilder builder)
		{
			// Repositories
			builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			builder.Services.AddTransient(typeof(IDetectiveTeamRepository), typeof(DetectiveTeamRepository));
			builder.Services.AddTransient(typeof(IDetectiveTeamParticipantRepository), typeof(DetectiveTeamParticipantRepository));

			// Serices
			builder.Services.AddTransient(typeof(IDetectiveTeamService), typeof(DetectiveTeamService));
			builder.Services.AddTransient(typeof(IGameUserService), typeof(GameUserService));

		}
	}
}
