using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("96EC93C7-1000-4e93-8991-98D8766E6666")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataValue
    {
        [PreserveSig]
        HRESULT GetFlags(
            [Out] out CLRDataValueFlag flags);

        [PreserveSig]
        HRESULT GetAddress(
            [Out] out CLRDATA_ADDRESS address);

        [PreserveSig]
        HRESULT GetSize(
            [Out] out long size);

        [PreserveSig]
        HRESULT GetBytes(
            [In] int bufLen,
            [Out] out int dataSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] buffer);

        [PreserveSig]
        HRESULT SetBytes(
            [In] int bufLen,
            [Out] out int dataSize,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] buffer);

        [PreserveSig]
        HRESULT GetType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeInstance typeInstance);

        [PreserveSig]
        HRESULT GetNumFields(
            [Out] out int numFields);

        [PreserveSig]
        HRESULT GetFieldByIndex(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] nameBuf,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode, //Requests can be across a variety of enums
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);

        [PreserveSig]
        HRESULT GetNumFields2(
            [In] CLRDataFieldFlag flags,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTypeInstance fromType,
            [Out] out int numFields);

        [PreserveSig]
        HRESULT StartEnumFields(
            [In] CLRDataFieldFlag flags,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTypeInstance fromType,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumField(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] nameBuf,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT EndEnumFields(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumFieldsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag nameFlags,
            [In] CLRDataFieldFlag fieldFlags,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTypeInstance fromType,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumFieldByName(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT EndEnumFieldsByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetFieldByToken(
            [In] mdFieldDef token,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] nameBuf);

        [PreserveSig]
        HRESULT GetAssociatedValue(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue assocValue);

        [PreserveSig]
        HRESULT GetAssociatedType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeInstance assocType);

        [PreserveSig]
        HRESULT GetString(
            [In] int bufLen,
            [Out] out int strLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] str);

        [PreserveSig]
        HRESULT GetArrayProperties(
            [Out] out int rank,
            [Out] out int totalElements,
            [In] int numDim,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] dims,
            [In] int numBases,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] int[] bases);

        [PreserveSig]
        HRESULT GetArrayElement(
            [In] int numInd,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] indices,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT EnumField2(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] nameBuf,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT EnumFieldByName2(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT GetFieldByToken2(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataModule tokenScope,
            [In] mdFieldDef token,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] nameBuf);

        [PreserveSig]
        HRESULT GetNumLocations(
            [Out] out int numLocs);

        [PreserveSig]
        HRESULT GetLocationByIndex(
            [In] int loc,
            [Out] out ClrDataValueLocationFlag flags,
            [Out] out CLRDATA_ADDRESS arg);
    }
}
