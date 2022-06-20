using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.LoadClass"/> method.
    /// </summary>
    public class LoadClassCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.LoadClass;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain into which the class has been loaded.
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
        /// Notifies the debugger that a class has been loaded.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain into which the class has been loaded.</param>
        /// <param name="c">A pointer to an <see cref="ICorDebugClass"/> object that represents the class.</param>
        public LoadClassCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugClass c) : base(pAppDomain)
        {
            rawAppDomain = pAppDomain;
            rawC = c;
        }
    }
}