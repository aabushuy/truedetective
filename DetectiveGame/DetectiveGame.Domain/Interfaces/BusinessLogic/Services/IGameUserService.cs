using DetectiveGame.Domain.Entities;
using System.Security.Claims;

namespace DetectiveGame.Domain.Interfaces.BusinessLogic.Services
{
	public interface IGameUserService
	{
		DetectiveGameUser GetUser(ClaimsPrincipal identity);
	}
}
