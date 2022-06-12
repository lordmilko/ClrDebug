using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that support the self-description model used by the common language runtime to resolve and consume resources.
    /// </summary>
    [Guid("211EF15B-5317-4438-B196-DEC87B887693")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IMetaDataAssemblyEmit
    {
        /// <summary>
        /// Creates an Assembly structure containing metadata for the specified assembly and returns the associated metadata token.
        /// </summary>
        /// <param name="pbPublicKey">[in] The public key that identifies the publisher of the assembly, or NULL if the assembly is not strongly named.</param>
        /// <param name="cbPublicKey">[in] The size in bytes of pbPublicKey.</param>
        /// <param name="ulHashAlgId">[in] The identifier of the hashing algorithm to use to encrypt the files in the assembly, or NULL to specify the SHA-1 algorithm.</param>
        /// <param name="szName">[in] The human-readable text name of the assembly. This value must not exceed 1024 characters.</param>
        /// <param name="pMetaData">[in] A pointer to an <see cref="ASSEMBLYMETADATA"/> instance that contains the version, platform, and locale information for the assembly.</param>
        /// <param name="dwAssemblyFlags">[in] A combination of <see cref="CorAssemblyFlags"/> values that describe features of the assembly.</param>
        /// <param name="pma">[out] A pointer to the metadata token.</param>
        /// <remarks>
        /// Only one Assembly metadata structure can be defined within a manifest.
        /// </remarks>
        [PreserveSig]
        HRESULT DefineAssembly(
            IntPtr pbPublicKey,
            int cbPublicKey,
            int ulHashAlgId,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            IntPtr pMetaData,
            CorAssemblyFlags dwAssemblyFlags,
            out int pma);

        /// <summary>
        /// Creates an AssemblyRef structure containing metadata for the assembly that this assembly references, and returns the associated metadata token.
        /// </summary>
        /// <param name="pbPublicKeyOrToken">[in] The public key of the publisher of the referenced assembly. The helper function StrongNameTokenFromAssembly can be used to get the hash of the public key to pass as this parameter.</param>
        /// <param name="cbPublicKeyOrToken">[in] The size in bytes of pbPublicKeyOrToken.</param>
        /// <param name="szName">[in] The human-readable text name of the assembly. This value must not exceed 1024 characters.</param>
        /// <param name="pMetaData">[in] An <see cref="ASSEMBLYMETADATA"/> instance that contains the version, platform and locale information of the referenced assembly.</param>
        /// <param name="pbHashValue">[in] The hash data associated with the referenced assembly. Optional.</param>
        /// <param name="cbHashValue">[in] The size in bytes of pbHashValue.</param>
        /// <param name="dwAssemblyRefFlags">[in] A bitwise combination of <see cref="CorAssemblyFlags"/> values that influence the behavior of the execution engine.</param>
        /// <param name="assemblyRefToken">[out] A pointer to the returned AssemblyRef metadata token.</param>
        /// <remarks>
        /// One AssemblyRef metadata structure must be defined for each assembly that this assembly references. At run time,
        /// the details of a referenced assembly are passed to the assembly resolver with an indication that they represent
        /// the "as built" information. The assembly resolver then applies policy.
        /// </remarks>
        [PreserveSig]
        HRESULT DefineAssemblyRef(
            IntPtr pbPublicKeyOrToken,
            int cbPublicKeyOrToken,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] ASSEMBLYMETADATA pMetaData,
            IntPtr pbHashValue,
            int cbHashValue,
            CorAssemblyFlags dwAssemblyRefFlags,
            out int assemblyRefToken);

        /// <summary>
        /// Creates a File metadata structure containing metadata for assembly referenced by this assembly, and returns the associated metadata token.
        /// </summary>
        /// <param name="szName">[in] The name of the file to be consumed.</param>
        /// <param name="pbHashValue">[in] A pointer to the hash data associated with the assembly.</param>
        /// <param name="cbHashValue">[in] The size in bytes of pbHashValue.</param>
        /// <param name="dwFileFlags">[in] A bitwise combination of FileFlags values that specify property settings.</param>
        /// <param name="fileToken">[out] A pointer to the returned File token.</param>
        /// <remarks>
        /// One File metadata structure must be defined for each file that was part of this assembly at the time that this
        /// assembly was built, excluding the file that contains the metadata.
        /// </remarks>
        [PreserveSig]
        HRESULT DefineFile(
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            IntPtr pbHashValue,
            int cbHashValue,
            int dwFileFlags,
            out int fileToken);

        /// <summary>
        /// Creates an ExportedType structure containing metadata for the specified exported type, and returns the associated metadata token.
        /// </summary>
        /// <param name="szName">[in] The name of type to be exported. For version 1.1 of the common language runtime, the name of the exported type must exactly match the name given in the TypeDef for the type.</param>
        /// <param name="tkImplementation">[in] A token specifying where the exported type is implemented. The valid values and their associated meanings are:</param>
        /// <param name="tkTypeDef">[in] A token to the metadata that specifies the type to be exported. This value is entered in the TypeDef table in the file that implements the type and is relevant only if that file is in this assembly.</param>
        /// <param name="dwExportedTypeFlags">[in] A bitwise combination of <see cref="CorTypeAttr"/> enumeration values that define the property settings for the exported type.</param>
        /// <param name="pmdct">[out] A pointer to the returned metadata token that indicates the exported type.</param>
        /// <remarks>
        /// An ExportedType metadata structure must be defined for each type that is exposed by this assembly and that is implemented
        /// in a module other than the one containing the manifest.
        /// </remarks>
        [PreserveSig]
        HRESULT DefineExportedType(
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            mdToken tkImplementation,
            mdTypeDef tkTypeDef,
            int dwExportedTypeFlags,
            out int pmdct);

        /// <summary>
        /// Creates a ManifestResource structure containing metadata for the specified manifest resource, and returns the associated metadata token.
        /// </summary>
        /// <param name="szName">[in] The name of the resource.</param>
        /// <param name="tkImplementation">[in] A metadata token of type mdtFile or mdtAssemblyRef that maps to the resource provider. A NULL value indicates that the file in which the metadata is embedded is the resource provider.</param>
        /// <param name="dwOffset">[in] The offset to the beginning of the resource within the file. For resources in standalone files, this will always be zero.<para/>
        /// If the resource is embedded in a PE (portable executable) file, this is an offset of the resource BLOB, which starts at the location specified in the cor.h header file.</param>
        /// <param name="dwResourceFlags">[in] A bitwise combination of flag values that specify property settings for the resource definition.</param>
        /// <param name="pmdmr">[out] A pointer to the returned metadata token.</param>
        /// <remarks>
        /// One ManifestResource metadata structure must be defined for each resource that is implemented in each of the assembly's
        /// files.
        /// </remarks>
        [PreserveSig]
        HRESULT DefineManifestResource(
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            mdToken tkImplementation,
            int dwOffset,
            int dwResourceFlags,
            out int pmdmr);

        /// <summary>
        /// Modifies the specified Assembly metadata structure.
        /// </summary>
        /// <param name="pma">[in] The metadata token that specifies the Assembly metadata structure to be modified.</param>
        /// <param name="pbPublicKey">[in] A pointer to the public key of the publisher of the assembly.</param>
        /// <param name="cbPublicKey">[in] The size in bytes of pbPublicKey.</param>
        /// <param name="ulHashAlgId">[in] The identifier for the hash algorithm used to hash the assembly files.</param>
        /// <param name="szName">[in] The human-readable text name of the assembly.</param>
        /// <param name="pMetaData">[in] A pointer to the <see cref="ASSEMBLYMETADATA"/> that contains version, platform, and locale information for the assembly.</param>
        /// <param name="dwAssemblyFlags">[in] A bitwise combination of <see cref="AssemblyFlags"/> values that specify various attributes of the assembly.</param>
        /// <remarks>
        /// To create an Assembly metadata structure, use the <see cref="DefineAssembly"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT SetAssemblyProps(int pma,
            IntPtr pbPublicKey,
            int cbPublicKey,
            int ulHashAlgId,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            IntPtr pMetaData,
            int dwAssemblyFlags);

        /// <summary>
        /// Modifies the specified AssemblyRef metadata structure.
        /// </summary>
        /// <param name="ar">[in] The metadata token that specifies the AssemblyRef metadata structure to be modified.</param>
        /// <param name="pbPublicKeyOrToken">[in] The public key of the publisher of the referenced assembly.</param>
        /// <param name="cbPublicKeyOrToken">[in] The size in bytes of pbPublicKeyOrToken.</param>
        /// <param name="szName">[in] The human-readable text name of the assembly.</param>
        /// <param name="pMetaData">[in] A pointer to an <see cref="ASSEMBLYMETADATA"/> instance that contains the version, platform, and locale information for the assembly.</param>
        /// <param name="pbHashValue">[in] A pointer to the hash data associated with the assembly.</param>
        /// <param name="cbHashValue">[in] The size in bytes of pbHashValue.</param>
        /// <param name="dwAssemblyRefFlags">[in] A bitwise combination of <see cref="AssemblyRefFlags"/> values that specify attributes of the referenced assembly.</param>
        /// <remarks>
        /// To create an AssemblyRef metadata structure, use the <see cref="DefineAssemblyRef"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT SetAssemblyRefProps(
            int ar,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            IntPtr pbPublicKeyOrToken, int cbPublicKeyOrToken, [MarshalAs(UnmanagedType.LPWStr)] string szName, IntPtr pMetaData,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)]
            IntPtr pbHashValue,
            int cbHashValue,
            AssemblyRefFlags dwAssemblyRefFlags);

        /// <summary>
        /// Modifies the specified File metadata structure.
        /// </summary>
        /// <param name="file">[in] The metadata token that specifies the File metadata structure to be modified.</param>
        /// <param name="pbHashValue">[in] A pointer to the hash data associated with the file.</param>
        /// <param name="cbHashValue">[in] The size in bytes of pbHashValue.</param>
        /// <param name="dwFileFlags">[in] A bitwise combination of <see cref="CorFileFlags"/> values that specify various attributes of the file.</param>
        /// <remarks>
        /// To create a File metadata structure, use the <see cref="DefineFile"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT SetFileProps(
            int file,
            IntPtr pbHashValue,
            int cbHashValue,
            int dwFileFlags);

        /// <summary>
        /// Modifies the specified ExportedType metadata structure.
        /// </summary>
        /// <param name="ct">[in] The metadata token that specifies the ExportedType metadata structure to be modified.</param>
        /// <param name="tkImplementation">[in] The token, of type File, AssemblyRef, or ExportedType, that specifies how this type is implemented.</param>
        /// <param name="tkTypeDef">[in] The TypeDef token referenced in the code file.</param>
        /// <param name="dwExportedTypeFlags">[in] A bitwise combination of values that specify attributes of the type.</param>
        /// <remarks>
        /// To create an ExportedType metadata structure, use the <see cref="DefineExportedType"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT SetExportedTypeProps(
            int ct,
            mdToken tkImplementation,
            mdTypeDef tkTypeDef,
            int dwExportedTypeFlags);

        /// <summary>
        /// Modifies the specified ManifestResource metadata structure.
        /// </summary>
        /// <param name="mr">[in] The token that specifies the ManifestResource metadata structure to be modified.</param>
        /// <param name="tkImplementation">[in] The token, of type File or AssemblyRef, that maps to the resource provider.</param>
        /// <param name="dwOffset">[in] The offset to the beginning of the resource within the file.</param>
        /// <param name="dwResourceFlags">[in] A bitwise combination of flag values that specify the attributes of the resource.</param>
        /// <remarks>
        /// To create a ManifestResource metadata structure, use the <see cref="DefineManifestResource"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT SetManifestResourceProps(
            int mr,
            mdToken tkImplementation,
            int dwOffset,
            int dwResourceFlags);

    };
}