using System;

namespace StarPrismTools.Infrastructure
{
	public class OperationResult
	{
		protected OperationResult(bool success, string message, Exception exception)
		{
			Success = success;
			Message = message ?? string.Empty;
			Exception = exception;
		}

		public bool Success { get; private set; }

		public string Message { get; private set; }

		public Exception Exception { get; private set; }

		public static OperationResult Ok(string message = "")
		{
			return new OperationResult(true, message, null);
		}

		public static OperationResult Fail(string message, Exception exception = null)
		{
			return new OperationResult(false, message, exception);
		}
	}

	public class OperationResult<T> : OperationResult
	{
		private OperationResult(bool success, string message, T value, Exception exception)
			: base(success, message, exception)
		{
			Value = value;
		}

		public T Value { get; private set; }

		public static OperationResult<T> Ok(T value, string message = "")
		{
			return new OperationResult<T>(true, message, value, null);
		}

		public new static OperationResult<T> Fail(string message, Exception exception = null)
		{
			return new OperationResult<T>(false, message, default(T), exception);
		}
	}
}
