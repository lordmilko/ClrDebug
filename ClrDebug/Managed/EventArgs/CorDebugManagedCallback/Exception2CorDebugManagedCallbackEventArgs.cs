using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback2.Exception"/> method.
    /// </summary>
    public class Exception2CorDebugManagedCallbackEventArgs : AppDomainThreadDebugCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.Exception2;

        #region Frame

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugFrame rawFrame;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugFrame frame;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugFrame"/> object that represents a frame, as determined by the dwEventType parameter.<para/>
        /// For more information, see the table in the Remarks section.
        /// </summary>
        public CorDebugFrame Frame
        {
            get
            {
                if (frame == null && rawFrame != null)
                    frame = CorDebugFrame.New(rawFrame);

                return frame;
            }
        }

        #endregion
        
        /// <summary>
        /// An integer that specifies an offset, as determined by the dwEventType parameter. For more information, see the table in the Remarks section.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// A value of the <see cref="CorDebugExceptionCallbackType"/> enumeration that specifies the type of this exception callback.
        /// </summary>
        public CorDebugExceptionCallbackType EventType { get; }

        /// <summary>
        /// A value of the <see cref="CorDebugExceptionFlags"/> enumeration that specifies additional information about the exception
        /// </summary>
        public CorDebugExceptionFlags Flags { get; }

        /// <summary>
        /// Notifies the debugger that a search for an exception handler has started.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the thread on which the exception was thrown.</param>
        /// <param name="pThread">A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the exception was thrown.</param>
        /// <param name="pFrame">A pointer to an <see cref="ICorDebugFrame"/> object that represents a frame, as determined by the dwEventType parameter.<para/>
        /// For more information, see the table in the Remarks section.</param>
        /// <param name="nOffset">An integer that specifies an offset, as determined by the dwEventType parameter. For more information, see the table in the Remarks section.</param>
        /// <param name="dwEventType">A value of the <see cref="CorDebugExceptionCallbackType"/> enumeration that specifies the type of this exception callback.</param>
        /// <param name="dwFlags">A value of the <see cref="CorDebugExceptionFlags"/> enumeration that specifies additional information about the exception</param>
        public Exception2CorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFrame pFrame, int nOffset, CorDebugExceptionCallbackType dwEventType, CorDebugExceptionFlags dwFlags) : base(pAppDomain, pThread)
        {
            rawFrame = pFrame;
            Offset = nOffset;
            EventType = dwEventType;
            Flags = dwFlags;
        }
    }
}
