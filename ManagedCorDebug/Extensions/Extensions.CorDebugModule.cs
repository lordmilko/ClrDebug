using System;

namespace ManagedCorDebug
{
    public static partial class Extensions
    {
        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from <see cref="CorDebugModule.GetMetaDataInterface(Guid)"/>.
        /// </summary>
        public class CorDebugModuleMetaDataInterfaces
        {
            private readonly CorDebugModule module;

            internal CorDebugModuleMetaDataInterfaces(CorDebugModule module)
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

        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from <see cref="CorDebugModule.GetMetaDataInterface(Guid)"/>.
        /// </summary>
        /// <param name="module">The <see cref="CLRControl"/> to use to retrieve the interfaces.</param>
        /// <returns>The common interfaces that can be retrieved from <see cref="CorDebugModule.GetMetaDataInterface(Guid)"/>.</returns>
        public static CorDebugModuleMetaDataInterfaces GetMetaDataInterface(this CorDebugModule module) => new CorDebugModuleMetaDataInterfaces(module);

        /// <summary>
        /// Gets a metadata interface object that can be used to examine the metadata for the module.
        /// </summary>
        /// <typeparam name="T">The type of interface to retrieve.</typeparam>
        /// <param name="module">The <see cref="CorDebugModule"/> object to use to retrieve the interface.</param>
        /// <returns>A pointer to the address of an IUnknown object that is one of the metadata interfaces.</returns>
        public static T GetMetaDataInterface<T>(this CorDebugModule module) => (T)module.GetMetaDataInterface(typeof(T).GUID);
    }
}
