using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.ExitAppDomain"/> method.
    /// </summary>
    public class ExitAppDomainCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.ExitAppDomain;

        #region Process

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugProcess rawProcess;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugProcess process;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugProcess"/> object that represents the process that contains the given application domain.
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
        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that has exited.
        /// </summary>
        public CorDebugAppDomain AppDomain
        {
            get
            {
                if (appDomain == null && rawAppDomain != null)
                    appDomain = new CorDebugAppDomain(rawAppDomain);

                return appDomain;
            }
        }

        #endregion
        
        /// <summary>
        /// Notifies the debugger that an application domain has exited.
        /// </summary>
        /// <param name="pProcess">A pointer to an <see cref="ICorDebugProcess"/> object that represents the process that contains the given application domain.</param>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that has exited.</param>
        public ExitAppDomainCorDebugManagedCallbackEventArgs(ICorDebugProcess pProcess, ICorDebugAppDomain pAppDomain) : base(pProcess)
        {
            rawProcess = pProcess;
            rawAppDomain = pAppDomain;
        }
    }
}