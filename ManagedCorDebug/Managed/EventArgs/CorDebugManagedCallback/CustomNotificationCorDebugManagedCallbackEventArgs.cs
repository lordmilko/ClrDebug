using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback3.CustomNotification"/> method.
    /// </summary>
    public class CustomNotificationCorDebugManagedCallbackEventArgs : AppDomainThreadDebugCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.CustomNotification;
        /// <summary>
        /// Indicates that a custom debugger notification has been raised.
        /// </summary>
        /// <param name="pThread">A pointer to the thread that raised the notification.</param>
        /// <param name="pAppDomain">A pointer to the application domain that contains the thread that raised the notification.</param>
        public CustomNotificationCorDebugManagedCallbackEventArgs(ICorDebugThread pThread, ICorDebugAppDomain pAppDomain) : base(pAppDomain, pThread)
        {
        }
    }
}