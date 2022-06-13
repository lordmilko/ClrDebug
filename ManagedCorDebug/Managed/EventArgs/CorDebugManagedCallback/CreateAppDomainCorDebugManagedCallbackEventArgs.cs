using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.CreateAppDomain"/> method.
    /// </summary>
    public class CreateAppDomainCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.CreateAppDomain;

        #region Process

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugProcess rawProcess;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugProcess process;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugProcess"/> object that represents the process in which the application domain was created.
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
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that has been created.
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
        /// Notifies the debugger that an application domain has been created.
        /// </summary>
        /// <param name="pProcess">A pointer to an <see cref="ICorDebugProcess"/> object that represents the process in which the application domain was created.</param>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that has been created.</param>
        public CreateAppDomainCorDebugManagedCallbackEventArgs(ICorDebugProcess pProcess, ICorDebugAppDomain pAppDomain)
        {
            rawProcess = pProcess;
            rawAppDomain = pAppDomain;
        }
    }
}