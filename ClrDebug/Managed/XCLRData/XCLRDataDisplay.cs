using System;

namespace ClrDebug
{
    public class XCLRDataDisplay : ComObject<IXCLRDataDisplay>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataDisplay"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataDisplay(IXCLRDataDisplay raw) : base(raw)
        {
        }

        #region IXCLRDataDisplay
        #region DumpOptions

        public CLRNativeImageDumpOptions DumpOptions
        {
            get
            {
                CLRNativeImageDumpOptions pOptions;
                TryGetDumpOptions(out pOptions).ThrowOnNotOK();

                return pOptions;
            }
        }

        public HRESULT TryGetDumpOptions(out CLRNativeImageDumpOptions pOptions)
        {
            /*HRESULT GetDumpOptions(
            [Out] out CLRNativeImageDumpOptions pOptions);*/
            return Raw.GetDumpOptions(out pOptions);
        }

        #endregion
        #region ErrorPrintF

        [Obsolete("Vararg functions cannot safely be called from managed code.")]
        public void ErrorPrintF()
        {
            TryErrorPrintF().ThrowOnNotOK();
        }

        [Obsolete("Vararg functions cannot safely be called from managed code.")]
        public HRESULT TryErrorPrintF()
        {
            /*HRESULT ErrorPrintF();*/
            return Raw.ErrorPrintF();
        }

        #endregion
        #region NativeImageDimensions

        public void NativeImageDimensions(long _base, long size, int sectionAlign)
        {
            TryNativeImageDimensions(_base, size, sectionAlign).ThrowOnNotOK();
        }

        public HRESULT TryNativeImageDimensions(long _base, long size, int sectionAlign)
        {
            /*HRESULT NativeImageDimensions(
            [In] long _base,
            [In] long size,
            [In] int sectionAlign);*/
            return Raw.NativeImageDimensions(_base, size, sectionAlign);
        }

        #endregion
        #region Section

        public void Section(string name, long rva, long size)
        {
            TrySection(name, rva, size).ThrowOnNotOK();
        }

        public HRESULT TrySection(string name, long rva, long size)
        {
            /*HRESULT Section(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] long rva,
            [In] long size);*/
            return Raw.Section(name, rva, size);
        }

        #endregion
        #region StartDocument

        public void StartDocument()
        {
            TryStartDocument().ThrowOnNotOK();
        }

        public HRESULT TryStartDocument()
        {
            /*HRESULT StartDocument();*/
            return Raw.StartDocument();
        }

        #endregion
        #region EndDocument

        public void EndDocument()
        {
            TryEndDocument().ThrowOnNotOK();
        }

        public HRESULT TryEndDocument()
        {
            /*HRESULT EndDocument();*/
            return Raw.EndDocument();
        }

        #endregion
        #region StartCategory

        public void StartCategory(string name)
        {
            TryStartCategory(name).ThrowOnNotOK();
        }

        public HRESULT TryStartCategory(string name)
        {
            /*HRESULT StartCategory(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name);*/
            return Raw.StartCategory(name);
        }

        #endregion
        #region EndCategory

        public void EndCategory()
        {
            TryEndCategory().ThrowOnNotOK();
        }

        public HRESULT TryEndCategory()
        {
            /*HRESULT EndCategory();*/
            return Raw.EndCategory();
        }

        #endregion
        #region StartElement

        public void StartElement(string name)
        {
            TryStartElement(name).ThrowOnNotOK();
        }

        public HRESULT TryStartElement(string name)
        {
            /*HRESULT StartElement(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name);*/
            return Raw.StartElement(name);
        }

        #endregion
        #region EndElement

        public void EndElement()
        {
            TryEndElement().ThrowOnNotOK();
        }

        public HRESULT TryEndElement()
        {
            /*HRESULT EndElement();*/
            return Raw.EndElement();
        }

        #endregion
        #region StartVStructure

        public void StartVStructure(string name)
        {
            TryStartVStructure(name).ThrowOnNotOK();
        }

        public HRESULT TryStartVStructure(string name)
        {
            /*HRESULT StartVStructure(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name);*/
            return Raw.StartVStructure(name);
        }

        #endregion
        #region StartVStructureWithOffset

        public void StartVStructureWithOffset(string name, int fieldOffset, int fieldSize)
        {
            TryStartVStructureWithOffset(name, fieldOffset, fieldSize).ThrowOnNotOK();
        }

        public HRESULT TryStartVStructureWithOffset(string name, int fieldOffset, int fieldSize)
        {
            /*HRESULT StartVStructureWithOffset(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int fieldOffset,
            [In] int fieldSize);*/
            return Raw.StartVStructureWithOffset(name, fieldOffset, fieldSize);
        }

        #endregion
        #region EndVStructure

        public void EndVStructure()
        {
            TryEndVStructure().ThrowOnNotOK();
        }

        public HRESULT TryEndVStructure()
        {
            /*HRESULT EndVStructure();*/
            return Raw.EndVStructure();
        }

        #endregion
        #region StartTextElement

        public void StartTextElement(string name)
        {
            TryStartTextElement(name).ThrowOnNotOK();
        }

        public HRESULT TryStartTextElement(string name)
        {
            /*HRESULT StartTextElement(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name);*/
            return Raw.StartTextElement(name);
        }

        #endregion
        #region EndTextElement

        public void EndTextElement()
        {
            TryEndTextElement().ThrowOnNotOK();
        }

        public HRESULT TryEndTextElement()
        {
            /*HRESULT EndTextElement();*/
            return Raw.EndTextElement();
        }

        #endregion
        #region WriteXmlText

        [Obsolete("Vararg functions cannot safely be called from managed code.")]
        public void WriteXmlText()
        {
            TryWriteXmlText().ThrowOnNotOK();
        }

        [Obsolete("Vararg functions cannot safely be called from managed code.")]
        public HRESULT TryWriteXmlText()
        {
            /*HRESULT WriteXmlText();*/
            return Raw.WriteXmlText();
        }

        #endregion
        #region WriteXmlTextBlock

        [Obsolete("Vararg functions cannot safely be called from managed code.")]
        public void WriteXmlTextBlock()
        {
            TryWriteXmlTextBlock().ThrowOnNotOK();
        }

        [Obsolete("Vararg functions cannot safely be called from managed code.")]
        public HRESULT TryWriteXmlTextBlock()
        {
            /*HRESULT WriteXmlTextBlock();*/
            return Raw.WriteXmlTextBlock();
        }

        #endregion
        #region WriteEmptyElement

        public void WriteEmptyElement(string element)
        {
            TryWriteEmptyElement(element).ThrowOnNotOK();
        }

        public HRESULT TryWriteEmptyElement(string element)
        {
            /*HRESULT WriteEmptyElement(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element);*/
            return Raw.WriteEmptyElement(element);
        }

        #endregion
        #region WriteElementPointer

        public void WriteElementPointer(string element, long ptr)
        {
            TryWriteElementPointer(element, ptr).ThrowOnNotOK();
        }

        public HRESULT TryWriteElementPointer(string element, long ptr)
        {
            /*HRESULT WriteElementPointer(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] long ptr);*/
            return Raw.WriteElementPointer(element, ptr);
        }

        #endregion
        #region WriteElementPointerAnnotated

        public void WriteElementPointerAnnotated(string element, long ptr, string annotation)
        {
            TryWriteElementPointerAnnotated(element, ptr, annotation).ThrowOnNotOK();
        }

        public HRESULT TryWriteElementPointerAnnotated(string element, long ptr, string annotation)
        {
            /*HRESULT WriteElementPointerAnnotated(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] long ptr,
            [In, MarshalAs(UnmanagedType.LPWStr)] string annotation);*/
            return Raw.WriteElementPointerAnnotated(element, ptr, annotation);
        }

        #endregion
        #region WriteElementAddress

        public void WriteElementAddress(string element, long _base, long size)
        {
            TryWriteElementAddress(element, _base, size).ThrowOnNotOK();
        }

        public HRESULT TryWriteElementAddress(string element, long _base, long size)
        {
            /*HRESULT WriteElementAddress(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] long _base,
            [In] long size);*/
            return Raw.WriteElementAddress(element, _base, size);
        }

        #endregion
        #region WriteElementAddressNamed

        public void WriteElementAddressNamed(string element, string name, long _base, long size)
        {
            TryWriteElementAddressNamed(element, name, _base, size).ThrowOnNotOK();
        }

        public HRESULT TryWriteElementAddressNamed(string element, string name, long _base, long size)
        {
            /*HRESULT WriteElementAddressNamed(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] long _base,
            [In] long size);*/
            return Raw.WriteElementAddressNamed(element, name, _base, size);
        }

        #endregion
        #region WriteElementAddressNamedW

        public void WriteElementAddressNamedW(string element, string name, long _base, long size)
        {
            TryWriteElementAddressNamedW(element, name, _base, size).ThrowOnNotOK();
        }

        public HRESULT TryWriteElementAddressNamedW(string element, string name, long _base, long size)
        {
            /*HRESULT WriteElementAddressNamedW(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] long _base,
            [In] long size);*/
            return Raw.WriteElementAddressNamedW(element, name, _base, size);
        }

        #endregion
        #region WriteElementString

        public void WriteElementString(string element, string data)
        {
            TryWriteElementString(element, data).ThrowOnNotOK();
        }

        public HRESULT TryWriteElementString(string element, string data)
        {
            /*HRESULT WriteElementString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In, MarshalAs(UnmanagedType.LPWStr)] string data);*/
            return Raw.WriteElementString(element, data);
        }

        #endregion
        #region WriteElementStringW

        public void WriteElementStringW(string element, string data)
        {
            TryWriteElementStringW(element, data).ThrowOnNotOK();
        }

        public HRESULT TryWriteElementStringW(string element, string data)
        {
            /*HRESULT WriteElementStringW(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In, MarshalAs(UnmanagedType.LPWStr)] string data);*/
            return Raw.WriteElementStringW(element, data);
        }

        #endregion
        #region WriteElementInt

        public void WriteElementInt(string element, int value)
        {
            TryWriteElementInt(element, value).ThrowOnNotOK();
        }

        public HRESULT TryWriteElementInt(string element, int value)
        {
            /*HRESULT WriteElementInt(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int value);*/
            return Raw.WriteElementInt(element, value);
        }

        #endregion
        #region WriteElementUInt

        public void WriteElementUInt(string element, int value)
        {
            TryWriteElementUInt(element, value).ThrowOnNotOK();
        }

        public HRESULT TryWriteElementUInt(string element, int value)
        {
            /*HRESULT WriteElementUInt(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int value);*/
            return Raw.WriteElementUInt(element, value);
        }

        #endregion
        #region WriteElementEnumerated

        public void WriteElementEnumerated(string element, int value, string mnemonic)
        {
            TryWriteElementEnumerated(element, value, mnemonic).ThrowOnNotOK();
        }

        public HRESULT TryWriteElementEnumerated(string element, int value, string mnemonic)
        {
            /*HRESULT WriteElementEnumerated(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int value,
            [In, MarshalAs(UnmanagedType.LPWStr)] string mnemonic);*/
            return Raw.WriteElementEnumerated(element, value, mnemonic);
        }

        #endregion
        #region WriteElementIntWithSuppress

        public void WriteElementIntWithSuppress(string element, int value, int suppressIfEqual)
        {
            TryWriteElementIntWithSuppress(element, value, suppressIfEqual).ThrowOnNotOK();
        }

        public HRESULT TryWriteElementIntWithSuppress(string element, int value, int suppressIfEqual)
        {
            /*HRESULT WriteElementIntWithSuppress(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int value,
            [In] int suppressIfEqual);*/
            return Raw.WriteElementIntWithSuppress(element, value, suppressIfEqual);
        }

        #endregion
        #region WriteElementFlag

        public void WriteElementFlag(string element, int flag)
        {
            TryWriteElementFlag(element, flag).ThrowOnNotOK();
        }

        public HRESULT TryWriteElementFlag(string element, int flag)
        {
            /*HRESULT WriteElementFlag(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int flag);*/
            return Raw.WriteElementFlag(element, flag);
        }

        #endregion
        #region StartArray

        public void StartArray(string name, string fmt)
        {
            TryStartArray(name, fmt).ThrowOnNotOK();
        }

        public HRESULT TryStartArray(string name, string fmt)
        {
            /*HRESULT StartArray(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In, MarshalAs(UnmanagedType.LPWStr)] string fmt);*/
            return Raw.StartArray(name, fmt);
        }

        #endregion
        #region EndArray

        public void EndArray(string countPrefix)
        {
            TryEndArray(countPrefix).ThrowOnNotOK();
        }

        public HRESULT TryEndArray(string countPrefix)
        {
            /*HRESULT EndArray(
            [In, MarshalAs(UnmanagedType.LPWStr)] string countPrefix);*/
            return Raw.EndArray(countPrefix);
        }

        #endregion
        #region StartList

        public void StartList(string fmt)
        {
            TryStartList(fmt).ThrowOnNotOK();
        }

        public HRESULT TryStartList(string fmt)
        {
            /*HRESULT StartList(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fmt);*/
            return Raw.StartList(fmt);
        }

        #endregion
        #region EndList

        public void EndList()
        {
            TryEndList().ThrowOnNotOK();
        }

        public HRESULT TryEndList()
        {
            /*HRESULT EndList();*/
            return Raw.EndList();
        }

        #endregion
        #region StartArrayWithOffset

        public void StartArrayWithOffset(string name, int fieldOffset, int fieldSize, string fmt)
        {
            TryStartArrayWithOffset(name, fieldOffset, fieldSize, fmt).ThrowOnNotOK();
        }

        public HRESULT TryStartArrayWithOffset(string name, int fieldOffset, int fieldSize, string fmt)
        {
            /*HRESULT StartArrayWithOffset(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string fmt);*/
            return Raw.StartArrayWithOffset(name, fieldOffset, fieldSize, fmt);
        }

        #endregion
        #region WriteFieldString

        public void WriteFieldString(string element, int fieldOffset, int fieldSize, string data)
        {
            TryWriteFieldString(element, fieldOffset, fieldSize, data).ThrowOnNotOK();
        }

        public HRESULT TryWriteFieldString(string element, int fieldOffset, int fieldSize, string data)
        {
            /*HRESULT WriteFieldString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string data);*/
            return Raw.WriteFieldString(element, fieldOffset, fieldSize, data);
        }

        #endregion
        #region WriteFieldStringW

        public void WriteFieldStringW(string element, int fieldOffset, int fieldSize, string data)
        {
            TryWriteFieldStringW(element, fieldOffset, fieldSize, data).ThrowOnNotOK();
        }

        public HRESULT TryWriteFieldStringW(string element, int fieldOffset, int fieldSize, string data)
        {
            /*HRESULT WriteFieldStringW(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string data);*/
            return Raw.WriteFieldStringW(element, fieldOffset, fieldSize, data);
        }

        #endregion
        #region WriteFieldPointer

        public void WriteFieldPointer(string element, int fieldOffset, int fieldSize, long ptr)
        {
            TryWriteFieldPointer(element, fieldOffset, fieldSize, ptr).ThrowOnNotOK();
        }

        public HRESULT TryWriteFieldPointer(string element, int fieldOffset, int fieldSize, long ptr)
        {
            /*HRESULT WriteFieldPointer(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] long ptr);*/
            return Raw.WriteFieldPointer(element, fieldOffset, fieldSize, ptr);
        }

        #endregion
        #region WriteFieldPointerWithSize

        public void WriteFieldPointerWithSize(string element, int fieldOffset, int fieldSize, long ptr, long size)
        {
            TryWriteFieldPointerWithSize(element, fieldOffset, fieldSize, ptr, size).ThrowOnNotOK();
        }

        public HRESULT TryWriteFieldPointerWithSize(string element, int fieldOffset, int fieldSize, long ptr, long size)
        {
            /*HRESULT WriteFieldPointerWithSize(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] long ptr,
            [In] long size);*/
            return Raw.WriteFieldPointerWithSize(element, fieldOffset, fieldSize, ptr, size);
        }

        #endregion
        #region WriteFieldInt

        public void WriteFieldInt(string element, int fieldOffset, int fieldSize, int value)
        {
            TryWriteFieldInt(element, fieldOffset, fieldSize, value).ThrowOnNotOK();
        }

        public HRESULT TryWriteFieldInt(string element, int fieldOffset, int fieldSize, int value)
        {
            /*HRESULT WriteFieldInt(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] int value);*/
            return Raw.WriteFieldInt(element, fieldOffset, fieldSize, value);
        }

        #endregion
        #region WriteFieldUInt

        public void WriteFieldUInt(string element, int fieldOffset, int fieldSize, int value)
        {
            TryWriteFieldUInt(element, fieldOffset, fieldSize, value).ThrowOnNotOK();
        }

        public HRESULT TryWriteFieldUInt(string element, int fieldOffset, int fieldSize, int value)
        {
            /*HRESULT WriteFieldUInt(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] int value);*/
            return Raw.WriteFieldUInt(element, fieldOffset, fieldSize, value);
        }

        #endregion
        #region WriteFieldEnumerated

        public void WriteFieldEnumerated(string element, int fieldOffset, int fieldSize, int value, string mnemonic)
        {
            TryWriteFieldEnumerated(element, fieldOffset, fieldSize, value, mnemonic).ThrowOnNotOK();
        }

        public HRESULT TryWriteFieldEnumerated(string element, int fieldOffset, int fieldSize, int value, string mnemonic)
        {
            /*HRESULT WriteFieldEnumerated(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] int value,
            [In, MarshalAs(UnmanagedType.LPWStr)] string mnemonic);*/
            return Raw.WriteFieldEnumerated(element, fieldOffset, fieldSize, value, mnemonic);
        }

        #endregion
        #region WriteFieldEmpty

        public void WriteFieldEmpty(string element, int fieldOffset, int fieldSize)
        {
            TryWriteFieldEmpty(element, fieldOffset, fieldSize).ThrowOnNotOK();
        }

        public HRESULT TryWriteFieldEmpty(string element, int fieldOffset, int fieldSize)
        {
            /*HRESULT WriteFieldEmpty(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize);*/
            return Raw.WriteFieldEmpty(element, fieldOffset, fieldSize);
        }

        #endregion
        #region WriteFieldFlag

        public void WriteFieldFlag(string element, int fieldOffset, int fieldSize, int flag)
        {
            TryWriteFieldFlag(element, fieldOffset, fieldSize, flag).ThrowOnNotOK();
        }

        public HRESULT TryWriteFieldFlag(string element, int fieldOffset, int fieldSize, int flag)
        {
            /*HRESULT WriteFieldFlag(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] int flag);*/
            return Raw.WriteFieldFlag(element, fieldOffset, fieldSize, flag);
        }

        #endregion
        #region WriteFieldPointerAnnotated

        public void WriteFieldPointerAnnotated(string element, int fieldOffset, int fieldSize, long ptr, string annotation)
        {
            TryWriteFieldPointerAnnotated(element, fieldOffset, fieldSize, ptr, annotation).ThrowOnNotOK();
        }

        public HRESULT TryWriteFieldPointerAnnotated(string element, int fieldOffset, int fieldSize, long ptr, string annotation)
        {
            /*HRESULT WriteFieldPointerAnnotated(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] long ptr,
            [In, MarshalAs(UnmanagedType.LPWStr)] string annotation);*/
            return Raw.WriteFieldPointerAnnotated(element, fieldOffset, fieldSize, ptr, annotation);
        }

        #endregion
        #region WriteFieldAddress

        public void WriteFieldAddress(string element, int fieldOffset, int fieldSize, long _base, long size)
        {
            TryWriteFieldAddress(element, fieldOffset, fieldSize, _base, size).ThrowOnNotOK();
        }

        public HRESULT TryWriteFieldAddress(string element, int fieldOffset, int fieldSize, long _base, long size)
        {
            /*HRESULT WriteFieldAddress(
            [In, MarshalAs(UnmanagedType.LPWStr)] string element,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] long _base,
            [In] long size);*/
            return Raw.WriteFieldAddress(element, fieldOffset, fieldSize, _base, size);
        }

        #endregion
        #region StartStructure

        public void StartStructure(string name, long ptr, long size)
        {
            TryStartStructure(name, ptr, size).ThrowOnNotOK();
        }

        public HRESULT TryStartStructure(string name, long ptr, long size)
        {
            /*HRESULT StartStructure(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] long ptr,
            [In] long size);*/
            return Raw.StartStructure(name, ptr, size);
        }

        #endregion
        #region StartStructureWithNegSpace

        public void StartStructureWithNegSpace(string name, long ptr, long startPtr, long totalSize)
        {
            TryStartStructureWithNegSpace(name, ptr, startPtr, totalSize).ThrowOnNotOK();
        }

        public HRESULT TryStartStructureWithNegSpace(string name, long ptr, long startPtr, long totalSize)
        {
            /*HRESULT StartStructureWithNegSpace(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] long ptr,
            [In] long startPtr,
            [In] long totalSize);*/
            return Raw.StartStructureWithNegSpace(name, ptr, startPtr, totalSize);
        }

        #endregion
        #region StartStructureWithOffset

        public void StartStructureWithOffset(string name, int fieldOffset, int fieldSize, long ptr, long size)
        {
            TryStartStructureWithOffset(name, fieldOffset, fieldSize, ptr, size).ThrowOnNotOK();
        }

        public HRESULT TryStartStructureWithOffset(string name, int fieldOffset, int fieldSize, long ptr, long size)
        {
            /*HRESULT StartStructureWithOffset(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int fieldOffset,
            [In] int fieldSize,
            [In] long ptr,
            [In] long size);*/
            return Raw.StartStructureWithOffset(name, fieldOffset, fieldSize, ptr, size);
        }

        #endregion
        #region EndStructure

        public void EndStructure()
        {
            TryEndStructure().ThrowOnNotOK();
        }

        public HRESULT TryEndStructure()
        {
            /*HRESULT EndStructure();*/
            return Raw.EndStructure();
        }

        #endregion
        #endregion
    }
}
