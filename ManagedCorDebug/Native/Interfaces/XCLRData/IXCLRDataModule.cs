using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    [Guid("88E32849-0A0A-4cb0-9022-7CD2E9E139E2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataModule
    {
        [PreserveSig]
        HRESULT StartEnumAssemblies(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumAssembly(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataAssembly assembly);

        [PreserveSig]
        HRESULT EndEnumAssemblies(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumTypeDefinitions(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumTypeDefinition(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTypeDefinition typeDefinition);

        [PreserveSig]
        HRESULT EndEnumTypeDefinitions(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumTypeInstances(
            [In] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumTypeInstance(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTypeInstance typeInstance);

        [PreserveSig]
        HRESULT EndEnumTypeInstances(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumTypeDefinitionsByName(
            [In] string name,
            [In] int flags,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumTypeDefinitionByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTypeDefinition type);

        [PreserveSig]
        HRESULT EndEnumTypeDefinitionsByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumTypeInstancesByName(
            [In] string name,
            [In] int flags,
            [In] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumTypeInstanceByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTypeInstance type);

        [PreserveSig]
        HRESULT EndEnumTypeInstancesByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetTypeDefinitionByToken(
            [In] mdTypeDef token,
            [Out] out IXCLRDataTypeDefinition typeDefinition);

        [PreserveSig]
        HRESULT StartEnumMethodDefinitionsByName(
            [In] string name,
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
        HRESULT StartEnumMethodInstancesByName(
            [In] string name,
            [In] int flags,
            [In] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumMethodInstanceByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodInstance method);

        [PreserveSig]
        HRESULT EndEnumMethodInstancesByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetMethodDefinitionByToken(
            [In] mdMethodDef token,
            [Out] out IXCLRDataMethodDefinition methodDefinition);

        [PreserveSig]
        HRESULT StartEnumDataByName(
            [In] string name,
            [In] int flags,
            [In] IXCLRDataAppDomain appDomain,
            [In] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumDataByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT EndEnumDataByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetName(
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name);

        [PreserveSig]
        HRESULT GetFileName(
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out int flags);

        [PreserveSig]
        HRESULT IsSameObject(
            [In] IXCLRDataModule mod);

        [PreserveSig]
        HRESULT StartEnumExtents(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumExtent(
            [In, Out] ref IntPtr handle,
            [Out] out CLRDATA_MODULE_EXTENT extent);

        [PreserveSig]
        HRESULT EndEnumExtents(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode,
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] out IntPtr outBuffer);

        [PreserveSig]
        HRESULT StartEnumAppDomains(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumAppDomain(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataAppDomain appDomain);

        [PreserveSig]
        HRESULT EndEnumAppDomains(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetVersionId(
            [Out] out Guid vid);
    }
}
