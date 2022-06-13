using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback2.ChangeConnection"/> method.
    /// </summary>
    public class ChangeConnectionCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.ChangeConnection;

        #region Process

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugProcess rawProcess;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugProcess process;

        /// <summary>
        /// A pointer to an "ICorDebugProcess" object that represents the process containing the connection that changed.
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
        /// The ID of the connection that changed.
        /// </summary>
        public int ConnectionId { get; }

        /// <summary>
        /// Notifies the debugger that the set of tasks associated with the specified connection has changed.
        /// </summary>
        /// <param name="pProcess">A pointer to an "ICorDebugProcess" object that represents the process containing the connection that changed.</param>
        /// <param name="dwConnectionId">The ID of the connection that changed.</param>
        public ChangeConnectionCorDebugManagedCallbackEventArgs(ICorDebugProcess pProcess, int dwConnectionId)
        {
            rawProcess = pProcess;
            ConnectionId = dwConnectionId;
        }
    }
}