using DataAccess.EFCore.Repositories;
using DetectiveGame.Domain.Interfaces;

namespace DetectiveGame.Helpers
{
	public class DIHelper
	{
		public static void RegisterDependecy(WebApplicationBuilder builder)
		{
			// Repositories
			builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
		}
	}
}
