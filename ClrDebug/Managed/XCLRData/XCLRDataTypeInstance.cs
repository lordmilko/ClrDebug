using System;
using static ClrDebug.Extensions;

namespace ClrDebug
{
    public class XCLRDataTypeInstance : ComObject<IXCLRDataTypeInstance>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataTypeInstance"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataTypeInstance(IXCLRDataTypeInstance raw) : base(raw)
        {
        }

        #region IXCLRDataTypeInstance
        #region NumStaticFields

        public int NumStaticFields
        {
            get
            {
                int numFields;
                TryGetNumStaticFields(out numFields).ThrowOnNotOK();

                return numFields;
            }
        }

        public HRESULT TryGetNumStaticFields(out int numFields)
        {
            /*HRESULT GetNumStaticFields(
            [Out] out int numFields);*/
            return Raw.GetNumStaticFields(out numFields);
        }

        #endregion
        #region NumTypeArguments

        public int NumTypeArguments
        {
            get
            {
                int numTypeArgs;
                TryGetNumTypeArguments(out numTypeArgs).ThrowOnNotOK();

                return numTypeArgs;
            }
        }

        public HRESULT TryGetNumTypeArguments(out int numTypeArgs)
        {
            /*HRESULT GetNumTypeArguments(
            [Out] out int numTypeArgs);*/
            return Raw.GetNumTypeArguments(out numTypeArgs);
        }

        #endregion
        #region Module

        public XCLRDataModule Module
        {
            get
            {
                XCLRDataModule modResult;
                TryGetModule(out modResult).ThrowOnNotOK();

                return modResult;
            }
        }

        public HRESULT TryGetModule(out XCLRDataModule modResult)
        {
            /*HRESULT GetModule(
            [Out] out IXCLRDataModule mod);*/
            IXCLRDataModule mod;
            HRESULT hr = Raw.GetModule(out mod);

            if (hr == HRESULT.S_OK)
                modResult = mod == null ? null : new XCLRDataModule(mod);
            else
                modResult = default(XCLRDataModule);

            return hr;
        }

        #endregion
        #region Definition

        public XCLRDataTypeDefinition Definition
        {
            get
            {
                XCLRDataTypeDefinition typeDefinitionResult;
                TryGetDefinition(out typeDefinitionResult).ThrowOnNotOK();

                return typeDefinitionResult;
            }
        }

        public HRESULT TryGetDefinition(out XCLRDataTypeDefinition typeDefinitionResult)
        {
            /*HRESULT GetDefinition(
            [Out] out IXCLRDataTypeDefinition typeDefinition);*/
            IXCLRDataTypeDefinition typeDefinition;
            HRESULT hr = Raw.GetDefinition(out typeDefinition);

            if (hr == HRESULT.S_OK)
                typeDefinitionResult = typeDefinition == null ? null : new XCLRDataTypeDefinition(typeDefinition);
            else
                typeDefinitionResult = default(XCLRDataTypeDefinition);

            return hr;
        }

        #endregion
        #region Flags

        public CLRDataTypeFlag Flags
        {
            get
            {
                CLRDataTypeFlag flags;
                TryGetFlags(out flags).ThrowOnNotOK();

                return flags;
            }
        }

        public HRESULT TryGetFlags(out CLRDataTypeFlag flags)
        {
            /*HRESULT GetFlags(
            [Out] out CLRDataTypeFlag flags);*/
            return Raw.GetFlags(out flags);
        }

        #endregion
        #region Base

        public XCLRDataTypeInstance Base
        {
            get
            {
                XCLRDataTypeInstance _baseResult;
                TryGetBase(out _baseResult).ThrowOnNotOK();

                return _baseResult;
            }
        }

        public HRESULT TryGetBase(out XCLRDataTypeInstance _baseResult)
        {
            /*HRESULT GetBase(
            [Out] out IXCLRDataTypeInstance _base);*/
            IXCLRDataTypeInstance _base;
            HRESULT hr = Raw.GetBase(out _base);

            if (hr == HRESULT.S_OK)
                _baseResult = _base == null ? null : new XCLRDataTypeInstance(_base);
            else
                _baseResult = default(XCLRDataTypeInstance);

            return hr;
        }

        #endregion
        #region StartEnumMethodInstances

        public IntPtr StartEnumMethodInstances()
        {
            IntPtr handle;
            TryStartEnumMethodInstances(out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumMethodInstances(out IntPtr handle)
        {
            /*HRESULT StartEnumMethodInstances(
            [Out] out IntPtr handle);*/
            return Raw.StartEnumMethodInstances(out handle);
        }

        #endregion
        #region EnumMethodInstance

        public XCLRDataMethodInstance EnumMethodInstance(ref IntPtr handle)
        {
            XCLRDataMethodInstance methodInstanceResult;
            TryEnumMethodInstance(ref handle, out methodInstanceResult).ThrowOnNotOK();

            return methodInstanceResult;
        }

        public HRESULT TryEnumMethodInstance(ref IntPtr handle, out XCLRDataMethodInstance methodInstanceResult)
        {
            /*HRESULT EnumMethodInstance(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodInstance methodInstance);*/
            IXCLRDataMethodInstance methodInstance;
            HRESULT hr = Raw.EnumMethodInstance(ref handle, out methodInstance);

            if (hr == HRESULT.S_OK)
                methodInstanceResult = methodInstance == null ? null : new XCLRDataMethodInstance(methodInstance);
            else
                methodInstanceResult = default(XCLRDataMethodInstance);

            return hr;
        }

        #endregion
        #region EndEnumMethodInstances

        public void EndEnumMethodInstances(IntPtr handle)
        {
            TryEndEnumMethodInstances(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumMethodInstances(IntPtr handle)
        {
            /*HRESULT EndEnumMethodInstances(
            [In] IntPtr handle);*/
            return Raw.EndEnumMethodInstances(handle);
        }

        #endregion
        #region StartEnumMethodInstancesByName

        public IntPtr StartEnumMethodInstancesByName(string name, CLRDataByNameFlag flags)
        {
            IntPtr handle;
            TryStartEnumMethodInstancesByName(name, flags, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumMethodInstancesByName(string name, CLRDataByNameFlag flags, out IntPtr handle)
        {
            /*HRESULT StartEnumMethodInstancesByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumMethodInstancesByName(name, flags, out handle);
        }

        #endregion
        #region EnumMethodInstanceByName

        public XCLRDataMethodInstance EnumMethodInstanceByName(ref IntPtr handle)
        {
            XCLRDataMethodInstance methodResult;
            TryEnumMethodInstanceByName(ref handle, out methodResult).ThrowOnNotOK();

            return methodResult;
        }

        public HRESULT TryEnumMethodInstanceByName(ref IntPtr handle, out XCLRDataMethodInstance methodResult)
        {
            /*HRESULT EnumMethodInstanceByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodInstance method);*/
            IXCLRDataMethodInstance method;
            HRESULT hr = Raw.EnumMethodInstanceByName(ref handle, out method);

            if (hr == HRESULT.S_OK)
                methodResult = method == null ? null : new XCLRDataMethodInstance(method);
            else
                methodResult = default(XCLRDataMethodInstance);

            return hr;
        }

        #endregion
        #region EndEnumMethodInstancesByName

        public void EndEnumMethodInstancesByName(IntPtr handle)
        {
            TryEndEnumMethodInstancesByName(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumMethodInstancesByName(IntPtr handle)
        {
            /*HRESULT EndEnumMethodInstancesByName(
            [In] IntPtr handle);*/
            return Raw.EndEnumMethodInstancesByName(handle);
        }

        #endregion
        #region GetStaticFieldByIndex

        public GetStaticFieldByIndexResult GetStaticFieldByIndex(int index, IXCLRDataTask tlsTask)
        {
            GetStaticFieldByIndexResult result;
            TryGetStaticFieldByIndex(index, tlsTask, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetStaticFieldByIndex(int index, IXCLRDataTask tlsTask, out GetStaticFieldByIndexResult result)
        {
            /*HRESULT GetStaticFieldByIndex(
            [In] int index,
            [In] IXCLRDataTask tlsTask,
            [Out] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] nameBuf,
            [Out] out mdFieldDef token);*/
            IXCLRDataValue field;
            int bufLen = 0;
            int nameLen;
            char[] nameBuf;
            mdFieldDef token;
            HRESULT hr = Raw.GetStaticFieldByIndex(index, tlsTask, out field, bufLen, out nameLen, null, out token);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new char[bufLen];
            hr = Raw.GetStaticFieldByIndex(index, tlsTask, out field, bufLen, out nameLen, nameBuf, out token);

            if (hr == HRESULT.S_OK)
            {
                result = new GetStaticFieldByIndexResult(field == null ? null : new XCLRDataValue(field), CreateString(nameBuf, nameLen), token);

                return hr;
            }

            fail:
            result = default(GetStaticFieldByIndexResult);

            return hr;
        }

        #endregion
        #region StartEnumStaticFieldsByName

        public IntPtr StartEnumStaticFieldsByName(string name, CLRDataByNameFlag flags, IXCLRDataTask tlsTask)
        {
            IntPtr handle;
            TryStartEnumStaticFieldsByName(name, flags, tlsTask, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumStaticFieldsByName(string name, CLRDataByNameFlag flags, IXCLRDataTask tlsTask, out IntPtr handle)
        {
            /*HRESULT StartEnumStaticFieldsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [In] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumStaticFieldsByName(name, flags, tlsTask, out handle);
        }

        #endregion
        #region EnumStaticFieldByName

        public XCLRDataValue EnumStaticFieldByName(ref IntPtr handle)
        {
            XCLRDataValue valueResult;
            TryEnumStaticFieldByName(ref handle, out valueResult).ThrowOnNotOK();

            return valueResult;
        }

        public HRESULT TryEnumStaticFieldByName(ref IntPtr handle, out XCLRDataValue valueResult)
        {
            /*HRESULT EnumStaticFieldByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value);*/
            IXCLRDataValue value;
            HRESULT hr = Raw.EnumStaticFieldByName(ref handle, out value);

            if (hr == HRESULT.S_OK)
                valueResult = value == null ? null : new XCLRDataValue(value);
            else
                valueResult = default(XCLRDataValue);

            return hr;
        }

        #endregion
        #region EndEnumStaticFieldsByName

        public void EndEnumStaticFieldsByName(IntPtr handle)
        {
            TryEndEnumStaticFieldsByName(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumStaticFieldsByName(IntPtr handle)
        {
            /*HRESULT EndEnumStaticFieldsByName(
            [In] IntPtr handle);*/
            return Raw.EndEnumStaticFieldsByName(handle);
        }

        #endregion
        #region GetTypeArgumentByIndex

        public XCLRDataTypeInstance GetTypeArgumentByIndex(int index)
        {
            XCLRDataTypeInstance typeArgResult;
            TryGetTypeArgumentByIndex(index, out typeArgResult).ThrowOnNotOK();

            return typeArgResult;
        }

        public HRESULT TryGetTypeArgumentByIndex(int index, out XCLRDataTypeInstance typeArgResult)
        {
            /*HRESULT GetTypeArgumentByIndex(
            [In] int index,
            [Out] out IXCLRDataTypeInstance typeArg);*/
            IXCLRDataTypeInstance typeArg;
            HRESULT hr = Raw.GetTypeArgumentByIndex(index, out typeArg);

            if (hr == HRESULT.S_OK)
                typeArgResult = typeArg == null ? null : new XCLRDataTypeInstance(typeArg);
            else
                typeArgResult = default(XCLRDataTypeInstance);

            return hr;
        }

        #endregion
        #region GetName

        public string GetName(int flags)
        {
            string nameBufResult;
            TryGetName(flags, out nameBufResult).ThrowOnNotOK();

            return nameBufResult;
        }

        public HRESULT TryGetName(int flags, out string nameBufResult)
        {
            /*HRESULT GetName(
            [In] int flags, //Unused; must be 0
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] nameBuf);*/
            int bufLen = 0;
            int nameLen;
            char[] nameBuf;
            HRESULT hr = Raw.GetName(flags, bufLen, out nameLen, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new char[bufLen];
            hr = Raw.GetName(flags, bufLen, out nameLen, nameBuf);

            if (hr == HRESULT.S_OK)
            {
                nameBufResult = CreateString(nameBuf, nameLen);

                return hr;
            }

            fail:
            nameBufResult = default(string);

            return hr;
        }

        #endregion
        #region IsSameObject

        public bool IsSameObject(IXCLRDataTypeInstance type)
        {
            HRESULT hr = TryIsSameObject(type);
            hr.ThrowOnFailed();

            return hr == HRESULT.S_OK;
        }

        public HRESULT TryIsSameObject(IXCLRDataTypeInstance type)
        {
            /*HRESULT IsSameObject(
            [In] IXCLRDataTypeInstance type);*/
            return Raw.IsSameObject(type);
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
        #region GetNumStaticFields2

        public int GetNumStaticFields2(CLRDataFieldFlag flags)
        {
            int numFields;
            TryGetNumStaticFields2(flags, out numFields).ThrowOnNotOK();

            return numFields;
        }

        public HRESULT TryGetNumStaticFields2(CLRDataFieldFlag flags, out int numFields)
        {
            /*HRESULT GetNumStaticFields2(
            [In] CLRDataFieldFlag flags,
            [Out] out int numFields);*/
            return Raw.GetNumStaticFields2(flags, out numFields);
        }

        #endregion
        #region StartEnumStaticFields

        public IntPtr StartEnumStaticFields(CLRDataFieldFlag flags, IXCLRDataTask tlsTask)
        {
            IntPtr handle;
            TryStartEnumStaticFields(flags, tlsTask, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumStaticFields(CLRDataFieldFlag flags, IXCLRDataTask tlsTask, out IntPtr handle)
        {
            /*HRESULT StartEnumStaticFields(
            [In] CLRDataFieldFlag flags,
            [In] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumStaticFields(flags, tlsTask, out handle);
        }

        #endregion
        #region EnumStaticField

        public XCLRDataValue EnumStaticField(ref IntPtr handle)
        {
            XCLRDataValue valueResult;
            TryEnumStaticField(ref handle, out valueResult).ThrowOnNotOK();

            return valueResult;
        }

        public HRESULT TryEnumStaticField(ref IntPtr handle, out XCLRDataValue valueResult)
        {
            /*HRESULT EnumStaticField(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value);*/
            IXCLRDataValue value;
            HRESULT hr = Raw.EnumStaticField(ref handle, out value);

            if (hr == HRESULT.S_OK)
                valueResult = value == null ? null : new XCLRDataValue(value);
            else
                valueResult = default(XCLRDataValue);

            return hr;
        }

        #endregion
        #region EndEnumStaticFields

        public void EndEnumStaticFields(IntPtr handle)
        {
            TryEndEnumStaticFields(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumStaticFields(IntPtr handle)
        {
            /*HRESULT EndEnumStaticFields(
            [In] IntPtr handle);*/
            return Raw.EndEnumStaticFields(handle);
        }

        #endregion
        #region StartEnumStaticFieldsByName2

        public IntPtr StartEnumStaticFieldsByName2(string name, CLRDataByNameFlag nameFlags, CLRDataFieldFlag fieldFlags, IXCLRDataTask tlsTask)
        {
            IntPtr handle;
            TryStartEnumStaticFieldsByName2(name, nameFlags, fieldFlags, tlsTask, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumStaticFieldsByName2(string name, CLRDataByNameFlag nameFlags, CLRDataFieldFlag fieldFlags, IXCLRDataTask tlsTask, out IntPtr handle)
        {
            /*HRESULT StartEnumStaticFieldsByName2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag nameFlags,
            [In] CLRDataFieldFlag fieldFlags,
            [In] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumStaticFieldsByName2(name, nameFlags, fieldFlags, tlsTask, out handle);
        }

        #endregion
        #region EnumStaticFieldByName2

        public XCLRDataValue EnumStaticFieldByName2(ref IntPtr handle)
        {
            XCLRDataValue valueResult;
            TryEnumStaticFieldByName2(ref handle, out valueResult).ThrowOnNotOK();

            return valueResult;
        }

        public HRESULT TryEnumStaticFieldByName2(ref IntPtr handle, out XCLRDataValue valueResult)
        {
            /*HRESULT EnumStaticFieldByName2(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value);*/
            IXCLRDataValue value;
            HRESULT hr = Raw.EnumStaticFieldByName2(ref handle, out value);

            if (hr == HRESULT.S_OK)
                valueResult = value == null ? null : new XCLRDataValue(value);
            else
                valueResult = default(XCLRDataValue);

            return hr;
        }

        #endregion
        #region EndEnumStaticFieldsByName2

        public void EndEnumStaticFieldsByName2(IntPtr handle)
        {
            TryEndEnumStaticFieldsByName2(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumStaticFieldsByName2(IntPtr handle)
        {
            /*HRESULT EndEnumStaticFieldsByName2(
            [In] IntPtr handle);*/
            return Raw.EndEnumStaticFieldsByName2(handle);
        }

        #endregion
        #region GetStaticFieldByToken

        public GetStaticFieldByTokenResult GetStaticFieldByToken(mdFieldDef token, IXCLRDataTask tlsTask)
        {
            GetStaticFieldByTokenResult result;
            TryGetStaticFieldByToken(token, tlsTask, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetStaticFieldByToken(mdFieldDef token, IXCLRDataTask tlsTask, out GetStaticFieldByTokenResult result)
        {
            /*HRESULT GetStaticFieldByToken(
            [In] mdFieldDef token,
            [In] IXCLRDataTask tlsTask,
            [Out] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] nameBuf);*/
            IXCLRDataValue field;
            int bufLen = 0;
            int nameLen;
            char[] nameBuf;
            HRESULT hr = Raw.GetStaticFieldByToken(token, tlsTask, out field, bufLen, out nameLen, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new char[bufLen];
            hr = Raw.GetStaticFieldByToken(token, tlsTask, out field, bufLen, out nameLen, nameBuf);

            if (hr == HRESULT.S_OK)
            {
                result = new GetStaticFieldByTokenResult(field == null ? null : new XCLRDataValue(field), CreateString(nameBuf, nameLen));

                return hr;
            }

            fail:
            result = default(GetStaticFieldByTokenResult);

            return hr;
        }

        #endregion
        #region EnumStaticField2

        public EnumStaticField2Result EnumStaticField2(ref IntPtr handle)
        {
            EnumStaticField2Result result;
            TryEnumStaticField2(ref handle, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryEnumStaticField2(ref IntPtr handle, out EnumStaticField2Result result)
        {
            /*HRESULT EnumStaticField2(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] nameBuf,
            [Out] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);*/
            IXCLRDataValue value;
            int bufLen = 0;
            int nameLen;
            char[] nameBuf;
            IXCLRDataModule tokenScope;
            mdFieldDef token;
            HRESULT hr = Raw.EnumStaticField2(ref handle, out value, bufLen, out nameLen, null, out tokenScope, out token);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new char[bufLen];
            hr = Raw.EnumStaticField2(ref handle, out value, bufLen, out nameLen, nameBuf, out tokenScope, out token);

            if (hr == HRESULT.S_OK)
            {
                result = new EnumStaticField2Result(value == null ? null : new XCLRDataValue(value), CreateString(nameBuf, nameLen), tokenScope == null ? null : new XCLRDataModule(tokenScope), token);

                return hr;
            }

            fail:
            result = default(EnumStaticField2Result);

            return hr;
        }

        #endregion
        #region EnumStaticFieldByName3

        public EnumStaticFieldByName3Result EnumStaticFieldByName3(ref IntPtr handle)
        {
            EnumStaticFieldByName3Result result;
            TryEnumStaticFieldByName3(ref handle, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryEnumStaticFieldByName3(ref IntPtr handle, out EnumStaticFieldByName3Result result)
        {
            /*HRESULT EnumStaticFieldByName3(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value,
            [Out] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);*/
            IXCLRDataValue value;
            IXCLRDataModule tokenScope;
            mdFieldDef token;
            HRESULT hr = Raw.EnumStaticFieldByName3(ref handle, out value, out tokenScope, out token);

            if (hr == HRESULT.S_OK)
                result = new EnumStaticFieldByName3Result(value == null ? null : new XCLRDataValue(value), tokenScope == null ? null : new XCLRDataModule(tokenScope), token);
            else
                result = default(EnumStaticFieldByName3Result);

            return hr;
        }

        #endregion
        #region GetStaticFieldByToken2

        public GetStaticFieldByToken2Result GetStaticFieldByToken2(IXCLRDataModule tokenScope, mdFieldDef token, IXCLRDataTask tlsTask)
        {
            GetStaticFieldByToken2Result result;
            TryGetStaticFieldByToken2(tokenScope, token, tlsTask, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetStaticFieldByToken2(IXCLRDataModule tokenScope, mdFieldDef token, IXCLRDataTask tlsTask, out GetStaticFieldByToken2Result result)
        {
            /*HRESULT GetStaticFieldByToken2(
            [In] IXCLRDataModule tokenScope,
            [In] mdFieldDef token,
            [In] IXCLRDataTask tlsTask,
            [Out] out IXCLRDataValue field,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] nameBuf);*/
            IXCLRDataValue field;
            int bufLen = 0;
            int nameLen;
            char[] nameBuf;
            HRESULT hr = Raw.GetStaticFieldByToken2(tokenScope, token, tlsTask, out field, bufLen, out nameLen, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new char[bufLen];
            hr = Raw.GetStaticFieldByToken2(tokenScope, token, tlsTask, out field, bufLen, out nameLen, nameBuf);

            if (hr == HRESULT.S_OK)
            {
                result = new GetStaticFieldByToken2Result(field == null ? null : new XCLRDataValue(field), CreateString(nameBuf, nameLen));

                return hr;
            }

            fail:
            result = default(GetStaticFieldByToken2Result);

            return hr;
        }

        #endregion
        #endregion
    }
}
