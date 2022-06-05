using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods to create a new metadata scope, or open an existing one.
    /// </summary>
    [Guid("809C652E-7396-11D2-9771-00A0C9B4D50C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IMetaDataDispenser
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
        HRESULT DefineScope(
            [In] ref Guid rclsid,
            [In] uint dwCreateFlags,
            [In] ref Guid riid,
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
        HRESULT OpenScope(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szScope,
            [In] CorOpenFlags dwOpenFlags,
            [In] [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
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
        HRESULT OpenScopeOnMemory(
            [In] IntPtr pData,
            [In] uint cbData,
            [In] CorOpenFlags dwOpenFlags,
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppIUnk);
    }
}