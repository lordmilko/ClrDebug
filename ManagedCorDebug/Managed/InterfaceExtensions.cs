using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedCorDebug
{
    public static class InterfaceExtensions
    {
        #region CLRRuntimeInfo

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
            public MetaDataDispenserEx MetaDataDispenserEx => new MetaDataDispenserEx(info.GetInterface<IMetaDataDispenserEx>(NativeMethods.CLSID_CorMetaDataDispenser));

            /// <summary>
            /// Provides methods that enable the host to start and stop the common language runtime (CLR) explicitly, to create and configure application domains, to access the default domain, and to enumerate all domains running in the process.<para/>
            /// In the .NET Framework version 2.0, this interface is superseded by <see cref="ICLRRuntimeHost"/>.
            /// </summary>
            public CorRuntimeHost CorRuntimeHost => new CorRuntimeHost(info.GetInterface<ICorRuntimeHost>(NativeMethods.CLSID_CorRuntimeHost));

            /// <summary>
            /// Provides functionality similar to that of the <see cref="ICorRuntimeHost"/> interface provided in the .NET Framework version 1.
            /// </summary>
            public CLRRuntimeHost CLRRuntimeHost => new CLRRuntimeHost(info.GetInterface<ICLRRuntimeHost>(NativeMethods.CLSID_CLRRuntimeHost));

            //TypeNameFactory

            /// <summary>
            /// Provides methods that allow developers to debug applications in the common language runtime (CLR) environment.
            /// </summary>
            public CorDebug CorDebug => new CorDebug(info.GetInterface<ICorDebug>(NativeMethods.CLSID_CLRDebuggingLegacy));

            /// <summary>
            /// Provides basic global static functions for signing assemblies with strong names. All <see cref="ICLRStrongName"/> methods return standard COM HRESULTs.
            /// </summary>
            public CLRStrongName CLRStrongName => new CLRStrongName(info.GetInterface<ICLRStrongName>(NativeMethods.CLSID_CLRStrongName));
        }

        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from <see cref="CLRRuntimeInfo.GetInterface(Guid, Guid)"/>.
        /// </summary>
        /// <param name="info">The <see cref="CLRRuntimeInfo"/> to use to retrieve the interface.</param>
        /// <returns>The common interfaces that can be retrieved from <see cref="CLRRuntimeInfo.GetInterface(Guid, Guid)"/>.</returns>
        public static CLRRuntimeInfoInterfaces GetInterface(this CLRRuntimeInfo info) => new CLRRuntimeInfoInterfaces(info);

        public static T GetInterface<T>(this CLRRuntimeInfo info, Guid clsid) => (T)info.GetInterface(clsid, typeof(T).GUID);

        #endregion
        #region CorDebugModule

        public class CorDebugModuleInterfaces
        {
            private readonly CorDebugModule module;

            internal CorDebugModuleInterfaces(CorDebugModule module)
            {
                this.module = module;
            }

            /// <summary>
            /// Provides methods for importing and manipulating existing metadata from a portable executable (PE) file or other source, such as a type library or a stand-alone, run-time metadata binary.
            /// </summary>
            public MetaDataImport MetaDataImport => new MetaDataImport(module.GetMetaDataInterface<IMetaDataImport>());

            /// <summary>
            /// Provides methods to access and examine the contents of an assembly manifest.
            /// </summary>
            public MetaDataAssemblyImport MetaDataAssemblyImport => new MetaDataAssemblyImport(module.GetMetaDataInterface<IMetaDataAssemblyImport>());

            /// <summary>
            /// Provides methods for the storage and retrieval of metadata information in tables.
            /// </summary>
            public MetaDataTables MetaDataTables => new MetaDataTables(module.GetMetaDataInterface<IMetaDataTables>());

            /// <summary>
            /// Provides a method that gets information about the mapping of metadata from an on-disk file into memory.
            /// </summary>
            public MetaDataInfo MetaDataInfo => new MetaDataInfo(module.GetMetaDataInterface<IMetaDataInfo>());

            /// <summary>
            /// Provides methods to create, modify, and save metadata about the assembly in the currently defined scope. The metadata can be stored in memory or saved to disk.
            /// </summary>
            public MetaDataEmit MetaDataEmit => new MetaDataEmit(module.GetMetaDataInterface<IMetaDataEmit>());

            /// <summary>
            /// Provides methods that support the self-description model used by the common language runtime to resolve and consume resources.
            /// </summary>
            public MetaDataAssemblyEmit MetaDataAssemblyEmit => new MetaDataAssemblyEmit(module.GetMetaDataInterface<IMetaDataAssemblyEmit>());

            /// <summary>
            /// Provides methods for marking and filtering metadata tokens to avoid repeating actions that have already been taken.
            /// </summary>
            public MetaDataFilter MetaDataFilter => new MetaDataFilter(module.GetMetaDataInterface<IMetaDataFilter>());
        }

        public static T GetMetaDataInterface<T>(this CorDebugModule module) => (T) module.GetMetaDataInterface(typeof(T).GUID);

        #endregion
    }
}
