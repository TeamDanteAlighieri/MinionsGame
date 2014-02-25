namespace SecondAttempt
{
    using System;

	public class LoadGameException : Exception
	{
		public LoadGameException(string message, Exception innerException = null)
			: base(message, innerException)
		{

		}
	}
}