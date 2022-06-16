using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
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
                HRESULT hr;
                CLRNativeImageDumpOptions pOptions;

                if ((hr = TryGetDumpOptions(out pOptions)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
            HRESULT hr;

            if ((hr = TryErrorPrintF()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TryNativeImageDimensions(_base, size, sectionAlign)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryNativeImageDimensions(long _base, long size, int sectionAlign)
        {
            /*HRESULT NativeImageDimensions(
            long _base,
            long size,
            int sectionAlign);*/
            return Raw.NativeImageDimensions(_base, size, sectionAlign);
        }

        #endregion
        #region Section

        public void Section(string name, long rva, long size)
        {
            HRESULT hr;

            if ((hr = TrySection(name, rva, size)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySection(string name, long rva, long size)
        {
            /*HRESULT Section(
            string name,
            long rva,
            long size);*/
            return Raw.Section(name, rva, size);
        }

        #endregion
        #region StartDocument

        public void StartDocument()
        {
            HRESULT hr;

            if ((hr = TryStartDocument()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TryEndDocument()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TryStartCategory(name)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStartCategory(string name)
        {
            /*HRESULT StartCategory(
            string name);*/
            return Raw.StartCategory(name);
        }

        #endregion
        #region EndCategory

        public void EndCategory()
        {
            HRESULT hr;

            if ((hr = TryEndCategory()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TryStartElement(name)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStartElement(string name)
        {
            /*HRESULT StartElement(
            string name);*/
            return Raw.StartElement(name);
        }

        #endregion
        #region EndElement

        public void EndElement()
        {
            HRESULT hr;

            if ((hr = TryEndElement()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TryStartVStructure(name)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStartVStructure(string name)
        {
            /*HRESULT StartVStructure(
            string name);*/
            return Raw.StartVStructure(name);
        }

        #endregion
        #region StartVStructureWithOffset

        public void StartVStructureWithOffset(string name, int fieldOffset, int fieldSize)
        {
            HRESULT hr;

            if ((hr = TryStartVStructureWithOffset(name, fieldOffset, fieldSize)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStartVStructureWithOffset(string name, int fieldOffset, int fieldSize)
        {
            /*HRESULT StartVStructureWithOffset(
            string name,
            int fieldOffset,
            int fieldSize);*/
            return Raw.StartVStructureWithOffset(name, fieldOffset, fieldSize);
        }

        #endregion
        #region EndVStructure

        public void EndVStructure()
        {
            HRESULT hr;

            if ((hr = TryEndVStructure()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TryStartTextElement(name)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStartTextElement(string name)
        {
            /*HRESULT StartTextElement(
            string name);*/
            return Raw.StartTextElement(name);
        }

        #endregion
        #region EndTextElement

        public void EndTextElement()
        {
            HRESULT hr;

            if ((hr = TryEndTextElement()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TryWriteXmlText()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TryWriteXmlTextBlock()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TryWriteEmptyElement(element)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteEmptyElement(string element)
        {
            /*HRESULT WriteEmptyElement(
            string element);*/
            return Raw.WriteEmptyElement(element);
        }

        #endregion
        #region WriteElementPointer

        public void WriteElementPointer(string element, long ptr)
        {
            HRESULT hr;

            if ((hr = TryWriteElementPointer(element, ptr)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteElementPointer(string element, long ptr)
        {
            /*HRESULT WriteElementPointer(
            string element,
            long ptr);*/
            return Raw.WriteElementPointer(element, ptr);
        }

        #endregion
        #region WriteElementPointerAnnotated

        public void WriteElementPointerAnnotated(string element, long ptr, string annotation)
        {
            HRESULT hr;

            if ((hr = TryWriteElementPointerAnnotated(element, ptr, annotation)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteElementPointerAnnotated(string element, long ptr, string annotation)
        {
            /*HRESULT WriteElementPointerAnnotated(
            string element,
            long ptr,
            string annotation);*/
            return Raw.WriteElementPointerAnnotated(element, ptr, annotation);
        }

        #endregion
        #region WriteElementAddress

        public void WriteElementAddress(string element, long _base, long size)
        {
            HRESULT hr;

            if ((hr = TryWriteElementAddress(element, _base, size)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteElementAddress(string element, long _base, long size)
        {
            /*HRESULT WriteElementAddress(
            string element,
            long _base,
            long size);*/
            return Raw.WriteElementAddress(element, _base, size);
        }

        #endregion
        #region WriteElementAddressNamed

        public void WriteElementAddressNamed(string element, string name, long _base, long size)
        {
            HRESULT hr;

            if ((hr = TryWriteElementAddressNamed(element, name, _base, size)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteElementAddressNamed(string element, string name, long _base, long size)
        {
            /*HRESULT WriteElementAddressNamed(
            string element,
            string name,
            long _base,
            long size);*/
            return Raw.WriteElementAddressNamed(element, name, _base, size);
        }

        #endregion
        #region WriteElementAddressNamedW

        public void WriteElementAddressNamedW(string element, string name, long _base, long size)
        {
            HRESULT hr;

            if ((hr = TryWriteElementAddressNamedW(element, name, _base, size)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteElementAddressNamedW(string element, string name, long _base, long size)
        {
            /*HRESULT WriteElementAddressNamedW(
            string element,
            string name,
            long _base,
            long size);*/
            return Raw.WriteElementAddressNamedW(element, name, _base, size);
        }

        #endregion
        #region WriteElementString

        public void WriteElementString(string element, string data)
        {
            HRESULT hr;

            if ((hr = TryWriteElementString(element, data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteElementString(string element, string data)
        {
            /*HRESULT WriteElementString(
            string element,
            string data);*/
            return Raw.WriteElementString(element, data);
        }

        #endregion
        #region WriteElementStringW

        public void WriteElementStringW(string element, string data)
        {
            HRESULT hr;

            if ((hr = TryWriteElementStringW(element, data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteElementStringW(string element, string data)
        {
            /*HRESULT WriteElementStringW(
            string element,
            string data);*/
            return Raw.WriteElementStringW(element, data);
        }

        #endregion
        #region WriteElementInt

        public void WriteElementInt(string element, int value)
        {
            HRESULT hr;

            if ((hr = TryWriteElementInt(element, value)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteElementInt(string element, int value)
        {
            /*HRESULT WriteElementInt(
            string element,
            int value);*/
            return Raw.WriteElementInt(element, value);
        }

        #endregion
        #region WriteElementUInt

        public void WriteElementUInt(string element, int value)
        {
            HRESULT hr;

            if ((hr = TryWriteElementUInt(element, value)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteElementUInt(string element, int value)
        {
            /*HRESULT WriteElementUInt(
            string element,
            int value);*/
            return Raw.WriteElementUInt(element, value);
        }

        #endregion
        #region WriteElementEnumerated

        public void WriteElementEnumerated(string element, int value, string mnemonic)
        {
            HRESULT hr;

            if ((hr = TryWriteElementEnumerated(element, value, mnemonic)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteElementEnumerated(string element, int value, string mnemonic)
        {
            /*HRESULT WriteElementEnumerated(
            string element,
            int value,
            string mnemonic);*/
            return Raw.WriteElementEnumerated(element, value, mnemonic);
        }

        #endregion
        #region WriteElementIntWithSuppress

        public void WriteElementIntWithSuppress(string element, int value, int suppressIfEqual)
        {
            HRESULT hr;

            if ((hr = TryWriteElementIntWithSuppress(element, value, suppressIfEqual)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteElementIntWithSuppress(string element, int value, int suppressIfEqual)
        {
            /*HRESULT WriteElementIntWithSuppress(
            string element,
            int value,
            int suppressIfEqual);*/
            return Raw.WriteElementIntWithSuppress(element, value, suppressIfEqual);
        }

        #endregion
        #region WriteElementFlag

        public void WriteElementFlag(string element, int flag)
        {
            HRESULT hr;

            if ((hr = TryWriteElementFlag(element, flag)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteElementFlag(string element, int flag)
        {
            /*HRESULT WriteElementFlag(
            string element,
            int flag);*/
            return Raw.WriteElementFlag(element, flag);
        }

        #endregion
        #region StartArray

        public void StartArray(string name, string fmt)
        {
            HRESULT hr;

            if ((hr = TryStartArray(name, fmt)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStartArray(string name, string fmt)
        {
            /*HRESULT StartArray(
            string name,
            string fmt);*/
            return Raw.StartArray(name, fmt);
        }

        #endregion
        #region EndArray

        public void EndArray(string countPrefix)
        {
            HRESULT hr;

            if ((hr = TryEndArray(countPrefix)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndArray(string countPrefix)
        {
            /*HRESULT EndArray(
            string countPrefix);*/
            return Raw.EndArray(countPrefix);
        }

        #endregion
        #region StartList

        public void StartList(string fmt)
        {
            HRESULT hr;

            if ((hr = TryStartList(fmt)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStartList(string fmt)
        {
            /*HRESULT StartList(
            string fmt);*/
            return Raw.StartList(fmt);
        }

        #endregion
        #region EndList

        public void EndList()
        {
            HRESULT hr;

            if ((hr = TryEndList()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndList()
        {
            /*HRESULT EndList(
            );*/
            return Raw.EndList();
        }

        #endregion
        #region StartArrayWithOffset

        public void StartArrayWithOffset(string name, int fieldOffset, int fieldSize, string fmt)
        {
            HRESULT hr;

            if ((hr = TryStartArrayWithOffset(name, fieldOffset, fieldSize, fmt)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStartArrayWithOffset(string name, int fieldOffset, int fieldSize, string fmt)
        {
            /*HRESULT StartArrayWithOffset(
            string name,
            int fieldOffset,
            int fieldSize,
            string fmt);*/
            return Raw.StartArrayWithOffset(name, fieldOffset, fieldSize, fmt);
        }

        #endregion
        #region WriteFieldString

        public void WriteFieldString(string element, int fieldOffset, int fieldSize, string data)
        {
            HRESULT hr;

            if ((hr = TryWriteFieldString(element, fieldOffset, fieldSize, data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteFieldString(string element, int fieldOffset, int fieldSize, string data)
        {
            /*HRESULT WriteFieldString(
            string element,
            int fieldOffset,
            int fieldSize,
            string data);*/
            return Raw.WriteFieldString(element, fieldOffset, fieldSize, data);
        }

        #endregion
        #region WriteFieldStringW

        public void WriteFieldStringW(string element, int fieldOffset, int fieldSize, string data)
        {
            HRESULT hr;

            if ((hr = TryWriteFieldStringW(element, fieldOffset, fieldSize, data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteFieldStringW(string element, int fieldOffset, int fieldSize, string data)
        {
            /*HRESULT WriteFieldStringW(
            string element,
            int fieldOffset,
            int fieldSize,
            string data);*/
            return Raw.WriteFieldStringW(element, fieldOffset, fieldSize, data);
        }

        #endregion
        #region WriteFieldPointer

        public void WriteFieldPointer(string element, int fieldOffset, int fieldSize, long ptr)
        {
            HRESULT hr;

            if ((hr = TryWriteFieldPointer(element, fieldOffset, fieldSize, ptr)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteFieldPointer(string element, int fieldOffset, int fieldSize, long ptr)
        {
            /*HRESULT WriteFieldPointer(
            string element,
            int fieldOffset,
            int fieldSize,
            long ptr);*/
            return Raw.WriteFieldPointer(element, fieldOffset, fieldSize, ptr);
        }

        #endregion
        #region WriteFieldPointerWithSize

        public void WriteFieldPointerWithSize(string element, int fieldOffset, int fieldSize, long ptr, long size)
        {
            HRESULT hr;

            if ((hr = TryWriteFieldPointerWithSize(element, fieldOffset, fieldSize, ptr, size)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteFieldPointerWithSize(string element, int fieldOffset, int fieldSize, long ptr, long size)
        {
            /*HRESULT WriteFieldPointerWithSize(
            string element,
            int fieldOffset,
            int fieldSize,
            long ptr,
            long size);*/
            return Raw.WriteFieldPointerWithSize(element, fieldOffset, fieldSize, ptr, size);
        }

        #endregion
        #region WriteFieldInt

        public void WriteFieldInt(string element, int fieldOffset, int fieldSize, int value)
        {
            HRESULT hr;

            if ((hr = TryWriteFieldInt(element, fieldOffset, fieldSize, value)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteFieldInt(string element, int fieldOffset, int fieldSize, int value)
        {
            /*HRESULT WriteFieldInt(
            string element,
            int fieldOffset,
            int fieldSize,
            int value);*/
            return Raw.WriteFieldInt(element, fieldOffset, fieldSize, value);
        }

        #endregion
        #region WriteFieldUInt

        public void WriteFieldUInt(string element, int fieldOffset, int fieldSize, int value)
        {
            HRESULT hr;

            if ((hr = TryWriteFieldUInt(element, fieldOffset, fieldSize, value)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteFieldUInt(string element, int fieldOffset, int fieldSize, int value)
        {
            /*HRESULT WriteFieldUInt(
            string element,
            int fieldOffset,
            int fieldSize,
            int value);*/
            return Raw.WriteFieldUInt(element, fieldOffset, fieldSize, value);
        }

        #endregion
        #region WriteFieldEnumerated

        public void WriteFieldEnumerated(string element, int fieldOffset, int fieldSize, int value, string mnemonic)
        {
            HRESULT hr;

            if ((hr = TryWriteFieldEnumerated(element, fieldOffset, fieldSize, value, mnemonic)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteFieldEnumerated(string element, int fieldOffset, int fieldSize, int value, string mnemonic)
        {
            /*HRESULT WriteFieldEnumerated(
            string element,
            int fieldOffset,
            int fieldSize,
            int value,
            string mnemonic);*/
            return Raw.WriteFieldEnumerated(element, fieldOffset, fieldSize, value, mnemonic);
        }

        #endregion
        #region WriteFieldEmpty

        public void WriteFieldEmpty(string element, int fieldOffset, int fieldSize)
        {
            HRESULT hr;

            if ((hr = TryWriteFieldEmpty(element, fieldOffset, fieldSize)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteFieldEmpty(string element, int fieldOffset, int fieldSize)
        {
            /*HRESULT WriteFieldEmpty(
            string element,
            int fieldOffset,
            int fieldSize);*/
            return Raw.WriteFieldEmpty(element, fieldOffset, fieldSize);
        }

        #endregion
        #region WriteFieldFlag

        public void WriteFieldFlag(string element, int fieldOffset, int fieldSize, int flag)
        {
            HRESULT hr;

            if ((hr = TryWriteFieldFlag(element, fieldOffset, fieldSize, flag)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteFieldFlag(string element, int fieldOffset, int fieldSize, int flag)
        {
            /*HRESULT WriteFieldFlag(
            string element,
            int fieldOffset,
            int fieldSize,
            int flag);*/
            return Raw.WriteFieldFlag(element, fieldOffset, fieldSize, flag);
        }

        #endregion
        #region WriteFieldPointerAnnotated

        public void WriteFieldPointerAnnotated(string element, int fieldOffset, int fieldSize, long ptr, string annotation)
        {
            HRESULT hr;

            if ((hr = TryWriteFieldPointerAnnotated(element, fieldOffset, fieldSize, ptr, annotation)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteFieldPointerAnnotated(string element, int fieldOffset, int fieldSize, long ptr, string annotation)
        {
            /*HRESULT WriteFieldPointerAnnotated(
            string element,
            int fieldOffset,
            int fieldSize,
            long ptr,
            string annotation);*/
            return Raw.WriteFieldPointerAnnotated(element, fieldOffset, fieldSize, ptr, annotation);
        }

        #endregion
        #region WriteFieldAddress

        public void WriteFieldAddress(string element, int fieldOffset, int fieldSize, long _base, long size)
        {
            HRESULT hr;

            if ((hr = TryWriteFieldAddress(element, fieldOffset, fieldSize, _base, size)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteFieldAddress(string element, int fieldOffset, int fieldSize, long _base, long size)
        {
            /*HRESULT WriteFieldAddress(
            string element,
            int fieldOffset,
            int fieldSize,
            long _base,
            long size);*/
            return Raw.WriteFieldAddress(element, fieldOffset, fieldSize, _base, size);
        }

        #endregion
        #region StartStructure

        public void StartStructure(string name, long ptr, long size)
        {
            HRESULT hr;

            if ((hr = TryStartStructure(name, ptr, size)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStartStructure(string name, long ptr, long size)
        {
            /*HRESULT StartStructure(
            string name,
            long ptr,
            long size);*/
            return Raw.StartStructure(name, ptr, size);
        }

        #endregion
        #region StartStructureWithNegSpace

        public void StartStructureWithNegSpace(string name, long ptr, long startPtr, long totalSize)
        {
            HRESULT hr;

            if ((hr = TryStartStructureWithNegSpace(name, ptr, startPtr, totalSize)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStartStructureWithNegSpace(string name, long ptr, long startPtr, long totalSize)
        {
            /*HRESULT StartStructureWithNegSpace(
            string name,
            long ptr,
            long startPtr,
            long totalSize);*/
            return Raw.StartStructureWithNegSpace(name, ptr, startPtr, totalSize);
        }

        #endregion
        #region StartStructureWithOffset

        public void StartStructureWithOffset(string name, int fieldOffset, int fieldSize, long ptr, long size)
        {
            HRESULT hr;

            if ((hr = TryStartStructureWithOffset(name, fieldOffset, fieldSize, ptr, size)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStartStructureWithOffset(string name, int fieldOffset, int fieldSize, long ptr, long size)
        {
            /*HRESULT StartStructureWithOffset(
            string name,
            int fieldOffset,
            int fieldSize,
            long ptr,
            long size);*/
            return Raw.StartStructureWithOffset(name, fieldOffset, fieldSize, ptr, size);
        }

        #endregion
        #region EndStructure

        public void EndStructure()
        {
            HRESULT hr;

            if ((hr = TryEndStructure()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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