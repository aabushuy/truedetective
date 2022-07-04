using Microsoft.AspNetCore.Identity;

namespace DetectiveGame.Domain.Entities
{
	public class DetectiveGameUser : IdentityUser
	{
		public override bool Equals(object? obj)
		{
			return obj is DetectiveGameUser detective
				&& !string.IsNullOrWhiteSpace(detective.Id)
				&& Id == detective.Id;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
