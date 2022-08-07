using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback4.BeforeGarbageCollection"/> method.
    /// </summary>
    public class BeforeGarbageCollectionCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.BeforeGarbageCollection;

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
        
        public BeforeGarbageCollectionCorDebugManagedCallbackEventArgs(ICorDebugProcess pProcess) : base(pProcess)
        {
            rawProcess = pProcess;
        }
    }
}
