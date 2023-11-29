using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("4D078D91-9CB3-4b0d-97AC-28C8A5A82597")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataTypeInstance
    {
        [PreserveSig]
        HRESULT StartEnumMethodInstances(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumMethodInstance(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataMethodInstance methodInstance);

        [PreserveSig]
        HRESULT EndEnumMethodInstances(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumMethodInstancesByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumMethodInstanceByName(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataMethodInstance method);

        [PreserveSig]
        HRESULT EndEnumMethodInstancesByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetNumStaticFields(
            [Out] out int numFields);

        [PreserveSig]
        HRESULT GetStaticFieldByIndex(
            [In] int index,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTask tlsTask,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] nameBuf,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT StartEnumStaticFieldsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumStaticFieldByName(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT EndEnumStaticFieldsByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetNumTypeArguments(
            [Out] out int numTypeArgs);

        [PreserveSig]
        HRESULT GetTypeArgumentByIndex(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeInstance typeArg);

        [PreserveSig]
        HRESULT GetName(
            [In] int flags, //Unused; must be 0
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] nameBuf);

        [PreserveSig]
        HRESULT GetModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule mod);

        [PreserveSig]
        HRESULT GetDefinition(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition typeDefinition);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out CLRDataTypeFlag flags);

        [PreserveSig]
        HRESULT IsSameObject(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTypeInstance type);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode, //Requests can be across a variety of enums
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);

        [PreserveSig]
        HRESULT GetNumStaticFields2(
            [In] CLRDataFieldFlag flags,
            [Out] out int numFields);

        [PreserveSig]
        HRESULT StartEnumStaticFields(
            [In] CLRDataFieldFlag flags,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumStaticField(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT EndEnumStaticFields(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumStaticFieldsByName2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag nameFlags,
            [In] CLRDataFieldFlag fieldFlags,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumStaticFieldByName2(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT EndEnumStaticFieldsByName2(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetStaticFieldByToken(
            [In] mdFieldDef token,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTask tlsTask,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] nameBuf);

        [PreserveSig]
        HRESULT GetBase(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeInstance _base);

        [PreserveSig]
        HRESULT EnumStaticField2(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue value,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] nameBuf,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT EnumStaticFieldByName3(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue value,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT GetStaticFieldByToken2(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataModule tokenScope,
            [In] mdFieldDef token,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTask tlsTask,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] nameBuf);
    }
}
