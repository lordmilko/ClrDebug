using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback2.DestroyConnection"/> method.
    /// </summary>
    public class DestroyConnectionCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.DestroyConnection;

        #region Process

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugProcess rawProcess;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugProcess process;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugProcess"/> object that represents the process containing the connection that was destroyed.
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
        /// The ID of the connection that was destroyed.
        /// </summary>
        public int ConnectionId { get; }

        /// <summary>
        /// Notifies the debugger that the specified connection has been terminated.
        /// </summary>
        /// <param name="pProcess">A pointer to an <see cref="ICorDebugProcess"/> object that represents the process containing the connection that was destroyed.</param>
        /// <param name="dwConnectionId">The ID of the connection that was destroyed.</param>
        public DestroyConnectionCorDebugManagedCallbackEventArgs(ICorDebugProcess pProcess, int dwConnectionId) : base(pProcess)
        {
            rawProcess = pProcess;
            ConnectionId = dwConnectionId;
        }
    }
}