using DataAccess.EFCore;
using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Interfaces.BusinessLogic.Services;
using System.Security.Claims;

namespace DetectiveGame.BusinessLogic.Services
{
	public class GameUserService : IGameUserService
	{
		private readonly ApplicationContext _applicationContext;

		public GameUserService(ApplicationContext applicationContext)
		{
			_applicationContext = applicationContext;
		}

		public DetectiveGameUser GetUser(ClaimsPrincipal identity)
		{
			var claim = identity.FindFirst(ClaimTypes.NameIdentifier);

			return _applicationContext.DetectiveGameUsers.Find(claim?.Value ?? string.Empty);
		}
	}
}
