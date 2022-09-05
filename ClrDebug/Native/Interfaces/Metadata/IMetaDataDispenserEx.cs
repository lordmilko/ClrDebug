using System;
using System.Runtime.InteropServices;
using System.Text;
using ClrDebug.TypeLib;

namespace ClrDebug
{
    /// <summary>
    /// Extends the <see cref="IMetaDataDispenser"/> interface to provide the capability to control how the metadata APIs operate on the current metadata scope.
    /// </summary>
    [Guid("31BCFCE2-DAFB-11D2-9F81-00C04F79A0A3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IMetaDataDispenserEx : IMetaDataDispenser
    {
        /// <summary>
        /// Creates a new area in memory in which you can create new metadata.
        /// </summary>
        /// <param name="rclsid">[in] The CLSID of the version of metadata structures to be created. This value must be CLSID_CorMetaDataRuntime for the .NET Framework version 2.0.</param>
        /// <param name="dwCreateFlags">[in] Flags that specify options. This value must be zero for the .NET Framework 2.0.</param>
        /// <param name="riid">[in] The IID of the desired metadata interface to be returned; the caller will use the interface to create the new metadata.<para/>
        /// The value of riid must specify one of the "emit" interfaces. Valid values are IID_IMetaDataEmit, IID_IMetaDataAssemblyEmit, or IID_IMetaDataEmit2.</param>
        /// <param name="ppIUnk">[out] The pointer to the returned interface.</param>
        /// <remarks>
        /// DefineScope creates a set of in-memory metadata tables, generates a unique GUID (module version identifier, or
        /// MVID) for the metadata, and creates an entry in the module table for the compilation unit being emitted. You can
        /// attach attributes to the metadata scope as a whole by using the <see cref="IMetaDataEmit.SetModuleProps"/> or <see
        /// cref="IMetaDataEmit.DefineCustomAttribute"/> method, as appropriate.
        /// </remarks>
        [PreserveSig]
        new HRESULT DefineScope(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
            [In] int dwCreateFlags,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppIUnk);

        /// <summary>
        /// Opens an existing, on-disk file and maps its metadata into memory.
        /// </summary>
        /// <param name="szScope">[in] The name of the file to be opened. The file must contain common language runtime (CLR) metadata.</param>
        /// <param name="dwOpenFlags">[in] A value of the <see cref="CorOpenFlags"/> enumeration to specify the mode (read, write, and so on) for opening.</param>
        /// <param name="riid">[in] The IID of the desired metadata interface to be returned; the caller will use the interface to import (read) or emit (write) metadata.<para/>
        /// The value of riid must specify one of the "import" or "emit" interfaces. Valid values are IID_IMetaDataEmit, IID_IMetaDataImport, IID_IMetaDataAssemblyEmit, IID_IMetaDataAssemblyImport, IID_IMetaDataEmit2, or IID_IMetaDataImport2.</param>
        /// <param name="ppIUnk">[out] The pointer to the returned interface.</param>
        /// <remarks>
        /// The in-memory copy of the metadata can be queried using methods from one of the "import" interfaces, or added to
        /// using methods from the one of the "emit" interfaces. If the target file does not contain CLR metadata, the OpenScope
        /// method will fail. In the .NET Framework version 1.0 and version 1.1, if a scope is opened with dwOpenFlags set
        /// to ofRead, it is eligible for sharing. That is, if subsequent calls to OpenScope pass in the name of a file that
        /// was previously opened, the existing scope is reused and a new set of data structures is not created. However, problems
        /// can arise due to this sharing. In the .NET Framework version 2.0, scopes opened with dwOpenFlags set to ofRead
        /// are no longer shared. Use the ofReadOnly value to allow the scope to be shared. When a scope is shared, queries
        /// that use "read/write" metadata interfaces will fail.
        /// </remarks>
        [PreserveSig]
        new HRESULT OpenScope(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szScope,
            [In] CorOpenFlags dwOpenFlags,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppIUnk);

        /// <summary>
        /// Opens an area of memory that contains existing metadata. That is, this method opens a specified area of memory in which the existing data is treated as metadata.
        /// </summary>
        /// <param name="pData">[in] A pointer that specifies the starting address of the memory area.</param>
        /// <param name="cbData">[in] The size of the memory area, in bytes.</param>
        /// <param name="dwOpenFlags">[in] A value of the <see cref="CorOpenFlags"/> enumeration to specify the mode (read, write, and so on) for opening.</param>
        /// <param name="riid">[in] The IID of the desired metadata interface to be returned; the caller will use the interface to import (read) or emit (write) metadata.<para/>
        /// The value of riid must specify one of the "import" or "emit" interfaces. Valid values are IID_IMetaDataEmit, IID_IMetaDataImport, IID_IMetaDataAssemblyEmit, IID_IMetaDataAssemblyImport, IID_IMetaDataEmit2, or IID_IMetaDataImport2.</param>
        /// <param name="ppIUnk">[out] The pointer to the returned interface.</param>
        /// <remarks>
        /// The in-memory copy of the metadata can be queried using methods from one of the "import" interfaces, or added to
        /// using methods from the one of the "emit" interfaces. The OpenScopeOnMemory method is similar to the <see cref="OpenScope"/>
        /// method, except that the metadata of interest already exists in memory, rather than in a file on disk. If the target
        /// area of memory does not contain common language runtime (CLR) metadata, the OpenScopeOnMemory method will fail.
        /// </remarks>
        [PreserveSig]
        new HRESULT OpenScopeOnMemory(
            [In] IntPtr pData,
            [In] int cbData,
            [In] CorOpenFlags dwOpenFlags,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppIUnk);

        /// <summary>
        /// Sets the specified option to a given value for the current metadata scope. The option controls how calls to the current metadata scope are handled.
        /// </summary>
        /// <param name="optionId">[in] A pointer to a GUID that specifies the option to be set. For possible values see <see cref="MetaDataDispenserOption"/>.</param>
        /// <param name="pValue">[in] The value to use to set the option. The type of this value must be a variant of the specified option's type.</param>
        /// <remarks>
        /// The following table lists the available GUIDs that the optionId parameter can point to and the corresponding valid
        /// values for the pValue parameter.
        /// </remarks>
        [PreserveSig]
        HRESULT SetOption(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid optionId,
            [In, MarshalAs(UnmanagedType.Struct)] ref object pValue);

        /// <summary>
        /// Gets the value of the specified option for the current metadata scope. The option controls how calls to the current metadata scope are handled.
        /// </summary>
        /// <param name="optionId">[in] A pointer to a GUID that specifies the option to be retrieved. For possible values see <see cref="MetaDataDispenserOption"/>.</param>
        /// <param name="pValue">[out] The value of the returned option. The type of this value will be a variant of the specified option's type.</param>
        /// <remarks>
        /// The following list shows the GUIDs that are supported for this method. For descriptions, see the <see cref="SetOption"/>
        /// method. If optionId is not in this list, this method returns <see cref="HRESULT"/> E_INVALIDARG, indicating an incorrect parameter.
        /// </remarks>
        [PreserveSig]
        HRESULT GetOption(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid optionId,
            [Out] out object pValue);

        /// <summary>
        /// This method is not implemented. If called, it returns E_NOTIMPL.
        /// </summary>
        /// <param name="pITI">[in] Pointer to an ITypeInfo interface that provides the type information on which to open the scope.</param>
        /// <param name="dwOpenFlags">[in] The open mode flags.</param>
        /// <param name="riid">[in] The desired interface.</param>
        /// <param name="ppIUnk">[out] Pointer to a pointer to the returned interface.</param>
        [PreserveSig]
        HRESULT OpenScopeOnITypeInfo(
            [In, MarshalAs(UnmanagedType.Interface)] ITypeInfo pITI,
            [In] int dwOpenFlags,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object ppIUnk);

        /// <summary>
        /// Gets the directory that holds the current common language runtime (CLR). This method is supported only for use by out-of-process debuggers.<para/>
        /// If called from another component, it will return E_NOTIMPL.
        /// </summary>
        /// <param name="szBuffer">[out] The buffer to receive the directory name.</param>
        /// <param name="cchBuffer">[in] The size, in bytes, of szBuffer.</param>
        /// <param name="pchBuffer">[out] The number of bytes actually returned in szBuffer.</param>
        [PreserveSig]
        HRESULT GetCORSystemDirectory(
            [Out, MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 1)] StringBuilder szBuffer,
            [In] int cchBuffer,
            [Out] out int pchBuffer);

        /// <summary>
        /// This method is not implemented. If called, it returns E_NOTIMPL.
        /// </summary>
        /// <param name="szAppBase">[in] Not used.</param>
        /// <param name="szPrivateBin">[in] Not used.</param>
        /// <param name="szGlobalBin">[in] Not used.</param>
        /// <param name="szAssemblyName">[in] The assembly to be found.</param>
        /// <param name="szName">[out] The simple name of the assembly.</param>
        /// <param name="cchName">[in] The size, in bytes, of szName.</param>
        /// <param name="pcName">[out] The number of characters actually returned in szName.</param>
        [PreserveSig]
        HRESULT FindAssembly(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAppBase,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szPrivateBin,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szGlobalBin,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAssemblyName,
            [Out, MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 5)] StringBuilder szName,
            [In] int cchName,
            [Out] out int pcName);

        /// <summary>
        /// This method is not implemented. If called, it returns E_NOTIMPL.
        /// </summary>
        /// <param name="szAppBase">[in] Not used.</param>
        /// <param name="szPrivateBin">[in] Not used.</param>
        /// <param name="szGlobalBin">[in] Not used.</param>
        /// <param name="szAssemblyName">[in] The name of the module.</param>
        /// <param name="szModuleName">[in] The assembly to be found.</param>
        /// <param name="szName">[out] The simple name of the assembly.</param>
        /// <param name="cchName">[in] The size, in bytes, of szName.</param>
        /// <param name="pcName">[out] The number of characters actually returned in szName.</param>
        [PreserveSig]
        HRESULT FindAssemblyModule(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAppBase,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szPrivateBin,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szGlobalBin,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAssemblyName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szModuleName,
            [Out, MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 6)] StringBuilder szName,
            [In] int cchName,
            [Out] out int pcName);
    }
}
