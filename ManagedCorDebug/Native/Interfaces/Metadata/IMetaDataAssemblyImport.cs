using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods to access and examine the contents of an assembly manifest.
    /// </summary>
    [ComImport]
    [Guid("EE62470B-E94B-424e-9B7C-2F00C9249F93")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMetaDataAssemblyImport
    {
        /// <summary>
        /// Gets the set of properties for the assembly with the specified metadata signature.
        /// </summary>
        /// <param name="mda">[in]. The <see cref="mdAssembly"/> metadata token that represents the assembly for which to get the properties.</param>
        /// <param name="ppbPublicKey">[out] A pointer to the public key or the metadata token.</param>
        /// <param name="pcbPublicKey">[out] The number of bytes in the returned public key.</param>
        /// <param name="pulHashAlgId">[out] A pointer to the algorithm used to hash the files in the assembly.</param>
        /// <param name="szName">[out] The simple name of the assembly.</param>
        /// <param name="cchName">[in] The size, in wide chars, of szName.</param>
        /// <param name="pchName">[out] The number of wide chars actually returned in szName.</param>
        /// <param name="pMetaData">[out] A pointer to an <see cref="ASSEMBLYMETADATA"/> structure that contains the assembly metadata.</param>
        /// <param name="pdwAssemblyFlags">[out] Flags that describe the metadata applied to an assembly. This value is a combination of one or more <see cref="CorAssemblyFlags"/> values.</param>
        [PreserveSig]
        HRESULT GetAssemblyProps(
            [In] mdAssembly mda,
            [Out] out IntPtr ppbPublicKey,
            [Out] out int pcbPublicKey,
            [Out] out int pulHashAlgId,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
            [In] int cchName,
            [Out] out int pchName,
            [Out] out ASSEMBLYMETADATA pMetaData,
            [Out] out CorAssemblyFlags pdwAssemblyFlags);

        /// <summary>
        /// Gets the set of properties for the assembly reference with the specified metadata signature.
        /// </summary>
        /// <param name="mdar">[in] The <see cref="mdAssemblyRef"/> metadata token that represents the assembly reference for which to get the properties.</param>
        /// <param name="ppbPublicKeyOrToken">[out] A pointer to the public key or the metadata token.</param>
        /// <param name="pcbPublicKeyOrToken">[out] The number of bytes in the returned public key or token.</param>
        /// <param name="szName">[out] The simple name of the assembly.</param>
        /// <param name="cchName">[in] The size, in wide chars, of szName.</param>
        /// <param name="pchName">[out] A pointer to the number of wide chars actually returned in szName.</param>
        /// <param name="pMetaData">[out] A pointer to an <see cref="ASSEMBLYMETADATA"/> structure that contains the assembly metadata.</param>
        /// <param name="ppbHashValue">[out] A pointer to the hash value. This is the hash, using the SHA-1 algorithm, of the PublicKey property of the assembly being referenced, unless the arfFullOriginator flag of the <see cref="AssemblyRefFlags"/> enumeration is set.</param>
        /// <param name="pcbHashValue">[out] The number of wide chars in the returned hash value.</param>
        /// <param name="pdwAssemblyFlags">[out] A pointer to flags that describe the metadata applied to an assembly. The flags value is a combination of one or more <see cref="CorAssemblyFlags"/> values.</param>
        /// <returns>This method returns S_OK if it succeeds; otherwise, it returns one of the error codes defined in the Winerror.h header file.</returns>
        [PreserveSig]
        HRESULT GetAssemblyRefProps(
            [In] mdAssemblyRef mdar,
            [Out] IntPtr ppbPublicKeyOrToken,
            [Out] out int pcbPublicKeyOrToken,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
            [In] int cchName,
            [Out] out int pchName,
            [Out] out ASSEMBLYMETADATA pMetaData,
            [Out] IntPtr ppbHashValue,
            [Out] out int pcbHashValue,
            [Out] out CorAssemblyFlags pdwAssemblyFlags);

        /// <summary>
        /// Gets the properties of the file with the specified metadata signature.
        /// </summary>
        /// <param name="mdf">[in] The <see cref="mdFile"/> metadata token that represents the file for which to get the properties.</param>
        /// <param name="szName">[out] The simple name of the file.</param>
        /// <param name="cchName">[in] The size, in wide chars, of szName.</param>
        /// <param name="pchName">[out] The number of wide chars actually returned in szName.</param>
        /// <param name="ppbHashValue">[out] A pointer to the hash value. This is the hash, using the SHA-1 algorithm, of the file.</param>
        /// <param name="pcbHashValue">[out] The number of wide chars in the returned hash value.</param>
        /// <param name="pdwFileFlags">[out] A pointer to the flags that describe the metadata applied to a file. The flags value is a combination of one or more <see cref="CorFileFlags"/> values.</param>
        [PreserveSig]
        HRESULT GetFileProps(
            [In] mdFile mdf,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
            [In] int cchName,
            [Out] out int pchName,
            [Out] IntPtr ppbHashValue,
            [Out] out int pcbHashValue,
            [Out] out CorFileFlags pdwFileFlags);

        /// <summary>
        /// Gets the set of properties of the exported type with the specified metadata signature.
        /// </summary>
        /// <param name="mdct">[in] An <see cref="mdExportedType"/> metadata token that represents the exported type.</param>
        /// <param name="szName">[out] The name of the exported type.</param>
        /// <param name="cchName">[in] The size, in wide characters, of szName.</param>
        /// <param name="pchName">[out] The number of wide characters actually returned in szName</param>
        /// <param name="ptkImplementation">[out] An <see cref="mdFile"/>, <see cref="mdAssemblyRef"/>, or <see cref="mdExportedType"/> metadata token that contains or allows access to the properties of the exported type.</param>
        /// <param name="ptkTypeDef">[out] A pointer to an <see cref="mdTypeDef"/> token that represents a type in the file.</param>
        /// <param name="pdwExportedTypeFlags">[out] A pointer to the flags that describe the metadata applied to the exported type. The flags value can be one or more <see cref="CorTypeAttr"/> values.</param>
        [PreserveSig]
        HRESULT GetExportedTypeProps(
            [In] mdExportedType mdct,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
            [In] int cchName,
            [Out] out int pchName,
            [Out] out int ptkImplementation,
            [Out] out mdTypeDef ptkTypeDef,
            [Out] out CorTypeAttr pdwExportedTypeFlags);

        /// <summary>
        /// Gets the set of properties of the manifest resource with the specified metadata signature.
        /// </summary>
        /// <param name="mdmr">[in] An <see cref="mdManifestResource"/> token that represents the resource for which to get the properties.</param>
        /// <param name="szName">[out] The name of the resource.</param>
        /// <param name="cchName">[in] The size, in wide chars, of szName.</param>
        /// <param name="pchName">[out] A pointer to the number of wide chars actually returned in szName.</param>
        /// <param name="ptkImplementation">[out] A pointer to an <see cref="mdFile"/> token or an <see cref="mdAssemblyRef"/> token that represents the file or assembly, respectively, that contains the resource.</param>
        /// <param name="pdwOffset">[out] A pointer to a value that specifies the offset to the beginning of the resource within the file.</param>
        /// <param name="pdwResourceFlags">[out] A pointer to flags that describe the metadata applied to a resource. The flags value is a combination of one or more <see cref="CorManifestResourceFlags"/> values.</param>
        [PreserveSig]
        HRESULT GetManifestResourceProps(
            [In] mdManifestResource mdmr,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
            [In] int cchName,
            [Out] out int pchName,
            [Out] out int ptkImplementation,
            [Out] out int pdwOffset,
            [Out] out CorManifestResourceFlags pdwResourceFlags);

        /// <summary>
        /// Enumerates the <see cref="mdAssemblyRef"/> instances that are defined in the assembly manifest.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be a null value when the EnumAssemblyRefs method is called for the first time.</param>
        /// <param name="rAssemblyRefs">[out] The enumeration of <see cref="mdAssemblyRef"/> metadata tokens.</param>
        /// <param name="cMax">[in] The maximum number of tokens that can be placed in the rAssemblyRefs array.</param>
        /// <param name="pcTokens">[out] The number of tokens actually placed in rAssemblyRefs.</param>
        /// <returns>
        /// | HRESULT | Description                                                              |
        /// | ------- | ------------------------------------------------------------------------ |
        /// | S_OK    | EnumAssemblyRefs returned successfully.                                  |
        /// | S_FALSE | There are no tokens to enumerate. In this case, pcTokens is set to zero. |
        /// </returns>
        [PreserveSig]
        HRESULT EnumAssemblyRefs(
            [In] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray)] mdAssemblyRef[] rAssemblyRefs,
            [In] int cMax,
            [Out] out int pcTokens);

        /// <summary>
        /// Enumerates the files referenced in the current assembly manifest.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be a null value for the first call of this method.</param>
        /// <param name="rFiles">[out] The array used to store the <see cref="mdFile"/> metadata tokens.</param>
        /// <param name="cMax">[in] The maximum number of <see cref="mdFile"/> tokens that can be placed in rFiles.</param>
        /// <param name="pcTokens">[out] The number of <see cref="mdFile"/> tokens actually placed in rFiles.</param>
        /// <returns>
        /// | HRESULT | Description                                                              |
        /// | ------- | ------------------------------------------------------------------------ |
        /// | S_OK    | EnumFiles returned successfully.                                         |
        /// | S_FALSE | There are no tokens to enumerate. In this case, pcTokens is set to zero. |
        /// </returns>
        [PreserveSig]
        HRESULT EnumFiles(
            [In] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray)] mdFile[] rFiles,
            [In] int cMax,
            [Out] out int pcTokens);

        /// <summary>
        /// Enumerates the exported types referenced in the assembly manifest in the current metadata scope.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be a null value when the EnumExportedTypes method is called for the first time.</param>
        /// <param name="rExportedTypes">[out] The enumeration of <see cref="mdExportedType"/> metadata tokens.</param>
        /// <param name="cMax">[in] The maximum number of <see cref="mdExportedType"/> tokens that can be placed in the rExportedTypes array.</param>
        /// <param name="pcTokens">[out] The number of <see cref="mdExportedType"/> tokens actually placed in rExportedTypes.</param>
        /// <returns>
        /// | HRESULT | Description                                                              |
        /// | ------- | ------------------------------------------------------------------------ |
        /// | S_OK    | EnumExportedTypes returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In this case, pcTokens is set to zero. |
        /// </returns>
        [PreserveSig]
        HRESULT EnumExportedTypes(
            [In] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray)] mdExportedType[] rExportedTypes,
            [In] int cMax,
            [Out] out int pcTokens);

        /// <summary>
        /// Gets a pointer to an enumerator for the resources referenced in the current assembly manifest.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be a null value when the EnumManifestResources method is called for the first time.</param>
        /// <param name="rManifestResources">[out] The array used to store the <see cref="mdManifestResource"/> metadata tokens.</param>
        /// <param name="cMax">[in] The maximum number of <see cref="mdManifestResource"/> tokens that can be placed in rManifestResources.</param>
        /// <param name="pcTokens">[out] The number of <see cref="mdManifestResource"/> tokens actually placed in rManifestResources.</param>
        /// <returns>
        /// | HRESULT | Description                                                              |
        /// | ------- | ------------------------------------------------------------------------ |
        /// | S_OK    | EnumManifestResources returned successfully.                             |
        /// | S_FALSE | There are no tokens to enumerate. In this case, pcTokens is set to zero. |
        /// </returns>
        [PreserveSig]
        HRESULT EnumManifestResources(
            [In] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray)] mdManifestResource[] rManifestResources,
            [In] int cMax,
            [Out] out int pcTokens);

        /// <summary>
        /// Gets a pointer to the assembly in the current scope.
        /// </summary>
        /// <param name="ptkAssembly">[out] A pointer to the retrieved <see cref="mdAssembly"/> token that identifies the assembly.</param>
        [PreserveSig]
        HRESULT GetAssemblyFromScope(
            [Out] out mdAssembly ptkAssembly);

        /// <summary>
        /// Gets a pointer to an exported type, given its name and enclosing type.
        /// </summary>
        /// <param name="szName">[in] The name of the exported type.</param>
        /// <param name="mdtExportedType">[in] The metadata token for the enclosing class of the exported type. This value is mdExportedTypeNil if the requested exported type is not a nested type.</param>
        /// <param name="mdExportedType">[out] A pointer to the <see cref="mdExportedType"/> token that represents the exported type.</param>
        /// <remarks>
        /// The FindExportedTypeByName method uses the standard rules employed by the common language runtime for resolving
        /// references.
        /// </remarks>
        [PreserveSig]
        HRESULT FindExportedTypeByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] int mdtExportedType,
            [Out] out mdExportedType mdExportedType);

        /// <summary>
        /// Gets a pointer to the manifest resource with the specified name.
        /// </summary>
        /// <param name="szName">[in] The name of the resource.</param>
        /// <param name="ptkManifestResource">[out] The array used to store the <see cref="mdManifestResource"/> metadata tokens, each of which represents a manifest resource.</param>
        /// <remarks>
        /// The FindManifestResourceByName method uses the standard rules employed by the common language runtime for resolving
        /// references.
        /// </remarks>
        [PreserveSig]
        HRESULT FindManifestResourceByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [Out] out mdManifestResource[] ptkManifestResource);

        /// <summary>
        /// Releases a reference to the specified enumeration instance.
        /// </summary>
        /// <param name="hEnum">[in] The enumeration instance to be closed.</param>
        [PreserveSig]
        HRESULT CloseEnum(
            [In] IntPtr hEnum);

        /// <summary>
        /// Gets an array of assemblies with the specified szAssemblyName parameter, using the standard rules employed by the common language runtime (CLR) for resolving references.
        /// </summary>
        /// <param name="szAppBase">[in] The root directory in which to search for the given assembly. If this value is set to null, FindAssembliesByName will look only in the global assembly cache for the assembly.</param>
        /// <param name="szPrivateBin">[in] A list of semicolon-delimited subdirectories (for example, "bin;bin2"), under the root directory, in which to search for the assembly.<para/>
        /// These directories are probed in addition to those specified in the default probing rules.</param>
        /// <param name="szAssemblyName">[in] The name of the assembly to find. The format of this string is defined in the class reference page for <see cref="AssemblyName"/>.</param>
        /// <param name="ppIUnk">[out] An array that holds the <see cref="IMetaDataAssemblyImport"/> interface pointers.</param>
        /// <param name="cMax">[in] The maximum number of interface pointers to place in ppIUnk.</param>
        /// <param name="pcAssemblies">[out] The number of interface pointers returnedthat is, the number of interface pointers actually placed in ppIUnk.</param>
        /// <returns>
        /// | HRESULT | Description                                 |
        /// | ------- | ------------------------------------------- |
        /// | S_OK    | FindAssembliesByName returned successfully. |
        /// | S_FALSE | There are no assemblies.                    |
        /// </returns>
        /// <remarks>
        /// Given an assembly name, the FindAssembliesByName method finds the assembly by following the standard rules for
        /// resolving assembly references. (For more information, see How the Runtime Locates Assemblies.) FindAssembliesByName
        /// allows the caller to configure various aspects of the assembly resolver context, such as application base and private
        /// search path. The FindAssembliesByName method requires the CLR to be initialized in the process in order to invoke
        /// the assembly resolution logic. Therefore, you must call CoInitializeEE (passing COINITEE_DEFAULT) before calling
        /// FindAssembliesByName, and then follow with a call to CoUninitializeCor. FindAssembliesByName returns an <see cref="IMetaDataImport"/>
        /// pointer to the file containing the assembly manifest for the assembly name that is passed in. If the given assembly
        /// name is not fully specified (for example, if it does not include a version), multiple assemblies might be returned.
        /// FindAssembliesByName is commonly used by a compiler that attempts to find a referenced assembly at compile time.
        /// </remarks>
        [PreserveSig]
        HRESULT FindAssembliesByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAppBase,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szPrivateBin,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAssemblyName,
            [Out, MarshalAs(UnmanagedType.Interface)] out object[] ppIUnk,
            [In] int cMax,
            [Out] out int pcAssemblies);
    }
}