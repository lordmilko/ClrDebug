using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug
{
    [Guid("4675666C-C275-45b8-9F6C-AB165D5C1E09")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataTypeDefinition
    {
        [PreserveSig]
        HRESULT GetModule(
            [Out] out IXCLRDataModule mod);

        [PreserveSig]
        HRESULT StartEnumMethodDefinitions(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumMethodDefinition(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodDefinition methodDefinition);

        [PreserveSig]
        HRESULT EndEnumMethodDefinitions(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumMethodDefinitionsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int flags,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumMethodDefinitionByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodDefinition method);

        [PreserveSig]
        HRESULT EndEnumMethodDefinitionsByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetMethodDefinitionByToken(
            [In] mdMethodDef token,
            [Out] out IXCLRDataMethodDefinition methodDefinition);

        [PreserveSig]
        HRESULT StartEnumInstances(
            [In] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumInstance(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTypeInstance instance);

        [PreserveSig]
        HRESULT EndEnumInstances(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetName(
            [In] int flags,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);

        [PreserveSig]
        HRESULT GetTokenAndScope(
            [Out] out mdTypeDef token,
            [Out] out IXCLRDataModule mod);

        [PreserveSig]
        HRESULT GetCorElementType(
            [Out] out CorElementType type);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out int flags);

        [PreserveSig]
        HRESULT IsSameObject(
            [In] IXCLRDataTypeDefinition type);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode,
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);

        [PreserveSig]
        HRESULT GetArrayRank(
            [Out] out int rank);

        [PreserveSig]
        HRESULT GetBase(
            [Out] out IXCLRDataTypeDefinition _base);

        [PreserveSig]
        HRESULT GetNumFields(
            [In] int flags,
            [Out] out int numFields);

        [PreserveSig]
        HRESULT StartEnumFields(
            [In] int flags,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumField(
            [In, Out] ref IntPtr handle,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out IXCLRDataTypeDefinition type,
            [Out] out int flags,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT EndEnumFields(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumFieldsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int nameFlags,
            [In] int fieldFlags,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumFieldByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTypeDefinition type,
            [Out] out int flags,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT EndEnumFieldsByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetFieldByToken(
            [In] mdFieldDef token,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out IXCLRDataTypeDefinition type,
            [Out] out int flags);

        [PreserveSig]
        HRESULT GetTypeNotification(
            [Out] out int flags);

        [PreserveSig]
        HRESULT SetTypeNotification(
            [In] int flags);

        [PreserveSig]
        HRESULT EnumField2(
            [In, Out] ref IntPtr handle,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out IXCLRDataTypeDefinition type,
            [Out] out int flags,
            [Out] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT EnumFieldByName2(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTypeDefinition type,
            [Out] out int flags,
            [Out] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT GetFieldByToken2(
            [In] IXCLRDataModule tokenScope,
            [In] mdFieldDef token,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out IXCLRDataTypeDefinition type,
            [Out] out int flags);
    }
}
