using System;
using System.Runtime.InteropServices;
using ClrDebug.TypeLib;

namespace ClrDebug.DIA
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0000002F-0000-0000-C000-000000000046")]
    [ComImport]
    public interface IRecordInfo
    {
        [PreserveSig]
        HRESULT RecordInit(
            [Out] IntPtr pvNew);

        [PreserveSig]
        HRESULT RecordClear(
            [In] IntPtr pvExisting);

        [PreserveSig]
        HRESULT RecordCopy(
            [In] IntPtr pvExisting,
            [Out] IntPtr pvNew);

        [PreserveSig]
        HRESULT GetGuid(
            [Out] out Guid pguid);

        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

        [PreserveSig]
        HRESULT GetSize(
            [Out] out int pcbSize);

        [PreserveSig]
        HRESULT GetTypeInfo(
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeInfo ppTypeInfo);

        [PreserveSig]
        HRESULT GetField(
            [In] IntPtr pvData,
            [MarshalAs(UnmanagedType.LPWStr), In] string szFieldName,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pvarField);

        [PreserveSig]
        HRESULT GetFieldNoCopy(
            [In] IntPtr pvData,
            [MarshalAs(UnmanagedType.LPWStr), In] string szFieldName,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pvarField,
            [Out] out IntPtr ppvDataCArray);

        [PreserveSig]
        HRESULT PutField(
            [In] int wFlags,
            [In, Out] IntPtr pvData,
            [MarshalAs(UnmanagedType.LPWStr), In] string szFieldName,
            [MarshalAs(UnmanagedType.Struct), In] ref object pvarField);

        [PreserveSig]
        HRESULT PutFieldNoCopy(
            [In] int wFlags,
            [In, Out] IntPtr pvData,
            [MarshalAs(UnmanagedType.LPWStr), In] string szFieldName,
            [MarshalAs(UnmanagedType.Struct), In] ref object pvarField);

        [PreserveSig]
        HRESULT GetFieldNames(
            [In, Out] ref int pcNames,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.BStr, SizeParamIndex = 0)] string[] rgBstrNames);

        [PreserveSig]
        HRESULT IsMatchingType(
            [MarshalAs(UnmanagedType.Interface), In] IRecordInfo pRecordInfo);

        [PreserveSig]
        IntPtr RecordCreate();

        [PreserveSig]
        HRESULT RecordCreateCopy(
            [In] IntPtr pvSource,
            [Out] out IntPtr ppvDest);

        [PreserveSig]
        HRESULT RecordDestroy(
            [In] IntPtr pvRecord);
    }
}
