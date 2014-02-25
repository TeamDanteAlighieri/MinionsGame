using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondAttempt
{
	public class LoadGameException : Exception
	{
		public LoadGameException(string message, Exception innerException = null)
			: base(message, innerException)
		{

		}
	}
}