namespace DetectiveGame.Domain.Entities
{
	public class OperationResult
	{
		public bool IsSuccess { get; }

		public string Message { get; }

		public OperationResult(bool result) : this(result, string.Empty)
		{
		}

		public OperationResult(bool result, string message)
		{
			IsSuccess = result;
			Message = message;
		}

		public static OperationResult Create(bool result)
		{
			return new OperationResult(result);
		}

		public static OperationResult Create(bool result, string message)
		{
			return new OperationResult(result, message);
		}

		public static OperationResult Success()
		{
			return new OperationResult(true);
		}

		public static OperationResult Fail(string message)
		{
			return new OperationResult(false, message);
		}
	}
}
