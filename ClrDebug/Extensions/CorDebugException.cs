using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ClrDebug
{
    /// <summary>
    /// The exception that is thrown when a debugger API returns an unsuccessful <see cref="HRESULT"/>.
    /// </summary>
    [Serializable]
    public class CorDebugException : COMException
    {
        public new HRESULT HResult => (HRESULT) base.HResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugException"/> class.
        /// </summary>
        /// <param name="hr">The <see cref="HRESULT"/> that is the cause of the exception.</param>
        public CorDebugException(HRESULT hr) : base($"Error HRESULT {hr} has been returned from a call to a COM component.", (int) hr)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugException" /> class from serialization data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> object that holds the serialized object data.</param>
        /// <param name="context">The <see cref="StreamingContext" /> object that supplies the contextual information about the source or destination.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="info" /> is <see langword="null" />.</exception>
        protected CorDebugException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}