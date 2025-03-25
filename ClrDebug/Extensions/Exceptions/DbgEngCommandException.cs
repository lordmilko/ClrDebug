using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The exception that is thrown by DbgEng when a command being evaluated by <see cref="IDebugControl.Execute(DEBUG_OUTCTL, string, DEBUG_EXECUTE)"/> throws
    /// a native exception while attempting to execute a command. This commonly occurs when an invalid command is specified.<para/>
    /// Corresponds to <see cref="HRESULT.EVENT_E_INTERNALEXCEPTION"/>.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class DbgEngCommandException : InvalidOperationException
    {
        public new HRESULT HResult => (HRESULT) base.HResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbgEngCommandException"/> class.
        /// </summary>
        public DbgEngCommandException()
        {
            base.HResult = unchecked((int) HRESULT.EVENT_E_INTERNALEXCEPTION);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbgEngCommandException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public DbgEngCommandException(string message) : base(message)
        {
            base.HResult = unchecked((int) HRESULT.EVENT_E_INTERNALEXCEPTION);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbgEngCommandException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner"/> parameter is not null, the current exception is raised in a catch block that handles the inner exception.</param>
        public DbgEngCommandException(string message, Exception inner) : base(message, inner)
        {
            base.HResult = unchecked((int) HRESULT.EVENT_E_INTERNALEXCEPTION);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbgEngCommandException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        [Obsolete]
        protected DbgEngCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            base.HResult = unchecked((int) HRESULT.EVENT_E_INTERNALEXCEPTION);
        }
    }
}
