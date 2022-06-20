using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.DebuggerError"/> method.
    /// </summary>
    public class DebuggerErrorCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.DebuggerError;

        #region Process

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugProcess rawProcess;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugProcess process;

        /// <summary>
        /// A pointer to an "ICorDebugProcess" object that represents the process in which the event occurred.
        /// </summary>
        public CorDebugProcess Process
        {
            get
            {
                if (process == null && rawProcess != null)
                    process = new CorDebugProcess(rawProcess);

                return process;
            }
        }

        #endregion
        
        /// <summary>
        /// The <see cref="HRESULT"/> value that was returned from the event handler.
        /// </summary>
        public HRESULT ErrorHR { get; }

        /// <summary>
        /// An integer that specifies the CLR error.
        /// </summary>
        public int ErrorCode { get; }

        /// <summary>
        /// Notifies the debugger that an error has occurred while attempting to handle an event from the common language runtime (CLR).
        /// </summary>
        /// <param name="pProcess">A pointer to an "ICorDebugProcess" object that represents the process in which the event occurred.</param>
        /// <param name="errorHR">The <see cref="HRESULT"/> value that was returned from the event handler.</param>
        /// <param name="errorCode">An integer that specifies the CLR error.</param>
        public DebuggerErrorCorDebugManagedCallbackEventArgs(ICorDebugProcess pProcess, HRESULT errorHR, int errorCode) : base(pProcess)
        {
            rawProcess = pProcess;
            ErrorHR = errorHR;
            ErrorCode = errorCode;
        }
    }
}