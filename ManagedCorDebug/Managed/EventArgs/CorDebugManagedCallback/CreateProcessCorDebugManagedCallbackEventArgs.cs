using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.CreateProcess"/> method.
    /// </summary>
    public class CreateProcessCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.CreateProcess;

        #region Process

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugProcess rawProcess;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugProcess process;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugProcess"/> object that represents the process that has been attached or started.
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
        /// Notifies the debugger when a process has been attached or started for the first time.
        /// </summary>
        /// <param name="pProcess">A pointer to an <see cref="ICorDebugProcess"/> object that represents the process that has been attached or started.</param>
        public CreateProcessCorDebugManagedCallbackEventArgs(ICorDebugProcess pProcess) : base(pProcess)
        {
            rawProcess = pProcess;
        }
    }
}