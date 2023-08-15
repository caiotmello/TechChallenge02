namespace Domain.Validations
{
    public class AssertionConcern
    {

        /// <summary>
        /// Validation of maximun string lenght
        /// </summary>
        /// <param name="stringValue"></param>
        /// <param name="maximum"></param>
        /// <param name="message"></param>
        /// <exception cref="DomainValidationException"></exception>
        public static void AssertArgumentLenght(string stringValue, int maximum, string message)
        {
            int lenght = stringValue.Trim().Length;
            if (lenght > maximum)
            {
                throw new DomainValidationException(message);
            }
        }

        /// <summary>
        /// Validation of minimun and maximun string lenght
        /// </summary>
        /// <param name="stringValue"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <param name="message"></param>
        /// <exception cref="DomainValidationException"></exception>
        public static void AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            int length = stringValue.Trim().Length;
            if (length < minimum || length > maximum)
            {
                throw new DomainValidationException(message);
            }
        }

        /// <summary>
        /// Validation of empty string
        /// </summary>
        /// <param name="stringValue"></param>
        /// <param name="message"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AssertArgumentNotEmpty(string stringValue, string message)
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
            {
                throw new DomainValidationException(message);
            }
        }

        /// <summary>
        /// Validation of Null argument
        /// </summary>
        /// <param name="object1"></param>
        /// <param name="message"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AssertArgumentNotNull(object object1, string message)
        {
            if (object1 == null)
            {
                throw new DomainValidationException(message);
            }
        }

        /// <summary>
        /// Validation of Argument false. Generate a exception when boolValue is True
        /// </summary>
        /// <param name="boolValue"></param>
        /// <param name="message"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AssertArgumentFalse(bool boolValue, string message)
        {
            if (boolValue)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
