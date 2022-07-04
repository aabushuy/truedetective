using DataAccess.EFCore.Repositories;
using DetectiveGame.Domain.Entities.Team;
using DetectiveGame.Domain.Interfaces.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Tests
{
	public class DetectiveTeamRepositoryTest : RepositoryTestBase
	{
		private IDetectiveTeamRepository _repository;

		[SetUp]
		public void Setup()
		{
			_repository = new DetectiveTeamRepository(DbContext);
		}

		[TearDown]
		public void Clean()
		{
			//_repository.RemoveRange(_repository.GetAll());
		}

		[Test]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void DetectiveTeamRoles_RoleId_Role(int id)
		{
			var role = DbContext.DetectiveTeamRoles.FirstOrDefault(r => r.Id == id);
			
			Assert.NotNull(role, $"Expected role with id={id}");
		}

		public static IEnumerable<DetectiveTeam> DetectiveTeamTestSource
		{
			get
			{
				yield return new DetectiveTeam() { Name = "Test without id", Description = "Description" };
				yield return new DetectiveTeam() { Name = "Test Team", Description = "" };
			}
		}

		[Test]
		[TestCaseSource("DetectiveTeamTestSource")]
		public void CreateTeam_TeamObject_Created(DetectiveTeam detectiveTeam)
		{
			_repository.Add(detectiveTeam);
			_repository.Save();

			Assert.True(detectiveTeam.Id > 0);
		}		
	}
}