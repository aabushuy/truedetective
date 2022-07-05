using DetectiveGame.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DetectiveGame.Domain.Interfaces.Services
{
	public interface ISiteUserService
	{
		SiteUser GetCurrentUser(ClaimsPrincipal claimsPrincipal);

		SiteUser GetUserById(string id);
	}
}
