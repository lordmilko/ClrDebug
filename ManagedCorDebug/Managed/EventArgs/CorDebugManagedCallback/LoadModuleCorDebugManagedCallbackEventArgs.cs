using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.LoadModule"/> method.
    /// </summary>
    public class LoadModuleCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.LoadModule;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain into which the module has been loaded.
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
        /// A pointer to an <see cref="ICorDebugModule"/> object that represents the CLR module.
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
        /// Notifies the debugger that a common language runtime (CLR) module has been successfully loaded.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain into which the module has been loaded.</param>
        /// <param name="pModule">A pointer to an <see cref="ICorDebugModule"/> object that represents the CLR module.</param>
        public LoadModuleCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule)
        {
            rawAppDomain = pAppDomain;
            rawModule = pModule;
        }
    }
}