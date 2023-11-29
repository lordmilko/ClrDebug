using System;

namespace ClrDebug
{
    public static partial class Extensions
    {
        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from <see cref="CLRControl.GetCLRManager(Guid)"/>.
        /// </summary>
        public class CLRControlManagerInterfaces
        {
            private readonly CLRControl control;

            internal CLRControlManagerInterfaces(CLRControl control)
            {
                this.control = control;
            }

            /// <summary>
            /// Provides methods that allow a host to associate a set of tasks with an identifier and a friendly name.
            /// </summary>
            public CLRDebugManager CLRDebugManager => control.GetCLRManager<CLRDebugManager>();

            //CLRErrorReportingManager
            //CLRGCManager
            //CLRHostProtectionManager
            //CLROnEventManager
            //CLRPolicyManager

            /// <summary>
            /// Provides methods that allow the host to request explicitly that the common language runtime (CLR) create a new task, get the currently executing task, and set the geographic language and culture for the task.
            /// </summary>
            public CLRTaskManager CLRTaskManager => control.GetCLRManager<CLRTaskManager>();
        }

        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from <see cref="CLRControl.GetCLRManager(Guid)"/>.
        /// </summary>
        /// <param name="control">The <see cref="CLRControl"/> to use to retrieve the interfaces.</param>
        /// <returns>The common interfaces that can be retrieved from <see cref="CLRControl.GetCLRManager(Guid)"/>.</returns>
        public static CLRControlManagerInterfaces GetCLRManager(this CLRControl control) => new CLRControlManagerInterfaces(control);

        /// <summary>
        /// Gets an interface pointer to an instance of any of the manager types the host can use to configure the common language runtime (CLR).
        /// </summary>
        /// <typeparam name="T">The type of interface to retrieve. This may either be a raw interface or a supported wrapper type.</typeparam>
        /// <param name="control">The <see cref="CLRControl"/> object to use to retrieve the interface.</param>
        /// <returns>An interface pointer to the requested manager, or null, if an invalid manager type was requested.</returns>
        public static T GetCLRManager<T>(this CLRControl control)
        {
            var t = typeof(T);
            object result;

            if (t == typeof(CLRDebugManager))
                result = new CLRDebugManager((ICLRDebugManager) control.GetCLRManager(typeof(ICLRDebugManager).GUID));
            else if (t == typeof(CLRTaskManager))
                result = new CLRTaskManager((ICLRTaskManager) control.GetCLRManager(typeof(ICLRTaskManager).GUID));
            else
                result = control.GetCLRManager(typeof(T).GUID);

            return (T) result;
        }
    }
}
