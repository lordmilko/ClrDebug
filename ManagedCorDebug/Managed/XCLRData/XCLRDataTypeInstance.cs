using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
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
                HRESULT hr;
                int numFields;

                if ((hr = TryGetNumStaticFields(out numFields)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
                HRESULT hr;
                int numTypeArgs;

                if ((hr = TryGetNumTypeArguments(out numTypeArgs)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
                HRESULT hr;
                XCLRDataModule modResult;

                if ((hr = TryGetModule(out modResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
                modResult = new XCLRDataModule(mod);
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
                HRESULT hr;
                XCLRDataTypeDefinition typeDefinitionResult;

                if ((hr = TryGetDefinition(out typeDefinitionResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
                typeDefinitionResult = new XCLRDataTypeDefinition(typeDefinition);
            else
                typeDefinitionResult = default(XCLRDataTypeDefinition);

            return hr;
        }

        #endregion
        #region Flags

        public int Flags
        {
            get
            {
                HRESULT hr;
                int flags;

                if ((hr = TryGetFlags(out flags)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return flags;
            }
        }

        public HRESULT TryGetFlags(out int flags)
        {
            /*HRESULT GetFlags(
            [Out] out int flags);*/
            return Raw.GetFlags(out flags);
        }

        #endregion
        #region Base

        public XCLRDataTypeInstance Base
        {
            get
            {
                HRESULT hr;
                XCLRDataTypeInstance _baseResult;

                if ((hr = TryGetBase(out _baseResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
                _baseResult = new XCLRDataTypeInstance(_base);
            else
                _baseResult = default(XCLRDataTypeInstance);

            return hr;
        }

        #endregion
        #region StartEnumMethodInstances

        public IntPtr StartEnumMethodInstances()
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumMethodInstances(out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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

        public EnumMethodInstanceResult EnumMethodInstance()
        {
            HRESULT hr;
            EnumMethodInstanceResult result;

            if ((hr = TryEnumMethodInstance(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumMethodInstance(out EnumMethodInstanceResult result)
        {
            /*HRESULT EnumMethodInstance(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodInstance methodInstance);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataMethodInstance methodInstance;
            HRESULT hr = Raw.EnumMethodInstance(ref handle, out methodInstance);

            if (hr == HRESULT.S_OK)
                result = new EnumMethodInstanceResult(handle, new XCLRDataMethodInstance(methodInstance));
            else
                result = default(EnumMethodInstanceResult);

            return hr;
        }

        #endregion
        #region EndEnumMethodInstances

        public void EndEnumMethodInstances(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumMethodInstances(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumMethodInstances(IntPtr handle)
        {
            /*HRESULT EndEnumMethodInstances(
            [In] IntPtr handle);*/
            return Raw.EndEnumMethodInstances(handle);
        }

        #endregion
        #region StartEnumMethodInstancesByName

        public IntPtr StartEnumMethodInstancesByName(string name, int flags)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumMethodInstancesByName(name, flags, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumMethodInstancesByName(string name, int flags, out IntPtr handle)
        {
            /*HRESULT StartEnumMethodInstancesByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int flags,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumMethodInstancesByName(name, flags, out handle);
        }

        #endregion
        #region EnumMethodInstanceByName

        public EnumMethodInstanceByNameResult EnumMethodInstanceByName()
        {
            HRESULT hr;
            EnumMethodInstanceByNameResult result;

            if ((hr = TryEnumMethodInstanceByName(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumMethodInstanceByName(out EnumMethodInstanceByNameResult result)
        {
            /*HRESULT EnumMethodInstanceByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodInstance method);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataMethodInstance method;
            HRESULT hr = Raw.EnumMethodInstanceByName(ref handle, out method);

            if (hr == HRESULT.S_OK)
                result = new EnumMethodInstanceByNameResult(handle, new XCLRDataMethodInstance(method));
            else
                result = default(EnumMethodInstanceByNameResult);

            return hr;
        }

        #endregion
        #region EndEnumMethodInstancesByName

        public void EndEnumMethodInstancesByName(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumMethodInstancesByName(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;
            GetStaticFieldByIndexResult result;

            if ((hr = TryGetStaticFieldByIndex(index, tlsTask, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out mdFieldDef token);*/
            IXCLRDataValue field;
            int bufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            mdFieldDef token;
            HRESULT hr = Raw.GetStaticFieldByIndex(index, tlsTask, out field, bufLen, out nameLen, nameBuf, out token);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.GetStaticFieldByIndex(index, tlsTask, out field, bufLen, out nameLen, nameBuf, out token);

            if (hr == HRESULT.S_OK)
            {
                result = new GetStaticFieldByIndexResult(new XCLRDataValue(field), nameBuf.ToString(), token);

                return hr;
            }

            fail:
            result = default(GetStaticFieldByIndexResult);

            return hr;
        }

        #endregion
        #region StartEnumStaticFieldsByName

        public IntPtr StartEnumStaticFieldsByName(string name, int flags, IXCLRDataTask tlsTask)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumStaticFieldsByName(name, flags, tlsTask, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumStaticFieldsByName(string name, int flags, IXCLRDataTask tlsTask, out IntPtr handle)
        {
            /*HRESULT StartEnumStaticFieldsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int flags,
            [In] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumStaticFieldsByName(name, flags, tlsTask, out handle);
        }

        #endregion
        #region EnumStaticFieldByName

        public EnumStaticFieldByNameResult EnumStaticFieldByName()
        {
            HRESULT hr;
            EnumStaticFieldByNameResult result;

            if ((hr = TryEnumStaticFieldByName(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumStaticFieldByName(out EnumStaticFieldByNameResult result)
        {
            /*HRESULT EnumStaticFieldByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataValue value;
            HRESULT hr = Raw.EnumStaticFieldByName(ref handle, out value);

            if (hr == HRESULT.S_OK)
                result = new EnumStaticFieldByNameResult(handle, new XCLRDataValue(value));
            else
                result = default(EnumStaticFieldByNameResult);

            return hr;
        }

        #endregion
        #region EndEnumStaticFieldsByName

        public void EndEnumStaticFieldsByName(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumStaticFieldsByName(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;
            XCLRDataTypeInstance typeArgResult;

            if ((hr = TryGetTypeArgumentByIndex(index, out typeArgResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
                typeArgResult = new XCLRDataTypeInstance(typeArg);
            else
                typeArgResult = default(XCLRDataTypeInstance);

            return hr;
        }

        #endregion
        #region GetName

        public string GetName(int flags)
        {
            HRESULT hr;
            string nameBufResult;

            if ((hr = TryGetName(flags, out nameBufResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return nameBufResult;
        }

        public HRESULT TryGetName(int flags, out string nameBufResult)
        {
            /*HRESULT GetName(
            [In] int flags,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);*/
            int bufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            HRESULT hr = Raw.GetName(flags, bufLen, out nameLen, nameBuf);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.GetName(flags, bufLen, out nameLen, nameBuf);

            if (hr == HRESULT.S_OK)
            {
                nameBufResult = nameBuf.ToString();

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
            HRESULT hr;

            if ((hr = TryIsSameObject(type)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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

        public IntPtr Request(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize)
        {
            HRESULT hr;
            IntPtr outBuffer = default(IntPtr);

            if ((hr = TryRequest(reqCode, inBufferSize, inBuffer, outBufferSize, ref outBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return outBuffer;
        }

        public HRESULT TryRequest(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize, ref IntPtr outBuffer)
        {
            /*HRESULT Request(
            [In] uint reqCode,
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [In, Out] ref IntPtr outBuffer);*/
            return Raw.Request(reqCode, inBufferSize, inBuffer, outBufferSize, ref outBuffer);
        }

        #endregion
        #region GetNumStaticFields2

        public int GetNumStaticFields2(int flags)
        {
            HRESULT hr;
            int numFields;

            if ((hr = TryGetNumStaticFields2(flags, out numFields)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return numFields;
        }

        public HRESULT TryGetNumStaticFields2(int flags, out int numFields)
        {
            /*HRESULT GetNumStaticFields2(
            [In] int flags,
            [Out] out int numFields);*/
            return Raw.GetNumStaticFields2(flags, out numFields);
        }

        #endregion
        #region StartEnumStaticFields

        public IntPtr StartEnumStaticFields(int flags, IXCLRDataTask tlsTask)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumStaticFields(flags, tlsTask, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumStaticFields(int flags, IXCLRDataTask tlsTask, out IntPtr handle)
        {
            /*HRESULT StartEnumStaticFields(
            [In] int flags,
            [In] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumStaticFields(flags, tlsTask, out handle);
        }

        #endregion
        #region EnumStaticField

        public EnumStaticFieldResult EnumStaticField()
        {
            HRESULT hr;
            EnumStaticFieldResult result;

            if ((hr = TryEnumStaticField(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumStaticField(out EnumStaticFieldResult result)
        {
            /*HRESULT EnumStaticField(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataValue value;
            HRESULT hr = Raw.EnumStaticField(ref handle, out value);

            if (hr == HRESULT.S_OK)
                result = new EnumStaticFieldResult(handle, new XCLRDataValue(value));
            else
                result = default(EnumStaticFieldResult);

            return hr;
        }

        #endregion
        #region EndEnumStaticFields

        public void EndEnumStaticFields(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumStaticFields(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumStaticFields(IntPtr handle)
        {
            /*HRESULT EndEnumStaticFields(
            [In] IntPtr handle);*/
            return Raw.EndEnumStaticFields(handle);
        }

        #endregion
        #region StartEnumStaticFieldsByName2

        public IntPtr StartEnumStaticFieldsByName2(string name, int nameFlags, int fieldFlags, IXCLRDataTask tlsTask)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumStaticFieldsByName2(name, nameFlags, fieldFlags, tlsTask, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumStaticFieldsByName2(string name, int nameFlags, int fieldFlags, IXCLRDataTask tlsTask, out IntPtr handle)
        {
            /*HRESULT StartEnumStaticFieldsByName2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int nameFlags,
            [In] int fieldFlags,
            [In] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumStaticFieldsByName2(name, nameFlags, fieldFlags, tlsTask, out handle);
        }

        #endregion
        #region EnumStaticFieldByName2

        public EnumStaticFieldByName2Result EnumStaticFieldByName2()
        {
            HRESULT hr;
            EnumStaticFieldByName2Result result;

            if ((hr = TryEnumStaticFieldByName2(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumStaticFieldByName2(out EnumStaticFieldByName2Result result)
        {
            /*HRESULT EnumStaticFieldByName2(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataValue value;
            HRESULT hr = Raw.EnumStaticFieldByName2(ref handle, out value);

            if (hr == HRESULT.S_OK)
                result = new EnumStaticFieldByName2Result(handle, new XCLRDataValue(value));
            else
                result = default(EnumStaticFieldByName2Result);

            return hr;
        }

        #endregion
        #region EndEnumStaticFieldsByName2

        public void EndEnumStaticFieldsByName2(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumStaticFieldsByName2(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;
            GetStaticFieldByTokenResult result;

            if ((hr = TryGetStaticFieldByToken(token, tlsTask, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);*/
            IXCLRDataValue field;
            int bufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            HRESULT hr = Raw.GetStaticFieldByToken(token, tlsTask, out field, bufLen, out nameLen, nameBuf);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.GetStaticFieldByToken(token, tlsTask, out field, bufLen, out nameLen, nameBuf);

            if (hr == HRESULT.S_OK)
            {
                result = new GetStaticFieldByTokenResult(new XCLRDataValue(field), nameBuf.ToString());

                return hr;
            }

            fail:
            result = default(GetStaticFieldByTokenResult);

            return hr;
        }

        #endregion
        #region EnumStaticField2

        public EnumStaticField2Result EnumStaticField2()
        {
            HRESULT hr;
            EnumStaticField2Result result;

            if ((hr = TryEnumStaticField2(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumStaticField2(out EnumStaticField2Result result)
        {
            /*HRESULT EnumStaticField2(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataValue value;
            int bufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            IXCLRDataModule tokenScope;
            mdFieldDef token;
            HRESULT hr = Raw.EnumStaticField2(ref handle, out value, bufLen, out nameLen, nameBuf, out tokenScope, out token);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.EnumStaticField2(ref handle, out value, bufLen, out nameLen, nameBuf, out tokenScope, out token);

            if (hr == HRESULT.S_OK)
            {
                result = new EnumStaticField2Result(handle, new XCLRDataValue(value), nameBuf.ToString(), new XCLRDataModule(tokenScope), token);

                return hr;
            }

            fail:
            result = default(EnumStaticField2Result);

            return hr;
        }

        #endregion
        #region EnumStaticFieldByName3

        public EnumStaticFieldByName3Result EnumStaticFieldByName3()
        {
            HRESULT hr;
            EnumStaticFieldByName3Result result;

            if ((hr = TryEnumStaticFieldByName3(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumStaticFieldByName3(out EnumStaticFieldByName3Result result)
        {
            /*HRESULT EnumStaticFieldByName3(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value,
            [Out] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataValue value;
            IXCLRDataModule tokenScope;
            mdFieldDef token;
            HRESULT hr = Raw.EnumStaticFieldByName3(ref handle, out value, out tokenScope, out token);

            if (hr == HRESULT.S_OK)
                result = new EnumStaticFieldByName3Result(handle, new XCLRDataValue(value), new XCLRDataModule(tokenScope), token);
            else
                result = default(EnumStaticFieldByName3Result);

            return hr;
        }

        #endregion
        #region GetStaticFieldByToken2

        public GetStaticFieldByToken2Result GetStaticFieldByToken2(IXCLRDataModule tokenScope, mdFieldDef token, IXCLRDataTask tlsTask)
        {
            HRESULT hr;
            GetStaticFieldByToken2Result result;

            if ((hr = TryGetStaticFieldByToken2(tokenScope, token, tlsTask, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);*/
            IXCLRDataValue field;
            int bufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            HRESULT hr = Raw.GetStaticFieldByToken2(tokenScope, token, tlsTask, out field, bufLen, out nameLen, nameBuf);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.GetStaticFieldByToken2(tokenScope, token, tlsTask, out field, bufLen, out nameLen, nameBuf);

            if (hr == HRESULT.S_OK)
            {
                result = new GetStaticFieldByToken2Result(new XCLRDataValue(field), nameBuf.ToString());

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