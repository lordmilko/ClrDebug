using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [Guid("A3C1704A-4559-4a67-8D28-E8F4FE3B3F62")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataDisplay
    {
        [PreserveSig]
        [Obsolete("Vararg functions cannot safely be called from managed code.")]
        HRESULT ErrorPrintF();

        [PreserveSig]
        HRESULT NativeImageDimensions(
            [In] long _base,
            [In] long size,
            [In] int sectionAlign);

        [PreserveSig]
        HRESULT Section(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] long rva,
            [In] long size);

        [PreserveSig]
        HRESULT GetDumpOptions(
            [Out] out CLRNativeImageDumpOptions pOptions);

        [PreserveSig]
        HRESULT StartDocument();

        [PreserveSig]
        HRESULT EndDocument();

        [PreserveSig]
        HRESULT StartCategory(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name);

        [PreserveSig]
        HRESULT EndCategory();

        [PreserveSig]
        HRESULT StartElement(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name);

        [PreserveSig]
        HRESULT EndElement();

        [PreserveSig]
        HRESULT StartVStructure(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name);

        [PreserveSig]
        HRESULT StartVStructureWithOffset(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int fieldOffset,
            [In] int fieldSize);

        [PreserveSig]
        HRESULT EndVStructure();

        [PreserveSig]
        HRESULT StartTextElement(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name);

        [PreserveSig]
        HRESULT EndTextElement();

        [PreserveSig]
        [Obsolete("Vararg functions cannot safely be called from managed code.")]
        HRESULT WriteXmlText();

        [PreserveSig]
        [Obsolete("Vararg functions cannot safely be called from managed code.")]
        HRESULT WriteXmlTextBlock();

        [PreserveSig]
        HRESULT WriteEmptyElement(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element);

        [PreserveSig]
        HRESULT WriteElementPointer(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] long ptr);

        [PreserveSig]
        HRESULT WriteElementPointerAnnotated(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] long ptr,
            [In, MarshalAs(UnmanagedType.LPWStr)] string annotation);

        [PreserveSig]
        HRESULT WriteElementAddress(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] long _base,
            [In] long size);

        [PreserveSig]
        HRESULT WriteElementAddressNamed(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] long _base,
            [In] long size);

        [PreserveSig]
        HRESULT WriteElementAddressNamedW(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] long _base,
            [In] long size);

        [PreserveSig]
        HRESULT WriteElementString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In, MarshalAs(UnmanagedType.LPWStr)] string data);

        [PreserveSig]
        HRESULT WriteElementStringW(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In, MarshalAs(UnmanagedType.LPWStr)] string data);

        [PreserveSig]
        HRESULT WriteElementInt(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int value);

        [PreserveSig]
        HRESULT WriteElementUInt(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int value);

        [PreserveSig]
        HRESULT WriteElementEnumerated(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int value,
            [In, MarshalAs(UnmanagedType.LPWStr)] string mnemonic);

        [PreserveSig]
        HRESULT WriteElementIntWithSuppress(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int value,
            [In] int suppressIfEqual);

        [PreserveSig]
        HRESULT WriteElementFlag(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int flag);

        [PreserveSig]
        HRESULT StartArray(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In, MarshalAs(UnmanagedType.LPWStr)] string fmt);

        [PreserveSig]
        HRESULT EndArray(
            [In, MarshalAs(UnmanagedType.LPWStr)] string countPrefix);

        [PreserveSig]
        HRESULT StartList(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fmt);

        [PreserveSig]
        HRESULT EndList();

        [PreserveSig]
        HRESULT StartArrayWithOffset(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string fmt);

        [PreserveSig]
        HRESULT WriteFieldString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string data);

        [PreserveSig]
        HRESULT WriteFieldStringW(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string data);

        [PreserveSig]
        HRESULT WriteFieldPointer(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] long ptr);

        [PreserveSig]
        HRESULT WriteFieldPointerWithSize(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] long ptr,
            [In] long size);

        [PreserveSig]
        HRESULT WriteFieldInt(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] int value);

        [PreserveSig]
        HRESULT WriteFieldUInt(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] int value);

        [PreserveSig]
        HRESULT WriteFieldEnumerated(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] int value,
            [In, MarshalAs(UnmanagedType.LPWStr)] string mnemonic);

        [PreserveSig]
        HRESULT WriteFieldEmpty(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize);

        [PreserveSig]
        HRESULT WriteFieldFlag(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] int flag);

        [PreserveSig]
        HRESULT WriteFieldPointerAnnotated(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] long ptr,
            [In, MarshalAs(UnmanagedType.LPWStr)] string annotation);

        [PreserveSig]
        HRESULT WriteFieldAddress(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] long _base,
            [In] long size);

        [PreserveSig]
        HRESULT StartStructure(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] long ptr,
            [In] long size);

        [PreserveSig]
        HRESULT StartStructureWithNegSpace(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] long ptr,
            [In] long startPtr,
            [In] long totalSize);

        [PreserveSig]
        HRESULT StartStructureWithOffset(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] long ptr,
            [In] long size);

        [PreserveSig]
        HRESULT EndStructure();
    }
}
