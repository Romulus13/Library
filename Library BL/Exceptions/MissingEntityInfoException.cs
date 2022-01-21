namespace Library_BL.Exceptions
{
    public class MissingEntityInfoException : Exception
    {
        public MissingEntityInfoException() {}
      
        public MissingEntityInfoException(string message) : base(message) { }
        public MissingEntityInfoException(string message, Exception innerException) : base (message, innerException) { }


    }
}