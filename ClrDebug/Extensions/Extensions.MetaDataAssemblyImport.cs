using System;

namespace ClrDebug
{
    public static partial class Extensions
    {
        private static readonly mdAssemblyRef[] NoAssemblyRefs = new mdAssemblyRef[0];
        private static readonly mdExportedType[] NoExportedTypes = new mdExportedType[0];
        private static readonly mdFile[] NoFiles = new mdFile[0];
        private static readonly mdManifestResource[] NoManifestResources = new mdManifestResource[0];

        /// <summary>
        /// Enumerates the <see cref="mdAssemblyRef"/> instances that are defined in the assembly manifest.
        /// </summary>
        /// <param name="metaDataAssemblyImport">The <see cref="MetaDataAssemblyImport"/> to use to enumerate the tokens.</param>
        /// <returns>The array used to store the AssemblyRef tokens.</returns>
        public static mdAssemblyRef[] EnumAssemblyRefs(this MetaDataAssemblyImport metaDataAssemblyImport)
        {
            IntPtr hEnum = IntPtr.Zero;
            int pcTokens;
            metaDataAssemblyImport.TryEnumAssemblyRefs(ref hEnum, null, out pcTokens).ThrowOnFailed();

            if (hEnum == IntPtr.Zero)
                return NoAssemblyRefs;

            try
            {
                ((IMetaDataImport)metaDataAssemblyImport.Raw).CountEnum(hEnum, out var count).ThrowOnNotOK();

                var buffer = new mdAssemblyRef[count];

                metaDataAssemblyImport.EnumAssemblyRefs(ref hEnum, buffer);

                return buffer;
            }
            finally
            {
                metaDataAssemblyImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates the files referenced in the current assembly manifest.
        /// </summary>
        /// <param name="metaDataAssemblyImport">The <see cref="MetaDataAssemblyImport"/> to use to enumerate the tokens.</param>
        /// <returns>the array used to store the file tokens.</returns>
        public static mdFile[] EnumFiles(this MetaDataAssemblyImport metaDataAssemblyImport)
        {
            IntPtr hEnum = IntPtr.Zero;
            int pcTokens;
            metaDataAssemblyImport.TryEnumFiles(ref hEnum, null, out pcTokens).ThrowOnFailed();

            if (hEnum == IntPtr.Zero)
                return NoFiles;

            try
            {
                ((IMetaDataImport)metaDataAssemblyImport.Raw).CountEnum(hEnum, out var count).ThrowOnNotOK();

                var buffer = new mdFile[count];

                metaDataAssemblyImport.EnumFiles(ref hEnum, buffer);

                return buffer;
            }
            finally
            {
                metaDataAssemblyImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates the exported types referenced in the assembly manifest in the current metadata scope.
        /// </summary>
        /// <param name="metaDataAssemblyImport">The <see cref="MetaDataAssemblyImport"/> to use to enumerate the tokens.</param>
        /// <returns>The array used to store the ExportedType tokens.</returns>
        public static mdExportedType[] EnumExportedTypes(this MetaDataAssemblyImport metaDataAssemblyImport)
        {
            IntPtr hEnum = IntPtr.Zero;
            int pcTokens;
            metaDataAssemblyImport.TryEnumExportedTypes(ref hEnum, null, out pcTokens).ThrowOnFailed();

            if (hEnum == IntPtr.Zero)
                return NoExportedTypes;

            try
            {
                ((IMetaDataImport) metaDataAssemblyImport.Raw).CountEnum(hEnum, out var count).ThrowOnNotOK();

                var buffer = new mdExportedType[count];

                metaDataAssemblyImport.EnumExportedTypes(ref hEnum, buffer);

                return buffer;
            }
            finally
            {
                metaDataAssemblyImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Gets a pointer to an enumerator for the resources referenced in the current assembly manifest.
        /// </summary>
        /// <param name="metaDataAssemblyImport">The <see cref="MetaDataAssemblyImport"/> to use to enumerate the tokens.</param>
        /// <returns>The array used to store the ManifestResource tokens.</returns>
        public static mdManifestResource[] EnumManifestResources(this MetaDataAssemblyImport metaDataAssemblyImport)
        {
            IntPtr hEnum = IntPtr.Zero;
            int pcTokens;
            metaDataAssemblyImport.TryEnumManifestResources(ref hEnum, null, out pcTokens).ThrowOnFailed();

            if (hEnum == IntPtr.Zero)
                return NoManifestResources;

            try
            {
                ((IMetaDataImport)metaDataAssemblyImport.Raw).CountEnum(hEnum, out var count).ThrowOnNotOK();

                var buffer = new mdManifestResource[count];

                metaDataAssemblyImport.EnumManifestResources(ref hEnum, buffer);

                return buffer;
            }
            finally
            {
                metaDataAssemblyImport.CloseEnum(hEnum);
            }
        }
    }
}
