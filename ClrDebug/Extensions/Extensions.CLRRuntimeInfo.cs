using System;

namespace ClrDebug
{
    public static partial class Extensions
    {
        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from <see cref="CLRRuntimeInfo.GetInterface(Guid, Guid)"/>.
        /// </summary>
        public class CLRRuntimeInfoInterfaces
        {
            private readonly CLRRuntimeInfo info;

            internal CLRRuntimeInfoInterfaces(CLRRuntimeInfo info)
            {
                this.info = info;
            }

            /// <summary>
            /// Extends the <see cref="IMetaDataDispenser"/> interface to provide the capability to control how the metadata APIs operate on the current metadata scope.
            /// </summary>
            public MetaDataDispenserEx MetaDataDispenserEx => new MetaDataDispenserEx(info.GetInterface<IMetaDataDispenserEx>(CLSID_CorMetaDataDispenser));

            /// <summary>
            /// Provides methods that enable the host to start and stop the common language runtime (CLR) explicitly, to create and configure application domains, to access the default domain, and to enumerate all domains running in the process.<para/>
            /// In the .NET Framework version 2.0, this interface is superseded by <see cref="ICLRRuntimeHost"/>.
            /// </summary>
            public CorRuntimeHost CorRuntimeHost => new CorRuntimeHost(info.GetInterface<ICorRuntimeHost>(CLSID_CorRuntimeHost));

            /// <summary>
            /// Provides functionality similar to that of the <see cref="ICorRuntimeHost"/> interface provided in the .NET Framework version 1.
            /// </summary>
            public CLRRuntimeHost CLRRuntimeHost => new CLRRuntimeHost(info.GetInterface<ICLRRuntimeHost>(CLSID_CLRRuntimeHost));

            //TypeNameFactory

            /// <summary>
            /// Provides methods that allow developers to debug applications in the common language runtime (CLR) environment.
            /// </summary>
            public CorDebug CorDebug => new CorDebug(info.GetInterface<ICorDebug>(CLSID_CLRDebuggingLegacy));

            /// <summary>
            /// Provides basic global static functions for signing assemblies with strong names. All <see cref="ICLRStrongName"/> methods return standard COM HRESULTs.
            /// </summary>
            public CLRStrongName CLRStrongName => new CLRStrongName(info.GetInterface<ICLRStrongName>(CLSID_CLRStrongName));
        }

        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from <see cref="CLRRuntimeInfo.GetInterface(Guid, Guid)"/>.
        /// </summary>
        /// <param name="info">The <see cref="CLRRuntimeInfo"/> to use to retrieve the interfaces.</param>
        /// <returns>The common interfaces that can be retrieved from <see cref="CLRRuntimeInfo.GetInterface(Guid, Guid)"/>.</returns>
        public static CLRRuntimeInfoInterfaces GetInterface(this CLRRuntimeInfo info) => new CLRRuntimeInfoInterfaces(info);

        /// <summary>
        /// Loads the CLR into the current process and returns runtime interface pointers, such as <see cref="ICLRRuntimeHost"/>, <see cref="ICLRStrongName"/>, and <see cref="IMetaDataDispenser"/>.<para/>
        /// This method supersedes all the CorBindTo* functions in the Deprecated CLR Hosting Functions section.
        /// </summary>
        /// <typeparam name="T">The type of interface to retrieve.</typeparam>
        /// <param name="info">The <see cref="CLRRuntimeInfo"/> object to use to retrieve the interface.</param>
        /// <param name="clsid">[in] The CLSID interface for the coclass.</param>
        /// <returns>A pointer to the queried interface.</returns>
        public static T GetInterface<T>(this CLRRuntimeInfo info, Guid clsid) => (T)info.GetInterface(clsid, typeof(T).GUID);
    }
}
