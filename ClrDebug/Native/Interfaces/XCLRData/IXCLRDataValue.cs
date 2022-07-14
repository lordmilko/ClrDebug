using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug
{
    [Guid("96EC93C7-1000-4e93-8991-98D8766E6666")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataValue
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
            [Out] out IntPtr buffer);

        [PreserveSig]
        HRESULT SetBytes(
            [In] int bufLen,
            [Out] out int dataSize,
            [In] IntPtr buffer);

        [PreserveSig]
        HRESULT GetType(
            [Out] out IXCLRDataTypeInstance typeInstance);

        [PreserveSig]
        HRESULT GetNumFields(
            [Out] out int numFields);

        [PreserveSig]
        HRESULT GetFieldByIndex(
            [In] int index,
            [Out] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
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
            [In] IXCLRDataTypeInstance fromType,
            [Out] out int numFields);

        [PreserveSig]
        HRESULT StartEnumFields(
            [In] CLRDataFieldFlag flags,
            [In] IXCLRDataTypeInstance fromType,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumField(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue field,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT EndEnumFields(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumFieldsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag nameFlags,
            [In] CLRDataFieldFlag fieldFlags,
            [In] IXCLRDataTypeInstance fromType,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumFieldByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue field,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT EndEnumFieldsByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetFieldByToken(
            [In] mdFieldDef token,
            [Out] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);

        [PreserveSig]
        HRESULT GetAssociatedValue(
            [Out] out IXCLRDataValue assocValue);

        [PreserveSig]
        HRESULT GetAssociatedType(
            [Out] out IXCLRDataTypeInstance assocType);

        [PreserveSig]
        HRESULT GetString(
            [In] int bufLen,
            [Out] out int strLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder str);

        [PreserveSig]
        HRESULT GetArrayProperties(
            [Out] out int rank,
            [Out] out int totalElements,
            [In] int numDim,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] dims,
            [In] int numBases,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] int[] bases);

        [PreserveSig]
        HRESULT GetArrayElement(
            [In] int numInd,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] indices,
            [Out] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT EnumField2(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue field,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT EnumFieldByName2(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue field,
            [Out] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT GetFieldByToken2(
            [In] IXCLRDataModule tokenScope,
            [In] mdFieldDef token,
            [Out] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);

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
