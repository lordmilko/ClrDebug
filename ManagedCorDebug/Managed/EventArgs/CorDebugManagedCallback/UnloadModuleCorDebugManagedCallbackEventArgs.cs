using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.UnloadModule"/> method.
    /// </summary>
    public class UnloadModuleCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.UnloadModule;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contained the module.
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
        #region Module

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugModule rawModule;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugModule module;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugModule"/> object that represents the module.
        /// </summary>
        public CorDebugModule Module
        {
            get
            {
                if (module == null && rawModule != null)
                    module = new CorDebugModule(rawModule);

                return module;
            }
        }

        #endregion
        
        /// <summary>
        /// Notifies the debugger that a common language runtime module (DLL) has been unloaded.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contained the module.</param>
        /// <param name="pModule">A pointer to an <see cref="ICorDebugModule"/> object that represents the module.</param>
        public UnloadModuleCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule) : base(pAppDomain)
        {
            rawAppDomain = pAppDomain;
            rawModule = pModule;
        }
    }
}