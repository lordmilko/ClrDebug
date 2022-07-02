using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.ControlCTrap"/> method.
    /// </summary>
    public class ControlCTrapCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.ControlCTrap;

        #region Process

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugProcess rawProcess;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugProcess process;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugProcess"/> object that represents the process in which the CTRL+C is trapped.
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
        /// Notifies the debugger that a CTRL+C is trapped in the process that is being debugged.
        /// </summary>
        /// <param name="pProcess">A pointer to an <see cref="ICorDebugProcess"/> object that represents the process in which the CTRL+C is trapped.</param>
        public ControlCTrapCorDebugManagedCallbackEventArgs(ICorDebugProcess pProcess) : base(pProcess)
        {
            rawProcess = pProcess;
        }
    }
}