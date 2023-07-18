using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for querying information about a method instance.
    /// </summary>
    /// <remarks>
    /// This interface lives inside the runtime and is not exposed through any headers or library files. However, it's
    /// a COM interface that derives from IUnknown with GUID ECD73800-22CA-4b0d-AB55-E9BA7E6318A5 that can be obtained
    /// through the usual COM mechanisms.
    /// </remarks>
    [Guid("ECD73800-22CA-4b0d-AB55-E9BA7E6318A5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataMethodInstance
    {
        [PreserveSig]
        HRESULT GetTypeInstance(
            [Out] out IXCLRDataTypeInstance typeInstance);

        [PreserveSig]
        HRESULT GetDefinition(
            [Out] out IXCLRDataMethodDefinition methodDefinition);

        [PreserveSig]
        HRESULT GetTokenAndScope(
            [Out] out mdMethodDef token,
            [Out] out IXCLRDataModule mod);

        [PreserveSig]
        HRESULT GetName(
            [In] int flags, //Unused, must be 0
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] nameBuf);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out CLRDataMethodFlag flags);

        [PreserveSig]
        HRESULT IsSameObject(
            [In] IXCLRDataMethodInstance method);

        [PreserveSig]
        HRESULT GetEnCVersion(
            [Out] out int version);

        [PreserveSig]
        HRESULT GetNumTypeArguments(
            [Out] out int numTypeArgs);

        [PreserveSig]
        HRESULT GetTypeArgumentByIndex(
            [In] int index,
            [Out] out IXCLRDataTypeInstance typeArg);

        [PreserveSig]
        HRESULT GetILOffsetsByAddress(
            [In] CLRDATA_ADDRESS address,
            [In] int offsetsLen,
            [Out] out int offsetsNeeded,
            [Out] out int ilOffsets);

        [PreserveSig]
        HRESULT GetAddressRangesByILOffset(
            [In] int ilOffset,
            [In] int rangesLen,
            [Out] out int rangesNeeded,
            [Out] out CLRDATA_ADDRESS_RANGE addressRanges);

        /// <summary>
        /// Gets the IL to address mapping information.
        /// </summary>
        /// <param name="mapLen">[in] The length of the provided maps array.</param>
        /// <param name="mapNeeded">[out] The number of map entries that the method needs.</param>
        /// <param name="maps">[out, size_is(mapLen)] The array for storing the map entries.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataMethodInstance interface and corresponds to the 15th slot of the virtual
        /// method table.
        /// </remarks>
        [PreserveSig]
        HRESULT GetILAddressMap(
            [In] int mapLen,
            [Out] out int mapNeeded,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] CLRDATA_IL_ADDRESS_MAP[] maps);

        [PreserveSig]
        HRESULT StartEnumExtents(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumExtent(
            [In, Out] ref IntPtr handle,
            [Out] out CLRDATA_ADDRESS_RANGE extent);

        [PreserveSig]
        HRESULT EndEnumExtents(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode, //Requests can be across a variety of enums
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);

        /// <summary>
        /// Gets the most representative entry point address for the native compilation of all the possible entry points for a method.
        /// </summary>
        /// <param name="addr">[out] The address of the most representative native entry point for the method.</param>
        /// <remarks>
        /// The provided method is part of the <see cref="IXCLRDataMethodInstance"/> interface and corresponds to the 20th slot of the
        /// virtual method table.
        /// </remarks>
        [PreserveSig]
        HRESULT GetRepresentativeEntryAddress(
            [Out] out CLRDATA_ADDRESS addr);
    }
}
