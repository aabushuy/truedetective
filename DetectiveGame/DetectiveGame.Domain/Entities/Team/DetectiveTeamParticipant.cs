namespace DetectiveGame.Domain.Entities.Team
{
	public class DetectiveTeamParticipant
	{
		public int Id { get; set; }

		public int DetectiveTeamId { get; set; }

		public string DetectiveGameUserId { get; set; }

		public int DetectiveTeamRoleId { get; set; }

		public DetectiveTeam DetectiveTeam { get; set; }

		public DetectiveGameUser DetectiveGameUser { get; set; }

		public DetectiveTeamRole DetectiveTeamRole { get; set; }
	}
}
