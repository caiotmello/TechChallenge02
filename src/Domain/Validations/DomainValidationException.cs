namespace Domain.Validations
{
    public class DomainValidationException : Exception
    {
        /// <summary>
        /// Create only one instance
        /// </summary>
        /// <param name="error"></param>
        public DomainValidationException()
        {
        }

        /// <summary>
        /// Customized message exception
        /// </summary>
        /// <param name="error"></param>
        public DomainValidationException(string message) : base(message)
        { 
        }

        /// <summary>
        /// Pass one message and one exception generated previosly s
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public DomainValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
