using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.ExitThread"/> method.
    /// </summary>
    public class ExitThreadCorDebugManagedCallbackEventArgs : AppDomainThreadDebugCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.ExitThread;
        
        /// <summary>
        /// Notifies the debugger that a thread that was executing managed code has exited.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the managed thread.</param>
        /// <param name="thread">A pointer to an <see cref="ICorDebugThread"/> object that represents the managed thread.</param>
        public ExitThreadCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread thread) : base(pAppDomain, thread)
        {
        }
    }
}