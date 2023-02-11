using System;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that support the self-description model used by the common language runtime to resolve and consume resources.
    /// </summary>
    public class MetaDataAssemblyEmit : ComObject<IMetaDataAssemblyEmit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaDataAssemblyEmit"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public MetaDataAssemblyEmit(IMetaDataAssemblyEmit raw) : base(raw)
        {
        }

        #region IMetaDataAssemblyEmit
        #region DefineAssembly

        /// <summary>
        /// Creates an Assembly structure containing metadata for the specified assembly and returns the associated metadata token.
        /// </summary>
        /// <param name="pbPublicKey">[in] The public key that identifies the publisher of the assembly, or NULL if the assembly is not strongly named.</param>
        /// <param name="cbPublicKey">[in] The size in bytes of pbPublicKey.</param>
        /// <param name="ulHashAlgId">[in] The identifier of the hashing algorithm to use to encrypt the files in the assembly, or NULL to specify the SHA-1 algorithm.</param>
        /// <param name="szName">[in] The human-readable text name of the assembly. This value must not exceed 1024 characters.</param>
        /// <param name="pMetaData">[in] A pointer to an <see cref="ASSEMBLYMETADATA"/> instance that contains the version, platform, and locale information for the assembly.</param>
        /// <param name="dwAssemblyFlags">[in] A combination of <see cref="CorAssemblyFlags"/> values that describe features of the assembly.</param>
        /// <returns>[out] A pointer to the metadata token.</returns>
        /// <remarks>
        /// Only one Assembly metadata structure can be defined within a manifest.
        /// </remarks>
        public mdAssembly DefineAssembly(IntPtr pbPublicKey, int cbPublicKey, int ulHashAlgId, string szName, ASSEMBLYMETADATA pMetaData, CorAssemblyFlags dwAssemblyFlags)
        {
            mdAssembly pma;
            TryDefineAssembly(pbPublicKey, cbPublicKey, ulHashAlgId, szName, pMetaData, dwAssemblyFlags, out pma).ThrowOnNotOK();

            return pma;
        }

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
        public HRESULT TryDefineAssembly(IntPtr pbPublicKey, int cbPublicKey, int ulHashAlgId, string szName, ASSEMBLYMETADATA pMetaData, CorAssemblyFlags dwAssemblyFlags, out mdAssembly pma)
        {
            /*HRESULT DefineAssembly(
            [In] IntPtr pbPublicKey,
            [In] int cbPublicKey,
            [In] int ulHashAlgId,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] ref ASSEMBLYMETADATA pMetaData,
            [In] CorAssemblyFlags dwAssemblyFlags,
            [Out] out mdAssembly pma);*/
            return Raw.DefineAssembly(pbPublicKey, cbPublicKey, ulHashAlgId, szName, ref pMetaData, dwAssemblyFlags, out pma);
        }

        #endregion
        #region DefineAssemblyRef

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
        /// <returns>[out] A pointer to the returned AssemblyRef metadata token.</returns>
        /// <remarks>
        /// One AssemblyRef metadata structure must be defined for each assembly that this assembly references. At run time,
        /// the details of a referenced assembly are passed to the assembly resolver with an indication that they represent
        /// the "as built" information. The assembly resolver then applies policy.
        /// </remarks>
        public mdAssemblyRef DefineAssemblyRef(IntPtr pbPublicKeyOrToken, int cbPublicKeyOrToken, string szName, ASSEMBLYMETADATA pMetaData, IntPtr pbHashValue, int cbHashValue, CorAssemblyFlags dwAssemblyRefFlags)
        {
            mdAssemblyRef assemblyRefToken;
            TryDefineAssemblyRef(pbPublicKeyOrToken, cbPublicKeyOrToken, szName, pMetaData, pbHashValue, cbHashValue, dwAssemblyRefFlags, out assemblyRefToken).ThrowOnNotOK();

            return assemblyRefToken;
        }

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
        public HRESULT TryDefineAssemblyRef(IntPtr pbPublicKeyOrToken, int cbPublicKeyOrToken, string szName, ASSEMBLYMETADATA pMetaData, IntPtr pbHashValue, int cbHashValue, CorAssemblyFlags dwAssemblyRefFlags, out mdAssemblyRef assemblyRefToken)
        {
            /*HRESULT DefineAssemblyRef(
            [In] IntPtr pbPublicKeyOrToken,
            [In] int cbPublicKeyOrToken,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] ref ASSEMBLYMETADATA pMetaData,
            [In] IntPtr pbHashValue,
            [In] int cbHashValue,
            [In] CorAssemblyFlags dwAssemblyRefFlags,
            [Out] out mdAssemblyRef assemblyRefToken);*/
            return Raw.DefineAssemblyRef(pbPublicKeyOrToken, cbPublicKeyOrToken, szName, ref pMetaData, pbHashValue, cbHashValue, dwAssemblyRefFlags, out assemblyRefToken);
        }

        #endregion
        #region DefineFile

        /// <summary>
        /// Creates a File metadata structure containing metadata for assembly referenced by this assembly, and returns the associated metadata token.
        /// </summary>
        /// <param name="szName">[in] The name of the file to be consumed.</param>
        /// <param name="pbHashValue">[in] A pointer to the hash data associated with the assembly.</param>
        /// <param name="cbHashValue">[in] The size in bytes of pbHashValue.</param>
        /// <param name="dwFileFlags">[in] A bitwise combination of FileFlags values that specify property settings.</param>
        /// <returns>[out] A pointer to the returned File token.</returns>
        /// <remarks>
        /// One File metadata structure must be defined for each file that was part of this assembly at the time that this
        /// assembly was built, excluding the file that contains the metadata.
        /// </remarks>
        public int DefineFile(string szName, IntPtr pbHashValue, int cbHashValue, CorFileFlags dwFileFlags)
        {
            int fileToken;
            TryDefineFile(szName, pbHashValue, cbHashValue, dwFileFlags, out fileToken).ThrowOnNotOK();

            return fileToken;
        }

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
        public HRESULT TryDefineFile(string szName, IntPtr pbHashValue, int cbHashValue, CorFileFlags dwFileFlags, out int fileToken)
        {
            /*HRESULT DefineFile(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] IntPtr pbHashValue,
            [In] int cbHashValue,
            [In] CorFileFlags dwFileFlags,
            [Out] out int fileToken);*/
            return Raw.DefineFile(szName, pbHashValue, cbHashValue, dwFileFlags, out fileToken);
        }

        #endregion
        #region DefineExportedType

        /// <summary>
        /// Creates an ExportedType structure containing metadata for the specified exported type, and returns the associated metadata token.
        /// </summary>
        /// <param name="szName">[in] The name of type to be exported. For version 1.1 of the common language runtime, the name of the exported type must exactly match the name given in the TypeDef for the type.</param>
        /// <param name="tkImplementation">[in] A token specifying where the exported type is implemented. The valid values and their associated meanings are:</param>
        /// <param name="tkTypeDef">[in] A token to the metadata that specifies the type to be exported. This value is entered in the TypeDef table in the file that implements the type and is relevant only if that file is in this assembly.</param>
        /// <param name="dwExportedTypeFlags">[in] A bitwise combination of <see cref="CorTypeAttr"/> enumeration values that define the property settings for the exported type.</param>
        /// <returns>[out] A pointer to the returned metadata token that indicates the exported type.</returns>
        /// <remarks>
        /// An ExportedType metadata structure must be defined for each type that is exposed by this assembly and that is implemented
        /// in a module other than the one containing the manifest.
        /// </remarks>
        public mdExportedType DefineExportedType(string szName, mdToken tkImplementation, mdTypeDef tkTypeDef, CorTypeAttr dwExportedTypeFlags)
        {
            mdExportedType pmdct;
            TryDefineExportedType(szName, tkImplementation, tkTypeDef, dwExportedTypeFlags, out pmdct).ThrowOnNotOK();

            return pmdct;
        }

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
        public HRESULT TryDefineExportedType(string szName, mdToken tkImplementation, mdTypeDef tkTypeDef, CorTypeAttr dwExportedTypeFlags, out mdExportedType pmdct)
        {
            /*HRESULT DefineExportedType(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] mdToken tkImplementation,
            [In] mdTypeDef tkTypeDef,
            [In] CorTypeAttr dwExportedTypeFlags,
            [Out] out mdExportedType pmdct);*/
            return Raw.DefineExportedType(szName, tkImplementation, tkTypeDef, dwExportedTypeFlags, out pmdct);
        }

        #endregion
        #region DefineManifestResource

        /// <summary>
        /// Creates a ManifestResource structure containing metadata for the specified manifest resource, and returns the associated metadata token.
        /// </summary>
        /// <param name="szName">[in] The name of the resource.</param>
        /// <param name="tkImplementation">[in] A metadata token of type mdtFile or mdtAssemblyRef that maps to the resource provider. A NULL value indicates that the file in which the metadata is embedded is the resource provider.</param>
        /// <param name="dwOffset">[in] The offset to the beginning of the resource within the file. For resources in standalone files, this will always be zero.<para/>
        /// If the resource is embedded in a PE (portable executable) file, this is an offset of the resource BLOB, which starts at the location specified in the cor.h header file.</param>
        /// <param name="dwResourceFlags">[in] A bitwise combination of flag values that specify property settings for the resource definition.</param>
        /// <returns>[out] A pointer to the returned metadata token.</returns>
        /// <remarks>
        /// One ManifestResource metadata structure must be defined for each resource that is implemented in each of the assembly's
        /// files.
        /// </remarks>
        public mdManifestResource DefineManifestResource(string szName, mdToken tkImplementation, int dwOffset, CorManifestResourceFlags dwResourceFlags)
        {
            mdManifestResource pmdmr;
            TryDefineManifestResource(szName, tkImplementation, dwOffset, dwResourceFlags, out pmdmr).ThrowOnNotOK();

            return pmdmr;
        }

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
        public HRESULT TryDefineManifestResource(string szName, mdToken tkImplementation, int dwOffset, CorManifestResourceFlags dwResourceFlags, out mdManifestResource pmdmr)
        {
            /*HRESULT DefineManifestResource(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] mdToken tkImplementation,
            [In] int dwOffset,
            [In] CorManifestResourceFlags dwResourceFlags,
            [Out] out mdManifestResource pmdmr);*/
            return Raw.DefineManifestResource(szName, tkImplementation, dwOffset, dwResourceFlags, out pmdmr);
        }

        #endregion
        #region SetAssemblyProps

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
        public void SetAssemblyProps(mdAssembly pma, IntPtr pbPublicKey, int cbPublicKey, int ulHashAlgId, string szName, ASSEMBLYMETADATA pMetaData, AssemblyFlags dwAssemblyFlags)
        {
            TrySetAssemblyProps(pma, pbPublicKey, cbPublicKey, ulHashAlgId, szName, pMetaData, dwAssemblyFlags).ThrowOnNotOK();
        }

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
        public HRESULT TrySetAssemblyProps(mdAssembly pma, IntPtr pbPublicKey, int cbPublicKey, int ulHashAlgId, string szName, ASSEMBLYMETADATA pMetaData, AssemblyFlags dwAssemblyFlags)
        {
            /*HRESULT SetAssemblyProps(
            [In] mdAssembly pma,
            [In] IntPtr pbPublicKey,
            [In] int cbPublicKey,
            [In] int ulHashAlgId,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] ref ASSEMBLYMETADATA pMetaData,
            [In] AssemblyFlags dwAssemblyFlags);*/
            return Raw.SetAssemblyProps(pma, pbPublicKey, cbPublicKey, ulHashAlgId, szName, ref pMetaData, dwAssemblyFlags);
        }

        #endregion
        #region SetAssemblyRefProps

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
        public void SetAssemblyRefProps(mdAssemblyRef ar, IntPtr pbPublicKeyOrToken, int cbPublicKeyOrToken, string szName, ASSEMBLYMETADATA pMetaData, IntPtr pbHashValue, int cbHashValue, AssemblyRefFlags dwAssemblyRefFlags)
        {
            TrySetAssemblyRefProps(ar, pbPublicKeyOrToken, cbPublicKeyOrToken, szName, pMetaData, pbHashValue, cbHashValue, dwAssemblyRefFlags).ThrowOnNotOK();
        }

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
        public HRESULT TrySetAssemblyRefProps(mdAssemblyRef ar, IntPtr pbPublicKeyOrToken, int cbPublicKeyOrToken, string szName, ASSEMBLYMETADATA pMetaData, IntPtr pbHashValue, int cbHashValue, AssemblyRefFlags dwAssemblyRefFlags)
        {
            /*HRESULT SetAssemblyRefProps(
            [In] mdAssemblyRef ar,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr pbPublicKeyOrToken,
            [In] int cbPublicKeyOrToken,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] ref ASSEMBLYMETADATA pMetaData,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] IntPtr pbHashValue,
            [In] int cbHashValue,
            [In] AssemblyRefFlags dwAssemblyRefFlags);*/
            return Raw.SetAssemblyRefProps(ar, pbPublicKeyOrToken, cbPublicKeyOrToken, szName, ref pMetaData, pbHashValue, cbHashValue, dwAssemblyRefFlags);
        }

        #endregion
        #region SetFileProps

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
        public void SetFileProps(mdFile file, IntPtr pbHashValue, int cbHashValue, CorFileFlags dwFileFlags)
        {
            TrySetFileProps(file, pbHashValue, cbHashValue, dwFileFlags).ThrowOnNotOK();
        }

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
        public HRESULT TrySetFileProps(mdFile file, IntPtr pbHashValue, int cbHashValue, CorFileFlags dwFileFlags)
        {
            /*HRESULT SetFileProps(
            [In] mdFile file,
            [In] IntPtr pbHashValue,
            [In] int cbHashValue,
            [In] CorFileFlags dwFileFlags);*/
            return Raw.SetFileProps(file, pbHashValue, cbHashValue, dwFileFlags);
        }

        #endregion
        #region SetExportedTypeProps

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
        public void SetExportedTypeProps(mdExportedType ct, mdToken tkImplementation, mdTypeDef tkTypeDef, CorTypeAttr dwExportedTypeFlags)
        {
            TrySetExportedTypeProps(ct, tkImplementation, tkTypeDef, dwExportedTypeFlags).ThrowOnNotOK();
        }

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
        public HRESULT TrySetExportedTypeProps(mdExportedType ct, mdToken tkImplementation, mdTypeDef tkTypeDef, CorTypeAttr dwExportedTypeFlags)
        {
            /*HRESULT SetExportedTypeProps(
            [In] mdExportedType ct,
            [In] mdToken tkImplementation,
            [In] mdTypeDef tkTypeDef,
            [In] CorTypeAttr dwExportedTypeFlags);*/
            return Raw.SetExportedTypeProps(ct, tkImplementation, tkTypeDef, dwExportedTypeFlags);
        }

        #endregion
        #region SetManifestResourceProps

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
        public void SetManifestResourceProps(mdManifestResource mr, mdToken tkImplementation, int dwOffset, CorManifestResourceFlags dwResourceFlags)
        {
            TrySetManifestResourceProps(mr, tkImplementation, dwOffset, dwResourceFlags).ThrowOnNotOK();
        }

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
        public HRESULT TrySetManifestResourceProps(mdManifestResource mr, mdToken tkImplementation, int dwOffset, CorManifestResourceFlags dwResourceFlags)
        {
            /*HRESULT SetManifestResourceProps(
            [In] mdManifestResource mr,
            [In] mdToken tkImplementation,
            [In] int dwOffset,
            [In] CorManifestResourceFlags dwResourceFlags);*/
            return Raw.SetManifestResourceProps(mr, tkImplementation, dwOffset, dwResourceFlags);
        }

        #endregion
        #endregion
    }
}
