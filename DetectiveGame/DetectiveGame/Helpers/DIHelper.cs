using DataAccess.EFCore.Repositories;
using DetectiveGame.BusinessLogic.Services;
using DetectiveGame.Domain.Interfaces.Repositories;
using DetectiveGame.Domain.Interfaces.Services;

namespace DetectiveGame.Helpers
{
	public class DIHelper
	{
		public static void RegisterDependecy(WebApplicationBuilder builder)
		{
			// Repositories
			builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			builder.Services.AddTransient(typeof(ISiteUserRepository), typeof(SiteUserRepository));
			
			builder.Services.AddScoped(typeof(IDetectiveRepository), typeof(DetectiveRepository));
			builder.Services.AddScoped(typeof(IDetectiveTeamRepository), typeof(DetectiveTeamRepository));

			// Services
			builder.Services.AddScoped<ISiteUserService, SiteUserService>();
			builder.Services.AddScoped<IDetectiveTeamService, DetectiveTeamService>();
		}
	}
}
