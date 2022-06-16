using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
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
            long _base,
            long size,
            int sectionAlign);

        [PreserveSig]
        HRESULT Section(
            string name,
            long rva,
            long size);

        [PreserveSig]
        HRESULT GetDumpOptions(
            [Out] out CLRNativeImageDumpOptions pOptions);

        [PreserveSig]
        HRESULT StartDocument();

        [PreserveSig]
        HRESULT EndDocument();

        [PreserveSig]
        HRESULT StartCategory(
            string name);

        [PreserveSig]
        HRESULT EndCategory();

        [PreserveSig]
        HRESULT StartElement(
            string name);

        [PreserveSig]
        HRESULT EndElement();

        [PreserveSig]
        HRESULT StartVStructure(
            string name);

        [PreserveSig]
        HRESULT StartVStructureWithOffset(
            string name,
            int fieldOffset,
            int fieldSize);

        [PreserveSig]
        HRESULT EndVStructure();

        [PreserveSig]
        HRESULT StartTextElement(
            string name);

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
            string element);

        [PreserveSig]
        HRESULT WriteElementPointer(
            string element,
            long ptr);

        [PreserveSig]
        HRESULT WriteElementPointerAnnotated(
            string element,
            long ptr,
            string annotation);

        [PreserveSig]
        HRESULT WriteElementAddress(
            string element,
            long _base,
            long size);

        [PreserveSig]
        HRESULT WriteElementAddressNamed(
            string element,
            string name,
            long _base,
            long size);

        [PreserveSig]
        HRESULT WriteElementAddressNamedW(
            string element,
            string name,
            long _base,
            long size);

        [PreserveSig]
        HRESULT WriteElementString(
            string element,
            string data);

        [PreserveSig]
        HRESULT WriteElementStringW(
            string element,
            string data);

        [PreserveSig]
        HRESULT WriteElementInt(
            string element,
            int value);

        [PreserveSig]
        HRESULT WriteElementUInt(
            string element,
            int value);

        [PreserveSig]
        HRESULT WriteElementEnumerated(
            string element,
            int value,
            string mnemonic);

        [PreserveSig]
        HRESULT WriteElementIntWithSuppress(
            string element,
            int value,
            int suppressIfEqual);

        [PreserveSig]
        HRESULT WriteElementFlag(
            string element,
            int flag);

        [PreserveSig]
        HRESULT StartArray(
            string name,
            string fmt);

        [PreserveSig]
        HRESULT EndArray(
            string countPrefix);

        [PreserveSig]
        HRESULT StartList(
            string fmt);

        [PreserveSig]
        HRESULT EndList(
            );

        [PreserveSig]
        HRESULT StartArrayWithOffset(
            string name,
            int fieldOffset,
            int fieldSize,
            string fmt);

        [PreserveSig]
        HRESULT WriteFieldString(
            string element,
            int fieldOffset,
            int fieldSize,
            string data);

        [PreserveSig]
        HRESULT WriteFieldStringW(
            string element,
            int fieldOffset,
            int fieldSize,
            string data);

        [PreserveSig]
        HRESULT WriteFieldPointer(
            string element,
            int fieldOffset,
            int fieldSize,
            long ptr);

        [PreserveSig]
        HRESULT WriteFieldPointerWithSize(
            string element,
            int fieldOffset,
            int fieldSize,
            long ptr,
            long size);

        [PreserveSig]
        HRESULT WriteFieldInt(
            string element,
            int fieldOffset,
            int fieldSize,
            int value);

        [PreserveSig]
        HRESULT WriteFieldUInt(
            string element,
            int fieldOffset,
            int fieldSize,
            int value);

        [PreserveSig]
        HRESULT WriteFieldEnumerated(
            string element,
            int fieldOffset,
            int fieldSize,
            int value,
            string mnemonic);

        [PreserveSig]
        HRESULT WriteFieldEmpty(
            string element,
            int fieldOffset,
            int fieldSize);

        [PreserveSig]
        HRESULT WriteFieldFlag(
            string element,
            int fieldOffset,
            int fieldSize,
            int flag);

        [PreserveSig]
        HRESULT WriteFieldPointerAnnotated(
            string element,
            int fieldOffset,
            int fieldSize,
            long ptr,
            string annotation);

        [PreserveSig]
        HRESULT WriteFieldAddress(
            string element,
            int fieldOffset,
            int fieldSize,
            long _base,
            long size);

        [PreserveSig]
        HRESULT StartStructure(
            string name,
            long ptr,
            long size);

        [PreserveSig]
        HRESULT StartStructureWithNegSpace(
            string name,
            long ptr,
            long startPtr,
            long totalSize);

        [PreserveSig]
        HRESULT StartStructureWithOffset(
            string name,
            int fieldOffset,
            int fieldSize,
            long ptr,
            long size);

        [PreserveSig]
        HRESULT EndStructure();
    }
}
