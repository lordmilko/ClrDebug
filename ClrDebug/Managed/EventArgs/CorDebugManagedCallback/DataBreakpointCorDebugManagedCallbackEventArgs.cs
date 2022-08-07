using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback4.DataBreakpoint"/> method.
    /// </summary>
    public class DataBreakpointCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.DataBreakpoint;

        #region Process

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugProcess rawProcess;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugProcess process;

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
        #region Thread

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugThread rawThread;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugThread thread;

        public CorDebugThread Thread
        {
            get
            {
                if (thread == null && rawThread != null)
                    thread = new CorDebugThread(rawThread);

                return thread;
            }
        }

        #endregion
        
        public IntPtr Context { get; }

        public int ContextSize { get; }

        public DataBreakpointCorDebugManagedCallbackEventArgs(ICorDebugProcess pProcess, ICorDebugThread pThread, IntPtr pContext, int contextSize) : base(pProcess)
        {
            rawProcess = pProcess;
            rawThread = pThread;
            Context = pContext;
            ContextSize = contextSize;
        }
    }
}
