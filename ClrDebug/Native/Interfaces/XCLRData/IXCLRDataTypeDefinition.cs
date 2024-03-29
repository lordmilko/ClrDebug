﻿using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("4675666C-C275-45b8-9F6C-AB165D5C1E09")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataTypeDefinition
    {
        [PreserveSig]
        HRESULT GetModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule mod);

        [PreserveSig]
        HRESULT StartEnumMethodDefinitions(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumMethodDefinition(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataMethodDefinition methodDefinition);

        [PreserveSig]
        HRESULT EndEnumMethodDefinitions(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumMethodDefinitionsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumMethodDefinitionByName(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataMethodDefinition method);

        [PreserveSig]
        HRESULT EndEnumMethodDefinitionsByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetMethodDefinitionByToken(
            [In] mdMethodDef token,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataMethodDefinition methodDefinition);

        [PreserveSig]
        HRESULT StartEnumInstances(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumInstance(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeInstance instance);

        [PreserveSig]
        HRESULT EndEnumInstances(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetName(
            [In] int flags, //Unused, always 0
            [In] int bufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] nameBuf);

        [PreserveSig]
        HRESULT GetTokenAndScope(
            [Out] out mdTypeDef token,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule mod);

        [PreserveSig]
        HRESULT GetCorElementType(
            [Out] out CorElementType type);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out CLRDataTypeFlag flags);

        [PreserveSig]
        HRESULT IsSameObject(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTypeDefinition type);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode, //Requests can be across a variety of enums
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);

        [PreserveSig]
        HRESULT GetArrayRank(
            [Out] out int rank);

        [PreserveSig]
        HRESULT GetBase(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition _base);

        [PreserveSig]
        HRESULT GetNumFields(
            [In] CLRDataFieldFlag flags,
            [Out] out int numFields);

        [PreserveSig]
        HRESULT StartEnumFields(
            [In] CLRDataFieldFlag flags,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumField(
            [In, Out] ref IntPtr handle,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] nameBuf,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition type,
            [Out] out CLRDataFieldFlag flags,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT EndEnumFields(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumFieldsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag nameFlags,
            [In] CLRDataFieldFlag fieldFlags,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumFieldByName(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition type,
            [Out] out CLRDataFieldFlag flags,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT EndEnumFieldsByName(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetFieldByToken(
            [In] mdFieldDef token,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] nameBuf,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition type,
            [Out] out CLRDataValueFlag flags);

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
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] nameBuf,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition type,
            [Out] out CLRDataFieldFlag flags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT EnumFieldByName2(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition type,
            [Out] out CLRDataFieldFlag flags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);

        [PreserveSig]
        HRESULT GetFieldByToken2(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataModule tokenScope,
            [In] mdFieldDef token,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] nameBuf,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition type,
            [Out] out CLRDataValueFlag flags);
    }
}
