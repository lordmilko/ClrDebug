using System;
using static ClrDebug.Extensions;

namespace ClrDebug
{
    public class XCLRDataValue : ComObject<IXCLRDataValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataValue"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataValue(IXCLRDataValue raw) : base(raw)
        {
        }

        #region IXCLRDataValue
        #region Flags

        public CLRDataValueFlag Flags
        {
            get
            {
                CLRDataValueFlag flags;
                TryGetFlags(out flags).ThrowOnNotOK();

                return flags;
            }
        }

        public HRESULT TryGetFlags(out CLRDataValueFlag flags)
        {
            /*HRESULT GetFlags(
            [Out] out CLRDataValueFlag flags);*/
            return Raw.GetFlags(out flags);
        }

        #endregion
        #region Address

        public CLRDATA_ADDRESS Address
        {
            get
            {
                CLRDATA_ADDRESS address;
                TryGetAddress(out address).ThrowOnNotOK();

                return address;
            }
        }

        public HRESULT TryGetAddress(out CLRDATA_ADDRESS address)
        {
            /*HRESULT GetAddress(
            [Out] out CLRDATA_ADDRESS address);*/
            return Raw.GetAddress(out address);
        }

        #endregion
        #region Size

        public long Size
        {
            get
            {
                long size;
                TryGetSize(out size).ThrowOnNotOK();

                return size;
            }
        }

        public HRESULT TryGetSize(out long size)
        {
            /*HRESULT GetSize(
            [Out] out long size);*/
            return Raw.GetSize(out size);
        }

        #endregion
        #region Type

        public XCLRDataTypeInstance Type
        {
            get
            {
                XCLRDataTypeInstance typeInstanceResult;
                TryGetType(out typeInstanceResult).ThrowOnNotOK();

                return typeInstanceResult;
            }
        }

        public HRESULT TryGetType(out XCLRDataTypeInstance typeInstanceResult)
        {
            /*HRESULT GetType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeInstance typeInstance);*/
            IXCLRDataTypeInstance typeInstance;
            HRESULT hr = Raw.GetType(out typeInstance);

            if (hr == HRESULT.S_OK)
                typeInstanceResult = typeInstance == null ? null : new XCLRDataTypeInstance(typeInstance);
            else
                typeInstanceResult = default(XCLRDataTypeInstance);

            return hr;
        }

        #endregion
        #region NumFields

        public int NumFields
        {
            get
            {
                int numFields;
                TryGetNumFields(out numFields).ThrowOnNotOK();

                return numFields;
            }
        }

        public HRESULT TryGetNumFields(out int numFields)
        {
            /*HRESULT GetNumFields(
            [Out] out int numFields);*/
            return Raw.GetNumFields(out numFields);
        }

        #endregion
        #region AssociatedValue

        public XCLRDataValue AssociatedValue
        {
            get
            {
                XCLRDataValue assocValueResult;
                TryGetAssociatedValue(out assocValueResult).ThrowOnNotOK();

                return assocValueResult;
            }
        }

        public HRESULT TryGetAssociatedValue(out XCLRDataValue assocValueResult)
        {
            /*HRESULT GetAssociatedValue(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue assocValue);*/
            IXCLRDataValue assocValue;
            HRESULT hr = Raw.GetAssociatedValue(out assocValue);

            if (hr == HRESULT.S_OK)
                assocValueResult = assocValue == null ? null : new XCLRDataValue(assocValue);
            else
                assocValueResult = default(XCLRDataValue);

            return hr;
        }

        #endregion
        #region AssociatedType

        public XCLRDataTypeInstance AssociatedType
        {
            get
            {
                XCLRDataTypeInstance assocTypeResult;
                TryGetAssociatedType(out assocTypeResult).ThrowOnNotOK();

                return assocTypeResult;
            }
        }

        public HRESULT TryGetAssociatedType(out XCLRDataTypeInstance assocTypeResult)
        {
            /*HRESULT GetAssociatedType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeInstance assocType);*/
            IXCLRDataTypeInstance assocType;
            HRESULT hr = Raw.GetAssociatedType(out assocType);

            if (hr == HRESULT.S_OK)
                assocTypeResult = assocType == null ? null : new XCLRDataTypeInstance(assocType);
            else
                assocTypeResult = default(XCLRDataTypeInstance);

            return hr;
        }

        #endregion
        #region String

        public string String
        {
            get
            {
                string strResult;
                TryGetString(out strResult).ThrowOnNotOK();

                return strResult;
            }
        }

        public HRESULT TryGetString(out string strResult)
        {
            /*HRESULT GetString(
            [In] int bufLen,
            [Out] out int strLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] str);*/
            int bufLen = 0;
            int strLen;
            char[] str;
            HRESULT hr = Raw.GetString(bufLen, out strLen, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = strLen;
            str = new char[bufLen];
            hr = Raw.GetString(bufLen, out strLen, str);

            if (hr == HRESULT.S_OK)
            {
                strResult = CreateString(str, strLen);

                return hr;
            }

            fail:
            strResult = default(string);

            return hr;
        }

        #endregion
        #region NumLocations

        public int NumLocations
        {
            get
            {
                int numLocs;
                TryGetNumLocations(out numLocs).ThrowOnNotOK();

                return numLocs;
            }
        }

        public HRESULT TryGetNumLocations(out int numLocs)
        {
            /*HRESULT GetNumLocations(
            [Out] out int numLocs);*/
            return Raw.GetNumLocations(out numLocs);
        }

        #endregion
        #region GetBytes

        public GetBytesResult GetBytes(int bufLen)
        {
            GetBytesResult result;
            TryGetBytes(bufLen, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetBytes(int bufLen, out GetBytesResult result)
        {
            /*HRESULT GetBytes(
            [In] int bufLen,
            [Out] out int dataSize,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] buffer);*/
            int dataSize;
            byte[] buffer = new byte[bufLen];
            HRESULT hr = Raw.GetBytes(bufLen, out dataSize, buffer);

            if (hr == HRESULT.S_OK)
                result = new GetBytesResult(dataSize, buffer);
            else
                result = default(GetBytesResult);

            return hr;
        }

        #endregion
        #region SetBytes

        public int SetBytes(int bufLen, byte[] buffer)
        {
            int dataSize;
            TrySetBytes(bufLen, out dataSize, buffer).ThrowOnNotOK();

            return dataSize;
        }

        public HRESULT TrySetBytes(int bufLen, out int dataSize, byte[] buffer)
        {
            /*HRESULT SetBytes(
            [In] int bufLen,
            [Out] out int dataSize,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] buffer);*/
            return Raw.SetBytes(bufLen, out dataSize, buffer);
        }

        #endregion
        #region GetFieldByIndex

        public GetFieldByIndexResult GetFieldByIndex(int index)
        {
            GetFieldByIndexResult result;
            TryGetFieldByIndex(index, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetFieldByIndex(int index, out GetFieldByIndexResult result)
        {
            /*HRESULT GetFieldByIndex(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] nameBuf,
            [Out] out mdFieldDef token);*/
            IXCLRDataValue field;
            int bufLen = 0;
            int nameLen;
            char[] nameBuf;
            mdFieldDef token;
            HRESULT hr = Raw.GetFieldByIndex(index, out field, bufLen, out nameLen, null, out token);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new char[bufLen];
            hr = Raw.GetFieldByIndex(index, out field, bufLen, out nameLen, nameBuf, out token);

            if (hr == HRESULT.S_OK)
            {
                result = new GetFieldByIndexResult(field == null ? null : new XCLRDataValue(field), CreateString(nameBuf, nameLen), token);

                return hr;
            }

            fail:
            result = default(GetFieldByIndexResult);

            return hr;
        }

        #endregion
        #region Request

        public void Request(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize, IntPtr outBuffer)
        {
            TryRequest(reqCode, inBufferSize, inBuffer, outBufferSize, outBuffer).ThrowOnNotOK();
        }

        public HRESULT TryRequest(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize, IntPtr outBuffer)
        {
            /*HRESULT Request(
            [In] uint reqCode, //Requests can be across a variety of enums
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);*/
            return Raw.Request(reqCode, inBufferSize, inBuffer, outBufferSize, outBuffer);
        }

        #endregion
        #region GetNumFields2

        public int GetNumFields2(CLRDataFieldFlag flags, IXCLRDataTypeInstance fromType)
        {
            int numFields;
            TryGetNumFields2(flags, fromType, out numFields).ThrowOnNotOK();

            return numFields;
        }

        public HRESULT TryGetNumFields2(CLRDataFieldFlag flags, IXCLRDataTypeInstance fromType, out int numFields)
        {
            /*HRESULT GetNumFields2(
            [In] CLRDataFieldFlag flags,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTypeInstance fromType,
            [Out] out int numFields);*/
            return Raw.GetNumFields2(flags, fromType, out numFields);
        }

        #endregion
        #region StartEnumFields

        public IntPtr StartEnumFields(CLRDataFieldFlag flags, IXCLRDataTypeInstance fromType)
        {
            IntPtr handle;
            TryStartEnumFields(flags, fromType, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumFields(CLRDataFieldFlag flags, IXCLRDataTypeInstance fromType, out IntPtr handle)
        {
            /*HRESULT StartEnumFields(
            [In] CLRDataFieldFlag flags,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTypeInstance fromType,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumFields(flags, fromType, out handle);
        }

        #endregion
        #region EnumField

        public XCLRDataValue_EnumFieldResult EnumField(ref IntPtr handle)
        {
            XCLRDataValue_EnumFieldResult result;
            TryEnumField(ref handle, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryEnumField(ref IntPtr handle, out XCLRDataValue_EnumFieldResult result)
        {
            /*HRESULT EnumField(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] nameBuf,
            [Out] out mdFieldDef token);*/
            IXCLRDataValue field;
            int nameBufLen = 0;
            int nameLen;
            char[] nameBuf;
            mdFieldDef token;
            HRESULT hr = Raw.EnumField(ref handle, out field, nameBufLen, out nameLen, null, out token);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufLen = nameLen;
            nameBuf = new char[nameBufLen];
            hr = Raw.EnumField(ref handle, out field, nameBufLen, out nameLen, nameBuf, out token);

            if (hr == HRESULT.S_OK)
            {
                result = new XCLRDataValue_EnumFieldResult(field == null ? null : new XCLRDataValue(field), CreateString(nameBuf, nameLen), token);

                return hr;
            }

            fail:
            result = default(XCLRDataValue_EnumFieldResult);

            return hr;
        }

        #endregion
        #region EndEnumFields

        public void EndEnumFields(IntPtr handle)
        {
            TryEndEnumFields(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumFields(IntPtr handle)
        {
            /*HRESULT EndEnumFields(
            [In] IntPtr handle);*/
            return Raw.EndEnumFields(handle);
        }

        #endregion
        #region StartEnumFieldsByName

        public IntPtr StartEnumFieldsByName(string name, CLRDataByNameFlag nameFlags, CLRDataFieldFlag fieldFlags, IXCLRDataTypeInstance fromType)
        {
            IntPtr handle;
            TryStartEnumFieldsByName(name, nameFlags, fieldFlags, fromType, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumFieldsByName(string name, CLRDataByNameFlag nameFlags, CLRDataFieldFlag fieldFlags, IXCLRDataTypeInstance fromType, out IntPtr handle)
        {
            /*HRESULT StartEnumFieldsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag nameFlags,
            [In] CLRDataFieldFlag fieldFlags,
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTypeInstance fromType,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumFieldsByName(name, nameFlags, fieldFlags, fromType, out handle);
        }

        #endregion
        #region EnumFieldByName

        public XCLRDataValue_EnumFieldByNameResult EnumFieldByName(ref IntPtr handle)
        {
            XCLRDataValue_EnumFieldByNameResult result;
            TryEnumFieldByName(ref handle, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryEnumFieldByName(ref IntPtr handle, out XCLRDataValue_EnumFieldByNameResult result)
        {
            /*HRESULT EnumFieldByName(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [Out] out mdFieldDef token);*/
            IXCLRDataValue field;
            mdFieldDef token;
            HRESULT hr = Raw.EnumFieldByName(ref handle, out field, out token);

            if (hr == HRESULT.S_OK)
                result = new XCLRDataValue_EnumFieldByNameResult(field == null ? null : new XCLRDataValue(field), token);
            else
                result = default(XCLRDataValue_EnumFieldByNameResult);

            return hr;
        }

        #endregion
        #region EndEnumFieldsByName

        public void EndEnumFieldsByName(IntPtr handle)
        {
            TryEndEnumFieldsByName(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumFieldsByName(IntPtr handle)
        {
            /*HRESULT EndEnumFieldsByName(
            [In] IntPtr handle);*/
            return Raw.EndEnumFieldsByName(handle);
        }

        #endregion
        #region GetFieldByToken

        public XCLRDataValue_GetFieldByTokenResult GetFieldByToken(mdFieldDef token)
        {
            XCLRDataValue_GetFieldByTokenResult result;
            TryGetFieldByToken(token, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetFieldByToken(mdFieldDef token, out XCLRDataValue_GetFieldByTokenResult result)
        {
            /*HRESULT GetFieldByToken(
            [In] mdFieldDef token,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] nameBuf);*/
            IXCLRDataValue field;
            int bufLen = 0;
            int nameLen;
            char[] nameBuf;
            HRESULT hr = Raw.GetFieldByToken(token, out field, bufLen, out nameLen, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new char[bufLen];
            hr = Raw.GetFieldByToken(token, out field, bufLen, out nameLen, nameBuf);

            if (hr == HRESULT.S_OK)
            {
                result = new XCLRDataValue_GetFieldByTokenResult(field == null ? null : new XCLRDataValue(field), CreateString(nameBuf, nameLen));

                return hr;
            }

            fail:
            result = default(XCLRDataValue_GetFieldByTokenResult);

            return hr;
        }

        #endregion
        #region GetArrayProperties

        public GetArrayPropertiesResult GetArrayProperties(int numDim, int numBases)
        {
            GetArrayPropertiesResult result;
            TryGetArrayProperties(numDim, numBases, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetArrayProperties(int numDim, int numBases, out GetArrayPropertiesResult result)
        {
            /*HRESULT GetArrayProperties(
            [Out] out int rank,
            [Out] out int totalElements,
            [In] int numDim,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] dims,
            [In] int numBases,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] int[] bases);*/
            int rank;
            int totalElements;
            int[] dims = new int[numDim];
            int[] bases = new int[numBases];
            HRESULT hr = Raw.GetArrayProperties(out rank, out totalElements, numDim, dims, numBases, bases);

            if (hr == HRESULT.S_OK)
                result = new GetArrayPropertiesResult(rank, totalElements, dims, bases);
            else
                result = default(GetArrayPropertiesResult);

            return hr;
        }

        #endregion
        #region GetArrayElement

        public XCLRDataValue GetArrayElement(int numInd, int[] indices)
        {
            XCLRDataValue valueResult;
            TryGetArrayElement(numInd, indices, out valueResult).ThrowOnNotOK();

            return valueResult;
        }

        public HRESULT TryGetArrayElement(int numInd, int[] indices, out XCLRDataValue valueResult)
        {
            /*HRESULT GetArrayElement(
            [In] int numInd,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] indices,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue value);*/
            IXCLRDataValue value;
            HRESULT hr = Raw.GetArrayElement(numInd, indices, out value);

            if (hr == HRESULT.S_OK)
                valueResult = value == null ? null : new XCLRDataValue(value);
            else
                valueResult = default(XCLRDataValue);

            return hr;
        }

        #endregion
        #region EnumField2

        public XCLRDataValue_EnumField2Result EnumField2(ref IntPtr handle)
        {
            XCLRDataValue_EnumField2Result result;
            TryEnumField2(ref handle, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryEnumField2(ref IntPtr handle, out XCLRDataValue_EnumField2Result result)
        {
            /*HRESULT EnumField2(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] nameBuf,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);*/
            IXCLRDataValue field;
            int nameBufLen = 0;
            int nameLen;
            char[] nameBuf;
            IXCLRDataModule tokenScope;
            mdFieldDef token;
            HRESULT hr = Raw.EnumField2(ref handle, out field, nameBufLen, out nameLen, null, out tokenScope, out token);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufLen = nameLen;
            nameBuf = new char[nameBufLen];
            hr = Raw.EnumField2(ref handle, out field, nameBufLen, out nameLen, nameBuf, out tokenScope, out token);

            if (hr == HRESULT.S_OK)
            {
                result = new XCLRDataValue_EnumField2Result(field == null ? null : new XCLRDataValue(field), CreateString(nameBuf, nameLen), tokenScope == null ? null : new XCLRDataModule(tokenScope), token);

                return hr;
            }

            fail:
            result = default(XCLRDataValue_EnumField2Result);

            return hr;
        }

        #endregion
        #region EnumFieldByName2

        public XCLRDataValue_EnumFieldByName2Result EnumFieldByName2(ref IntPtr handle)
        {
            XCLRDataValue_EnumFieldByName2Result result;
            TryEnumFieldByName2(ref handle, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryEnumFieldByName2(ref IntPtr handle, out XCLRDataValue_EnumFieldByName2Result result)
        {
            /*HRESULT EnumFieldByName2(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);*/
            IXCLRDataValue field;
            IXCLRDataModule tokenScope;
            mdFieldDef token;
            HRESULT hr = Raw.EnumFieldByName2(ref handle, out field, out tokenScope, out token);

            if (hr == HRESULT.S_OK)
                result = new XCLRDataValue_EnumFieldByName2Result(field == null ? null : new XCLRDataValue(field), tokenScope == null ? null : new XCLRDataModule(tokenScope), token);
            else
                result = default(XCLRDataValue_EnumFieldByName2Result);

            return hr;
        }

        #endregion
        #region GetFieldByToken2

        public XCLRDataValue_GetFieldByToken2Result GetFieldByToken2(IXCLRDataModule tokenScope, mdFieldDef token)
        {
            XCLRDataValue_GetFieldByToken2Result result;
            TryGetFieldByToken2(tokenScope, token, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetFieldByToken2(IXCLRDataModule tokenScope, mdFieldDef token, out XCLRDataValue_GetFieldByToken2Result result)
        {
            /*HRESULT GetFieldByToken2(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataModule tokenScope,
            [In] mdFieldDef token,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] nameBuf);*/
            IXCLRDataValue field;
            int bufLen = 0;
            int nameLen;
            char[] nameBuf;
            HRESULT hr = Raw.GetFieldByToken2(tokenScope, token, out field, bufLen, out nameLen, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new char[bufLen];
            hr = Raw.GetFieldByToken2(tokenScope, token, out field, bufLen, out nameLen, nameBuf);

            if (hr == HRESULT.S_OK)
            {
                result = new XCLRDataValue_GetFieldByToken2Result(field == null ? null : new XCLRDataValue(field), CreateString(nameBuf, nameLen));

                return hr;
            }

            fail:
            result = default(XCLRDataValue_GetFieldByToken2Result);

            return hr;
        }

        #endregion
        #region GetLocationByIndex

        public GetLocationByIndexResult GetLocationByIndex(int loc)
        {
            GetLocationByIndexResult result;
            TryGetLocationByIndex(loc, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetLocationByIndex(int loc, out GetLocationByIndexResult result)
        {
            /*HRESULT GetLocationByIndex(
            [In] int loc,
            [Out] out ClrDataValueLocationFlag flags,
            [Out] out CLRDATA_ADDRESS arg);*/
            ClrDataValueLocationFlag flags;
            CLRDATA_ADDRESS arg;
            HRESULT hr = Raw.GetLocationByIndex(loc, out flags, out arg);

            if (hr == HRESULT.S_OK)
                result = new GetLocationByIndexResult(flags, arg);
            else
                result = default(GetLocationByIndexResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
