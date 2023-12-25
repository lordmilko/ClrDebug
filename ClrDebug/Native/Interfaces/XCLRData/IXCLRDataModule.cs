using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for querying information about a loaded module.
    /// </summary>
    /// <remarks>
    /// This interface lives inside the runtime and is not exposed through any headers or library files. However, it's
    /// a COM interface that derives from IUnknown with GUID 88E32849-0A0A-4cb0-9022-7CD2E9E139E2 that can be obtained
    /// through the usual COM mechanisms.
    /// </remarks>
    [Guid("88E32849-0A0A-4cb0-9022-7CD2E9E139E2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataModule
    {
        [PreserveSig]
        HRESULT StartEnumAssemblies(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumAssembly(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataAssembly assembly);

        [PreserveSig]
        HRESULT EndEnumAssemblies(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumTypeDefinitions(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumTypeDefinition(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition typeDefinition);

        [PreserveSig]
        HRESULT EndEnumTypeDefinitions(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumTypeInstances(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumTypeInstance(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeInstance typeInstance);

        [PreserveSig]
        HRESULT EndEnumTypeInstances(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumTypeDefinitionsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumTypeDefinitionByName(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition type);

        [PreserveSig]
        HRESULT EndEnumTypeDefinitionsByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumTypeInstancesByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumTypeInstanceByName(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeInstance type);

        [PreserveSig]
        HRESULT EndEnumTypeInstancesByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetTypeDefinitionByToken(
            [In] mdTypeDef token,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition typeDefinition);

        [PreserveSig]
        HRESULT StartEnumMethodDefinitionsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumMethodDefinitionByName(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataMethodDefinition method);

        [PreserveSig]
        HRESULT EndEnumMethodDefinitionsByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumMethodInstancesByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumMethodInstanceByName(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataMethodInstance method);

        [PreserveSig]
        HRESULT EndEnumMethodInstancesByName(
            [In] IntPtr handle);

        /// <summary>
        /// Gets the method definition corresponding to a given metadata token.
        /// </summary>
        /// <param name="token">[in] The method token.</param>
        /// <param name="methodDefinition">[out] The method definition.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataModule interface and corresponds to the 26th slot of the virtual method
        /// table.
        /// </remarks>
        [PreserveSig]
        HRESULT GetMethodDefinitionByToken(
            [In] mdMethodDef token,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataMethodDefinition methodDefinition);

        [PreserveSig]
        HRESULT StartEnumDataByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataAppDomain appDomain,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumDataByName(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT EndEnumDataByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetName(
            [In] int bufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] name);

        [PreserveSig]
        HRESULT GetFileName(
            [In] int bufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] name);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out CLRDataModuleFlag flags);

        [PreserveSig]
        HRESULT IsSameObject(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataModule mod);

        [PreserveSig]
        HRESULT StartEnumExtents(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumExtent(
            [In, Out] ref IntPtr handle,
            [Out] out CLRDATA_MODULE_EXTENT extent);

        [PreserveSig]
        HRESULT EndEnumExtents(
            [In] IntPtr handle);

        /// <summary>
        /// Requests to populate the buffer given with the module's data.
        /// </summary>
        /// <param name="reqCode">[in] Request type to be sent.</param>
        /// <param name="inBufferSize">[in] size of the input buffer to be passed in.</param>
        /// <param name="inBuffer">[in, size_is(inBufferSize)] Buffer pointer for the raw data to be sent in the request.</param>
        /// <param name="outBufferSize">[in] Size of the output buffer.</param>
        /// <param name="outBuffer">[out, size_is(outBufferSize)] Buffer pointer to used to store the request response.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataModule interface and corresponds to the 37th slot of the virtual method
        /// table.
        /// </remarks>
        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode, //Requests can be across a variety of enums
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);

        [PreserveSig]
        HRESULT StartEnumAppDomains(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumAppDomain(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataAppDomain appDomain);

        [PreserveSig]
        HRESULT EndEnumAppDomains(
            [In] IntPtr handle);

        /// <summary>
        /// Gets the module's version identifier.
        /// </summary>
        /// <param name="vid">[out] The module's version identifier.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataModule interface and corresponds to the 41st slot of the virtual method
        /// table.
        /// </remarks>
        [PreserveSig]
        HRESULT GetVersionId(
            [Out]
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            out Guid vid);
    }
}
