using DataAccess.EFCore;

namespace DataAccess.Tests
{
	public class RepositoryTestBase
	{
		protected ApplicationContext DbContext;

		public RepositoryTestBase()
		{
			DbContext = new ApplicationContext("Server=localhost;Database=LocalDetectiveTest;Trusted_Connection=True;MultipleActiveResultSets=true");
			DbContext.Database.EnsureCreated();
		}
	}
}
