using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif
using ClrDebug.TypeLib;

namespace ClrDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0000002F-0000-0000-C000-000000000046")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IRecordInfo
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
            [Out]
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            out Guid pguid);

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
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.Struct)]
#else
            [MarshalUsing(typeof(VariantMarshaller))]
#endif
            out object pvarField);

        [PreserveSig]
        HRESULT GetFieldNoCopy(
            [In] IntPtr pvData,
            [MarshalAs(UnmanagedType.LPWStr), In] string szFieldName,
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.Struct)]
#else
            [MarshalUsing(typeof(VariantMarshaller))]
#endif
            out object pvarField,
            [Out] out IntPtr ppvDataCArray);

        [PreserveSig]
        HRESULT PutField(
            [In] int wFlags,
            [In, Out] IntPtr pvData,
            [MarshalAs(UnmanagedType.LPWStr), In] string szFieldName,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.Struct)]
#else
            [MarshalUsing(typeof(VariantMarshaller))]
#endif
            ref object pvarField);

        [PreserveSig]
        HRESULT PutFieldNoCopy(
            [In] int wFlags,
            [In, Out] IntPtr pvData,
            [MarshalAs(UnmanagedType.LPWStr), In] string szFieldName,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.Struct)]
#else
            [MarshalUsing(typeof(VariantMarshaller))]
#endif
            ref object pvarField);

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
