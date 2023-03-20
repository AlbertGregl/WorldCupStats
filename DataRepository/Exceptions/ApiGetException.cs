using System.Runtime.Serialization;

namespace DataRepository.Exceptions
{
    [Serializable]
    internal class ApiGetException : Exception
    {
        public ApiGetException()
        {
        }

        public ApiGetException(string? message) : base(message)
        {
        }

        public ApiGetException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ApiGetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}