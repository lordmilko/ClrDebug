using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for querying information about a method definition.
    /// </summary>
    /// <remarks>
    /// This interface lives inside the runtime and is not exposed through any headers or library files. However, it's
    /// a COM interface that derives from IUnknown with GUID AAF60008-FB2C-420b-8FB1-42D244A54A97 that can be obtained
    /// through the usual COM mechanisms.
    /// </remarks>
    [Guid("AAF60008-FB2C-420b-8FB1-42D244A54A97")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataMethodDefinition
    {
        [PreserveSig]
        HRESULT GetTypeDefinition(
            [Out] out IXCLRDataTypeDefinition typeDefinition);

        /// <summary>
        /// Provides a handle for the enumeration of method instances for a given IXCLRDataAppDomain.
        /// </summary>
        /// <param name="appDomain">[in] An AppDomain for the enumeration.</param>
        /// <param name="handle">[out] A handle for enumerating the instances.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataMethodDefinition interface and corresponds to the 5th slot of the virtual
        /// method table.
        /// </remarks>
        [PreserveSig]
        HRESULT StartEnumInstances(
            [In] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);

        /// <summary>
        /// Enumerates the instances of this method definition.
        /// </summary>
        /// <param name="handle">[in, out] A handle for enumerating the instances.</param>
        /// <param name="instance">[out] The enumerated instance.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataMethodDefinition interface and corresponds to the 6th slot of the virtual
        /// method table.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumInstance(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodInstance instance);

        /// <summary>
        /// Releases the resources used by internal iterators used during instance enumeration.
        /// </summary>
        /// <param name="handle">[out] A handle for enumerating the instances.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataMethodDefinition interface and corresponds to the 7th slot of the virtual
        /// method table.
        /// </remarks>
        [PreserveSig]
        HRESULT EndEnumInstances(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetName(
            [In] int flags,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name);

        [PreserveSig]
        HRESULT GetTokenAndScope(
            [Out] out mdMethodDef token,
            [Out] out IXCLRDataModule mod);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out int flags);

        [PreserveSig]
        HRESULT IsSameObject(
            [In] IXCLRDataMethodDefinition method);

        [PreserveSig]
        HRESULT GetLatestEnCVersion(
            [Out] out int version);

        [PreserveSig]
        HRESULT StartEnumExtents(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumExtent(
            [In, Out] ref IntPtr handle,
            [Out] out CLRDATA_METHDEF_EXTENT extent);

        [PreserveSig]
        HRESULT EndEnumExtents(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetCodeNotification(
            [Out] out int flags);

        [PreserveSig]
        HRESULT SetCodeNotification(
            [In] int flags);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode,
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);

        [PreserveSig]
        HRESULT GetRepresentativeEntryAddress(
            [Out] out CLRDATA_ADDRESS addr);

        [PreserveSig]
        HRESULT HasClassOrMethodInstantiation(
            [Out] out bool bGeneric);
    }
}
