using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.UnloadAssembly"/> method.
    /// </summary>
    public class UnloadAssemblyCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.UnloadAssembly;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contained the assembly.
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
        #region Assembly

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAssembly rawAssembly;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAssembly assembly;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAssembly"/> object that represents the assembly.
        /// </summary>
        public CorDebugAssembly Assembly
        {
            get
            {
                if (assembly == null && rawAssembly != null)
                    assembly = new CorDebugAssembly(rawAssembly);

                return assembly;
            }
        }

        #endregion
        
        /// <summary>
        /// Notifies the debugger that a common language runtime assembly has been unloaded.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contained the assembly.</param>
        /// <param name="pAssembly">A pointer to an <see cref="ICorDebugAssembly"/> object that represents the assembly.</param>
        public UnloadAssemblyCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugAssembly pAssembly)
        {
            rawAppDomain = pAppDomain;
            rawAssembly = pAssembly;
        }
    }
}