namespace DetectiveGame.Domain.Entities.Team
{
	public class DetectiveTeam
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public List<Detective> Detectives { get; set; }

		public override bool Equals(object? obj)
		{
			return obj is DetectiveTeam detectiveTeam && Id == detectiveTeam.Id;
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}
