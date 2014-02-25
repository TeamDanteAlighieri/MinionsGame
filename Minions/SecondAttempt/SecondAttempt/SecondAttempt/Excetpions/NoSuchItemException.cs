namespace SecondAttempt
{
    using System;

    public class NoSuchItemException : ApplicationException
    {
        public NoSuchItemException(string message, Item item = null)
            : base(message)
        {
            if (item != null) message += string.Format("\nItem name: {0}\n", item.Name);
        }

        public NoSuchItemException(string message, Exception innerException, Item item = null)
            : base(message, innerException)
        {
            if (item != null) message += string.Format("\nItem name: {0}\n", item.Name);
        }
    }
}
