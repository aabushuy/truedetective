using DetectiveGame.Domain.Entities.Identity;

namespace DetectiveGame.Domain.Entities.Team
{
	public class Detective
	{
		public int Id { get; set; }

		public string SiteUserId { get; set; }

		public int? TeamId { get; set; }

		public bool IsOwner { get; set; }

		public bool IsAwaiting { get; set; }

		public SiteUser User { get; set; }

		public DetectiveTeam? Team { get; set; }

		public override bool Equals(object? obj)
		{
			return obj is Detective detective && Id == detective.Id;
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}
