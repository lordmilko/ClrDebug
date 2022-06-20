using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback2.CreateConnection"/> method.
    /// </summary>
    public class CreateConnectionCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.CreateConnection;

        #region Process

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugProcess rawProcess;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugProcess process;

        /// <summary>
        /// A pointer to an "ICorDebugProcess" object that represents the process in which the connection was created
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
        /// The ID of the new connection.
        /// </summary>
        public int ConnectionId { get; }

        /// <summary>
        /// A pointer to the name of the new connection.
        /// </summary>
        public string ConnName { get; }

        /// <summary>
        /// Notifies the debugger that a new connection has been created.
        /// </summary>
        /// <param name="pProcess">A pointer to an "ICorDebugProcess" object that represents the process in which the connection was created</param>
        /// <param name="dwConnectionId">The ID of the new connection.</param>
        /// <param name="pConnName">A pointer to the name of the new connection.</param>
        public CreateConnectionCorDebugManagedCallbackEventArgs(ICorDebugProcess pProcess, int dwConnectionId, string pConnName) : base(pProcess)
        {
            rawProcess = pProcess;
            ConnectionId = dwConnectionId;
            ConnName = pConnName;
        }
    }
}