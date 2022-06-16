using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
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
            [In] uint reqCode,
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] out IntPtr outBuffer);

        [PreserveSig]
        HRESULT GetNumFields2(
            [In] int flags,
            [In] IXCLRDataTypeInstance fromType,
            [Out] out int numFields);

        [PreserveSig]
        HRESULT StartEnumFields(
            [In] int flags,
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
            [In] string name,
            [In] int nameFlags,
            [In] int fieldFlags,
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
            [Out] out int[] rank,
            [Out] out int totalElements,
            [In] int numDim,
            [Out] out int[] dims,
            [In] int numBases,
            [Out] out int[] bases);

        [PreserveSig]
        HRESULT GetArrayElement(
            [In] int numInd,
            [In] int[] indices,
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
            [Out] out int flags,
            [Out] out CLRDATA_ADDRESS arg);
    }
}
