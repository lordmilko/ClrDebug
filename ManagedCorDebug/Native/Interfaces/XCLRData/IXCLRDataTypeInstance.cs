using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    [Guid("4D078D91-9CB3-4b0d-97AC-28C8A5A82597")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataTypeInstance
    {
        [PreserveSig]
        HRESULT StartEnumMethodInstances(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumMethodInstance(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodInstance methodInstance);

        [PreserveSig]
        HRESULT EndEnumMethodInstances(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumMethodInstancesByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int flags,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumMethodInstanceByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodInstance method);

        [PreserveSig]
        HRESULT EndEnumMethodInstancesByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetNumStaticFields(
            [Out] out int numFields);

        [PreserveSig]
        HRESULT GetStaticFieldByIndex(
            [In] int index,
            [In] IXCLRDataTask tlsTask,
            [Out] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT StartEnumStaticFieldsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int flags,
            [In] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumStaticFieldByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT EndEnumStaticFieldsByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetNumTypeArguments(
            [Out] out int numTypeArgs);

        [PreserveSig]
        HRESULT GetTypeArgumentByIndex(
            [In] int index,
            [Out] out IXCLRDataTypeInstance typeArg);

        [PreserveSig]
        HRESULT GetName(
            [In] int flags,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);

        [PreserveSig]
        HRESULT GetModule(
            [Out] out IXCLRDataModule mod);

        [PreserveSig]
        HRESULT GetDefinition(
            [Out] out IXCLRDataTypeDefinition typeDefinition);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out int flags);

        [PreserveSig]
        HRESULT IsSameObject(
            [In] IXCLRDataTypeInstance type);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode,
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);

        [PreserveSig]
        HRESULT GetNumStaticFields2(
            [In] int flags,
            [Out] out int numFields);

        [PreserveSig]
        HRESULT StartEnumStaticFields(
            [In] int flags,
            [In] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumStaticField(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT EndEnumStaticFields(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumStaticFieldsByName2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int nameFlags,
            [In] int fieldFlags,
            [In] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumStaticFieldByName2(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT EndEnumStaticFieldsByName2(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetStaticFieldByToken(
            [In] mdFieldDef token,
            [In] IXCLRDataTask tlsTask,
            [Out] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);

        [PreserveSig]
        HRESULT GetBase(
            [Out] out IXCLRDataTypeInstance _base);

        [PreserveSig]
        HRESULT EnumStaticField2(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT EnumStaticFieldByName3(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value,
            [Out] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT GetStaticFieldByToken2(
            [In] IXCLRDataModule tokenScope,
            [In] mdFieldDef token,
            [In] IXCLRDataTask tlsTask,
            [Out] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);
    }
}
