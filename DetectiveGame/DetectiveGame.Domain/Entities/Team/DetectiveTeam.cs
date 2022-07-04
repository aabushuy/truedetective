namespace DetectiveGame.Domain.Entities.Team
{
	public class DetectiveTeam
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public List<DetectiveTeamParticipant> DetectiveTeamParticipants { get; set; }

		public DetectiveTeam()
		{
			DetectiveTeamParticipants = new List<DetectiveTeamParticipant>();
		}
	}
}
