using System;
using System.Text;

namespace ManagedCorDebug
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
            [Out] out IXCLRDataTypeInstance typeInstance);*/
            IXCLRDataTypeInstance typeInstance;
            HRESULT hr = Raw.GetType(out typeInstance);

            if (hr == HRESULT.S_OK)
                typeInstanceResult = new XCLRDataTypeInstance(typeInstance);
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
            [Out] out IXCLRDataValue assocValue);*/
            IXCLRDataValue assocValue;
            HRESULT hr = Raw.GetAssociatedValue(out assocValue);

            if (hr == HRESULT.S_OK)
                assocValueResult = new XCLRDataValue(assocValue);
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
            [Out] out IXCLRDataTypeInstance assocType);*/
            IXCLRDataTypeInstance assocType;
            HRESULT hr = Raw.GetAssociatedType(out assocType);

            if (hr == HRESULT.S_OK)
                assocTypeResult = new XCLRDataTypeInstance(assocType);
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
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder str);*/
            int bufLen = 0;
            int strLen;
            StringBuilder str = null;
            HRESULT hr = Raw.GetString(bufLen, out strLen, str);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = strLen;
            str = new StringBuilder(strLen);
            hr = Raw.GetString(bufLen, out strLen, str);

            if (hr == HRESULT.S_OK)
            {
                strResult = str.ToString();

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
            [Out] out IntPtr buffer);*/
            int dataSize;
            IntPtr buffer;
            HRESULT hr = Raw.GetBytes(bufLen, out dataSize, out buffer);

            if (hr == HRESULT.S_OK)
                result = new GetBytesResult(dataSize, buffer);
            else
                result = default(GetBytesResult);

            return hr;
        }

        #endregion
        #region SetBytes

        public int SetBytes(int bufLen, IntPtr buffer)
        {
            int dataSize;
            TrySetBytes(bufLen, out dataSize, buffer).ThrowOnNotOK();

            return dataSize;
        }

        public HRESULT TrySetBytes(int bufLen, out int dataSize, IntPtr buffer)
        {
            /*HRESULT SetBytes(
            [In] int bufLen,
            [Out] out int dataSize,
            [In] IntPtr buffer);*/
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
            [Out] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out mdFieldDef token);*/
            IXCLRDataValue field;
            int bufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            mdFieldDef token;
            HRESULT hr = Raw.GetFieldByIndex(index, out field, bufLen, out nameLen, nameBuf, out token);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.GetFieldByIndex(index, out field, bufLen, out nameLen, nameBuf, out token);

            if (hr == HRESULT.S_OK)
            {
                result = new GetFieldByIndexResult(new XCLRDataValue(field), nameBuf.ToString(), token);

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
            [In] uint reqCode,
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);*/
            return Raw.Request(reqCode, inBufferSize, inBuffer, outBufferSize, outBuffer);
        }

        #endregion
        #region GetNumFields2

        public int GetNumFields2(int flags, IXCLRDataTypeInstance fromType)
        {
            int numFields;
            TryGetNumFields2(flags, fromType, out numFields).ThrowOnNotOK();

            return numFields;
        }

        public HRESULT TryGetNumFields2(int flags, IXCLRDataTypeInstance fromType, out int numFields)
        {
            /*HRESULT GetNumFields2(
            [In] int flags,
            [In] IXCLRDataTypeInstance fromType,
            [Out] out int numFields);*/
            return Raw.GetNumFields2(flags, fromType, out numFields);
        }

        #endregion
        #region StartEnumFields

        public IntPtr StartEnumFields(int flags, IXCLRDataTypeInstance fromType)
        {
            IntPtr handle;
            TryStartEnumFields(flags, fromType, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumFields(int flags, IXCLRDataTypeInstance fromType, out IntPtr handle)
        {
            /*HRESULT StartEnumFields(
            [In] int flags,
            [In] IXCLRDataTypeInstance fromType,
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
            [Out] out IXCLRDataValue field,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out mdFieldDef token);*/
            IXCLRDataValue field;
            int nameBufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            mdFieldDef token;
            HRESULT hr = Raw.EnumField(ref handle, out field, nameBufLen, out nameLen, nameBuf, out token);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.EnumField(ref handle, out field, nameBufLen, out nameLen, nameBuf, out token);

            if (hr == HRESULT.S_OK)
            {
                result = new XCLRDataValue_EnumFieldResult(new XCLRDataValue(field), nameBuf.ToString(), token);

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

        public IntPtr StartEnumFieldsByName(string name, int nameFlags, int fieldFlags, IXCLRDataTypeInstance fromType)
        {
            IntPtr handle;
            TryStartEnumFieldsByName(name, nameFlags, fieldFlags, fromType, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumFieldsByName(string name, int nameFlags, int fieldFlags, IXCLRDataTypeInstance fromType, out IntPtr handle)
        {
            /*HRESULT StartEnumFieldsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int nameFlags,
            [In] int fieldFlags,
            [In] IXCLRDataTypeInstance fromType,
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
            [Out] out IXCLRDataValue field,
            [Out] out mdFieldDef token);*/
            IXCLRDataValue field;
            mdFieldDef token;
            HRESULT hr = Raw.EnumFieldByName(ref handle, out field, out token);

            if (hr == HRESULT.S_OK)
                result = new XCLRDataValue_EnumFieldByNameResult(new XCLRDataValue(field), token);
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
            [Out] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);*/
            IXCLRDataValue field;
            int bufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            HRESULT hr = Raw.GetFieldByToken(token, out field, bufLen, out nameLen, nameBuf);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.GetFieldByToken(token, out field, bufLen, out nameLen, nameBuf);

            if (hr == HRESULT.S_OK)
            {
                result = new XCLRDataValue_GetFieldByTokenResult(new XCLRDataValue(field), nameBuf.ToString());

                return hr;
            }

            fail:
            result = default(XCLRDataValue_GetFieldByTokenResult);

            return hr;
        }

        #endregion
        #region GetArrayProperties

        public GetArrayPropertiesResult GetArrayProperties(int numDim)
        {
            GetArrayPropertiesResult result;
            TryGetArrayProperties(numDim, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetArrayProperties(int numDim, out GetArrayPropertiesResult result)
        {
            /*HRESULT GetArrayProperties(
            [Out, MarshalAs(UnmanagedType.LPArray)] int[] rank,
            [Out] out int totalElements,
            [In] int numDim,
            [Out, MarshalAs(UnmanagedType.LPArray)] int[] dims,
            [In] int numBases,
            [Out, MarshalAs(UnmanagedType.LPArray)] int[] bases);*/
            int[] rank = null;
            int totalElements;
            int[] dims = null;
            int numBases = 0;
            int[] bases = null;
            HRESULT hr = Raw.GetArrayProperties(rank, out totalElements, numDim, dims, numBases, bases);

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
            [In, MarshalAs(UnmanagedType.LPArray)] int[] indices,
            [Out] out IXCLRDataValue value);*/
            IXCLRDataValue value;
            HRESULT hr = Raw.GetArrayElement(numInd, indices, out value);

            if (hr == HRESULT.S_OK)
                valueResult = new XCLRDataValue(value);
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
            [Out] out IXCLRDataValue field,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);*/
            IXCLRDataValue field;
            int nameBufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            IXCLRDataModule tokenScope;
            mdFieldDef token;
            HRESULT hr = Raw.EnumField2(ref handle, out field, nameBufLen, out nameLen, nameBuf, out tokenScope, out token);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.EnumField2(ref handle, out field, nameBufLen, out nameLen, nameBuf, out tokenScope, out token);

            if (hr == HRESULT.S_OK)
            {
                result = new XCLRDataValue_EnumField2Result(new XCLRDataValue(field), nameBuf.ToString(), new XCLRDataModule(tokenScope), token);

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
            [Out] out IXCLRDataValue field,
            [Out] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);*/
            IXCLRDataValue field;
            IXCLRDataModule tokenScope;
            mdFieldDef token;
            HRESULT hr = Raw.EnumFieldByName2(ref handle, out field, out tokenScope, out token);

            if (hr == HRESULT.S_OK)
                result = new XCLRDataValue_EnumFieldByName2Result(new XCLRDataValue(field), new XCLRDataModule(tokenScope), token);
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
            [In] IXCLRDataModule tokenScope,
            [In] mdFieldDef token,
            [Out] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);*/
            IXCLRDataValue field;
            int bufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            HRESULT hr = Raw.GetFieldByToken2(tokenScope, token, out field, bufLen, out nameLen, nameBuf);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.GetFieldByToken2(tokenScope, token, out field, bufLen, out nameLen, nameBuf);

            if (hr == HRESULT.S_OK)
            {
                result = new XCLRDataValue_GetFieldByToken2Result(new XCLRDataValue(field), nameBuf.ToString());

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
            [Out] out int flags,
            [Out] out CLRDATA_ADDRESS arg);*/
            int flags;
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