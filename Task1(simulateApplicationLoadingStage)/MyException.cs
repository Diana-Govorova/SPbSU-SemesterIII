using System;
using System.Collections.Generic;
using System.Text;

namespace Task1_simulateApplicationLoadingStage_
{
    /// <summary>
    /// Exception class.
    /// </summary>
    [Serializable]
    public class MyException : Exception
    {
        /// <summary>
        /// Initialization of the <see cref="MyException"/> class element.
        /// </summary>
        public MyException()
        {
        }

        /// <summary>
        /// Initialization of the <see cref="MyException"/> class element.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public MyException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initialization of the <see cref="MyException"/> class element.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public MyException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initialization of the <see cref="MyException"/> class element.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected MyException(System.Runtime.Serialization.SerializationInfo info, 
            System.Runtime.Serialization.StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
