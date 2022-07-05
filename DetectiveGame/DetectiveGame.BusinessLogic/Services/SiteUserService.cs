using DetectiveGame.Domain.Entities.Identity;
using DetectiveGame.Domain.Interfaces.Repositories;
using DetectiveGame.Domain.Interfaces.Services;
using System.Security.Claims;

namespace DetectiveGame.BusinessLogic.Services
{
	public class SiteUserService : ServiceBase, ISiteUserService
	{
		private readonly ISiteUserRepository _siteUserRepository;

		public SiteUserService(ISiteUserRepository siteUserRepository)
		{
			_siteUserRepository = siteUserRepository;
		}

		public SiteUser GetCurrentUser(ClaimsPrincipal claimsPrincipal)
		{
			var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (userId == null)
			{
				throw new KeyNotFoundException($"No such user");
			}

			return GetUserById(userId);
		}

		public SiteUser GetUserById(string id)
		{
			var user = _siteUserRepository.Find(u => u.Id == id).FirstOrDefault();
			if (user == null)
			{
				throw new KeyNotFoundException($"No such user with id={id}");
			}

			return user;
		}
	}
}
