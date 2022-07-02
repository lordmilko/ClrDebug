using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.CreateThread"/> method.
    /// </summary>
    public class CreateThreadCorDebugManagedCallbackEventArgs : AppDomainThreadDebugCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.CreateThread;
        
        /// <summary>
        /// Notifies the debugger that a thread has started executing managed code.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the thread.</param>
        /// <param name="thread">A pointer to an <see cref="ICorDebugThread"/> object that represents the thread.</param>
        public CreateThreadCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread thread) : base(pAppDomain, thread)
        {
        }
    }
}