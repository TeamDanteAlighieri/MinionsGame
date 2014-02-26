namespace SecondAttempt
{
    using System;

	public class LoadGameException : ApplicationException
	{
		public LoadGameException(string message, Exception innerException = null)
			: base(message, innerException)
		{

		}
	}
}