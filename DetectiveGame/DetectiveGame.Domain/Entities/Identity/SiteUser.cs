using Microsoft.AspNetCore.Identity;

namespace DetectiveGame.Domain.Entities.Identity
{
	public class SiteUser : IdentityUser
	{
		public SiteRole Role { get; set; }

		public SiteUser()
		{
			Role = SiteRole.Detective;
		}

		public override bool Equals(object? obj)
		{
			return obj is SiteUser user
				&& !string.IsNullOrWhiteSpace(user.Id)
				&& Id == user.Id;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
