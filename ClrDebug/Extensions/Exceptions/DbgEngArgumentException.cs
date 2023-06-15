using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The exception that is thrown when one of the arguments that was passed to DbgEng was invalid.<para/>
    /// Corresponds to <see cref="HRESULT.E_INVALIDARG"/>.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class DbgEngArgumentException : ArgumentException
    {
        public new HRESULT HResult => (HRESULT) base.HResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbgEngArgumentException"/> class.
        /// </summary>
        public DbgEngArgumentException()
        {
            base.HResult = unchecked((int) HRESULT.E_INVALIDARG);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbgEngArgumentException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public DbgEngArgumentException(string message) : base(message)
        {
            base.HResult = unchecked((int) HRESULT.E_INVALIDARG);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbgEngArgumentException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner"/> parameter is not null, the current exception is raised in a catch block that handles the inner exception.</param>
        public DbgEngArgumentException(string message, Exception inner) : base(message, inner)
        {
            base.HResult = unchecked((int) HRESULT.E_INVALIDARG);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbgEngArgumentException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        [Obsolete]
        protected DbgEngArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            base.HResult = unchecked((int) HRESULT.E_INVALIDARG);
        }
    }
}
