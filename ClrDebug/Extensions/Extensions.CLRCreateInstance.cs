using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides API extensions to simplify common tasks performed using the ICorDebug API.
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from <see cref="CLRCreateInstance(Guid, Guid, out object)"/>.
        /// </summary>
        public class CLRCreateInstanceInterfaces
        {
#if GENERATED_MARSHALLING
            private static IntPtr mscoreeLib;
#endif

            /// <summary>
            /// Provides methods that return a specific version of the common language runtime (CLR) based on its version number,<para/>
            /// list all installed CLRs, list all runtimes that are loaded in a specified process, discover the CLR version used to compile an assembly,<para/>
            /// exit a process with a clean runtime shutdown, and query legacy API binding.
            /// </summary>
            public CLRMetaHost CLRMetaHost => new CLRMetaHost(CreateInstance<ICLRMetaHost>(CLSID_CLRMetaHost));

            /// <summary>
            /// Provides the <see cref="CLRMetaHostPolicy.GetRequestedRuntime"/> method, which returns a pointer to a common language runtime (CLR) interface based on a policy criteria, managed assembly, version and configuration file.
            /// </summary>
            public CLRMetaHostPolicy CLRMetaHostPolicy => new CLRMetaHostPolicy(CreateInstance<ICLRMetaHostPolicy>(CLSID_CLRMetaHostPolicy));

            /// <summary>
            /// Provides methods that handle loading and unloading modules for debugging.
            /// </summary>
            public CLRDebugging CLRDebugging => new CLRDebugging(CreateInstance<ICLRDebugging>(CLSID_CLRDebugging));

            internal static T CreateInstance<T>(Guid clsid)
            {
                var riid = typeof(T).GUID;
                object ppInterface;
#if GENERATED_MARSHALLING
                if (mscoreeLib == IntPtr.Zero)
                {
                    if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        throw new InvalidOperationException($"{nameof(CLRCreateInstance)} is only supported on Windows. Consider using {nameof(DbgShim)}.{nameof(DbgShim.CLRCreateInstance)} instead.");

                    mscoreeLib = LoadLibrary(mscoree);
                }

                var @delegate = new DelegateProvider(mscoreeLib).CLRCreateInstance;

                var hr = @delegate(clsid, riid, out ppInterface);
#else
                var hr = CLRCreateInstance(clsid, riid, out ppInterface);
#endif
                hr.ThrowOnNotOK();

                return (T)ppInterface;
            }
        }
    }
}
