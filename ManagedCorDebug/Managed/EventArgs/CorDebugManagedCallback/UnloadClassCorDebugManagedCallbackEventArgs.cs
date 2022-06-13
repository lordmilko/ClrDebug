using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.UnloadClass"/> method.
    /// </summary>
    public class UnloadClassCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.UnloadClass;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the class.
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
        #region C

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugClass rawC;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugClass c;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugClass"/> object that represents the class.
        /// </summary>
        public CorDebugClass C
        {
            get
            {
                if (c == null && rawC != null)
                    c = new CorDebugClass(rawC);

                return c;
            }
        }

        #endregion
        
        /// <summary>
        /// Notifies the debugger that a class is being unloaded.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the class.</param>
        /// <param name="c">A pointer to an <see cref="ICorDebugClass"/> object that represents the class.</param>
        public UnloadClassCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugClass c)
        {
            rawAppDomain = pAppDomain;
            rawC = c;
        }
    }
}