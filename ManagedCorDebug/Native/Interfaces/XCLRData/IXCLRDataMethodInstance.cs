using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    [Guid("ECD73800-22CA-4b0d-AB55-E9BA7E6318A5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataMethodInstance
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
            [In] int flags,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out int flags);

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

        [PreserveSig]
        HRESULT GetILAddressMap(
            [In] int mapLen,
            [Out] out int mapNeeded,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_IL_ADDRESS_MAP[] maps);

        [PreserveSig]
        HRESULT StartEnumExtents(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumExtent(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS_RANGE[] extent);

        [PreserveSig]
        HRESULT EndEnumExtents(
            [In] IntPtr handle);

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
    }
}
