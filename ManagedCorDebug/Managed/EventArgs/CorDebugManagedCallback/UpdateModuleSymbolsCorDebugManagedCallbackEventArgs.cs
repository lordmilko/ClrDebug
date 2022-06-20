using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.UpdateModuleSymbols"/> method.
    /// </summary>
    public class UpdateModuleSymbolsCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.UpdateModuleSymbols;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the module in which the symbols have changed.
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
        /// A pointer to an <see cref="ICorDebugModule"/> object that represents the module in which the symbols have changed.
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
        #region SymbolStream

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly IStream rawSymbolStream;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Stream symbolStream;

        /// <summary>
        /// A pointer to a Win32 COM <see cref="IStream"/> object that contains the modified symbols.
        /// </summary>
        public Stream SymbolStream
        {
            get
            {
                if (symbolStream == null && rawSymbolStream != null)
                    symbolStream = new Stream(rawSymbolStream);

                return symbolStream;
            }
        }

        #endregion
        
        /// <summary>
        /// Notifies the debugger that the symbols for a common language runtime module have changed.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the module in which the symbols have changed.</param>
        /// <param name="pModule">A pointer to an <see cref="ICorDebugModule"/> object that represents the module in which the symbols have changed.</param>
        /// <param name="pSymbolStream">A pointer to a Win32 COM <see cref="IStream"/> object that contains the modified symbols.</param>
        public UpdateModuleSymbolsCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule, IStream pSymbolStream) : base(pAppDomain)
        {
            rawAppDomain = pAppDomain;
            rawModule = pModule;
            rawSymbolStream = pSymbolStream;
        }
    }
}