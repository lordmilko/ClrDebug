using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ClrDebug
{
    /// <summary>
    /// The exception that is thrown when a debugger API returns an unsuccessful <see cref="HRESULT"/>.
    /// </summary>
    [Serializable]
    public class DebugException : COMException
    {
        public new HRESULT HResult => (HRESULT) base.HResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugException"/> class.
        /// </summary>
        /// <param name="hr">The <see cref="HRESULT"/> that is the cause of the exception.</param>
        public DebugException(HRESULT hr) : base($"Error HRESULT {(Enum.IsDefined(typeof(HRESULT), hr) ? hr.ToString() : "0x" + ((int)hr).ToString("X"))} has been returned from a call to a COM component.", (int) hr)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="hr">The <see cref="HRESULT"/> that is the cause of the exception.</param>
        public DebugException(string message, HRESULT hr) : base(message, (int) hr)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugException" /> class from serialization data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> object that holds the serialized object data.</param>
        /// <param name="context">The <see cref="StreamingContext" /> object that supplies the contextual information about the source or destination.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="info" /> is <see langword="null" />.</exception>
        [Obsolete]
        protected DebugException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
