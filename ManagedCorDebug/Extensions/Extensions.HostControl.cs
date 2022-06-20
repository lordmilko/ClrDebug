using System;

namespace ManagedCorDebug
{
    public static partial class Extensions
    {
        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from <see cref="HostControl.GetHostManager(Guid)"/>.
        /// </summary>
        public class HostControlManagerInterfaces
        {
            private readonly HostControl control;

            internal HostControlManagerInterfaces(HostControl control)
            {
                this.control = control;
            }

            //HostMemoryManager

            /// <summary>
            /// Provides methods that allow the common language runtime (CLR) to work with tasks through the host instead of using the standard operating system threading or fiber functions.
            /// </summary>
            public HostTaskManager HostTaskManager => new HostTaskManager(control.GetHostManager<IHostTaskManager>());

            /// <summary>
            /// Provides methods that enable the common language runtime (CLR) to configure the thread pool and to queue work items to the thread pool.
            /// </summary>
            public HostThreadPoolManager HostThreadPoolManager => new HostThreadPoolManager(control.GetHostManager<IHostThreadPoolManager>());

            /// <summary>
            /// Provides methods that allow the common language runtime (CLR) to interact with I/O completion ports provided by the host.
            /// </summary>
            public HostIoCompletionManager HostIoCompletionManager => new HostIoCompletionManager(control.GetHostManager<IHostIoCompletionManager>());

            //HostSyncManager
            //HostAssemblyManager
            //HostGCManager
            //HostPolicyManager

            /// <summary>
            /// Provides methods that allow access to and control over the security context of the currently executing thread.
            /// </summary>
            public HostSecurityManager HostSecurityManager => new HostSecurityManager(control.GetHostManager<IHostSecurityManager>());
        }

        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from <see cref="HostControl.GetHostManager(Guid)"/>.
        /// </summary>
        /// <param name="control">The <see cref="CLRControl"/> to use to retrieve the interfaces.</param>
        /// <returns>The common interfaces that can be retrieved from <see cref="HostControl.GetHostManager(Guid)"/>.</returns>
        public static HostControlManagerInterfaces GetHostManager(this HostControl control) => new HostControlManagerInterfaces(control);

        /// <summary>
        /// Gets an interface pointer to the host's implementation of the interface with the specified IID.
        /// </summary>
        /// <typeparam name="T">The type of interface to retrieve.</typeparam>
        /// <param name="control">The <see cref="HostControl"/> object to use to retrieve the interface.</param>
        /// <returns>A pointer to the host-implemented interface, or null if the host does not support this interface.</returns>
        public static T GetHostManager<T>(this HostControl control) => (T)control.GetHostManager(typeof(T).GUID);
    }
}
