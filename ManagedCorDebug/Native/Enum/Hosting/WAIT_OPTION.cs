using System.Threading;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains values that indicate the action a host should take if an operation requested by the common language runtime (CLR) blocks.
    /// </summary>
    /// <remarks>
    /// The <see cref="IHostTaskManager.Sleep"/> and <see cref="IHostTaskManager.SwitchToTask"/> methods both take a parameter
    /// of this type.
    /// </remarks>
    public enum WAIT_OPTION
    {
        /// <summary>
        /// Notifies the host that it must pump messages on the current OS thread if the thread becomes blocked. The runtime specifies this value only on an <see cref="ApartmentState.STA"/> thread.
        /// </summary>
        WAIT_MSGPUMP = 0x1,

        /// <summary>
        /// Notifies the host that the task should be awakened if the CLR calls the <see cref="IHostTask.Alert"/> method.
        /// </summary>
        WAIT_ALERTABLE = 0x2,

        /// <summary>
        /// Notifies the host that the specified synchronization request cannot be broken by a host. That is, the host cannot return HOST_E_DEADLOCK.
        /// </summary>
        WAIT_NOTINDEADLOCK = 0x4
    }
}