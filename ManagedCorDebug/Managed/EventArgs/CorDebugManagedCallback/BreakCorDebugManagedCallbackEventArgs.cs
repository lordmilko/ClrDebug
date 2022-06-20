using System.Reflection.Emit;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.Break"/> method.
    /// </summary>
    public class BreakCorDebugManagedCallbackEventArgs : AppDomainThreadDebugCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.Break;
        
        /// <summary>
        /// Notifies the debugger when a <see cref="OpCodes.Break"/> instruction in the code stream is executed.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the break instruction.</param>
        /// <param name="thread">A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that contains the break instruction.</param>
        public BreakCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread thread) : base(pAppDomain, thread)
        {
        }
    }
}