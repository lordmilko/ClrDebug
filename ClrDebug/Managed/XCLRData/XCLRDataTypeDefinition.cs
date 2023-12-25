using System;
using static ClrDebug.Extensions;

namespace ClrDebug
{
    public class XCLRDataTypeDefinition : ComObject<IXCLRDataTypeDefinition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataTypeDefinition"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataTypeDefinition(IXCLRDataTypeDefinition raw) : base(raw)
        {
        }

        #region IXCLRDataTypeDefinition
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
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule mod);*/
            IXCLRDataModule mod;
            HRESULT hr = Raw.GetModule(out mod);

            if (hr == HRESULT.S_OK)
                modResult = mod == null ? null : new XCLRDataModule(mod);
            else
                modResult = default(XCLRDataModule);

            return hr;
        }

        #endregion
        #region TokenAndScope

        public XCLRDataTypeDefinition_GetTokenAndScopeResult TokenAndScope
        {
            get
            {
                XCLRDataTypeDefinition_GetTokenAndScopeResult result;
                TryGetTokenAndScope(out result).ThrowOnNotOK();

                return result;
            }
        }

        public HRESULT TryGetTokenAndScope(out XCLRDataTypeDefinition_GetTokenAndScopeResult result)
        {
            /*HRESULT GetTokenAndScope(
            [Out] out mdTypeDef token,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule mod);*/
            mdTypeDef token;
            IXCLRDataModule mod;
            HRESULT hr = Raw.GetTokenAndScope(out token, out mod);

            if (hr == HRESULT.S_OK)
                result = new XCLRDataTypeDefinition_GetTokenAndScopeResult(token, mod == null ? null : new XCLRDataModule(mod));
            else
                result = default(XCLRDataTypeDefinition_GetTokenAndScopeResult);

            return hr;
        }

        #endregion
        #region CorElementType

        public CorElementType CorElementType
        {
            get
            {
                CorElementType type;
                TryGetCorElementType(out type).ThrowOnNotOK();

                return type;
            }
        }

        public HRESULT TryGetCorElementType(out CorElementType type)
        {
            /*HRESULT GetCorElementType(
            [Out] out CorElementType type);*/
            return Raw.GetCorElementType(out type);
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
        #region ArrayRank

        public int ArrayRank
        {
            get
            {
                int rank;
                TryGetArrayRank(out rank).ThrowOnNotOK();

                return rank;
            }
        }

        public HRESULT TryGetArrayRank(out int rank)
        {
            /*HRESULT GetArrayRank(
            [Out] out int rank);*/
            return Raw.GetArrayRank(out rank);
        }

        #endregion
        #region Base

        public XCLRDataTypeDefinition Base
        {
            get
            {
                XCLRDataTypeDefinition _baseResult;
                TryGetBase(out _baseResult).ThrowOnNotOK();

                return _baseResult;
            }
        }

        public HRESULT TryGetBase(out XCLRDataTypeDefinition _baseResult)
        {
            /*HRESULT GetBase(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition _base);*/
            IXCLRDataTypeDefinition _base;
            HRESULT hr = Raw.GetBase(out _base);

            if (hr == HRESULT.S_OK)
                _baseResult = _base == null ? null : new XCLRDataTypeDefinition(_base);
            else
                _baseResult = default(XCLRDataTypeDefinition);

            return hr;
        }

        #endregion
        #region TypeNotification

        public int TypeNotification
        {
            get
            {
                int flags;
                TryGetTypeNotification(out flags).ThrowOnNotOK();

                return flags;
            }
            set
            {
                TrySetTypeNotification(value).ThrowOnNotOK();
            }
        }

        public HRESULT TryGetTypeNotification(out int flags)
        {
            /*HRESULT GetTypeNotification(
            [Out] out int flags);*/
            return Raw.GetTypeNotification(out flags);
        }

        public HRESULT TrySetTypeNotification(int flags)
        {
            /*HRESULT SetTypeNotification(
            [In] int flags);*/
            return Raw.SetTypeNotification(flags);
        }

        #endregion
        #region StartEnumMethodDefinitions

        public IntPtr StartEnumMethodDefinitions()
        {
            IntPtr handle;
            TryStartEnumMethodDefinitions(out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumMethodDefinitions(out IntPtr handle)
        {
            /*HRESULT StartEnumMethodDefinitions(
            [Out] out IntPtr handle);*/
            return Raw.StartEnumMethodDefinitions(out handle);
        }

        #endregion
        #region EnumMethodDefinition

        public XCLRDataMethodDefinition EnumMethodDefinition(ref IntPtr handle)
        {
            XCLRDataMethodDefinition methodDefinitionResult;
            TryEnumMethodDefinition(ref handle, out methodDefinitionResult).ThrowOnNotOK();

            return methodDefinitionResult;
        }

        public HRESULT TryEnumMethodDefinition(ref IntPtr handle, out XCLRDataMethodDefinition methodDefinitionResult)
        {
            /*HRESULT EnumMethodDefinition(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataMethodDefinition methodDefinition);*/
            IXCLRDataMethodDefinition methodDefinition;
            HRESULT hr = Raw.EnumMethodDefinition(ref handle, out methodDefinition);

            if (hr == HRESULT.S_OK)
                methodDefinitionResult = methodDefinition == null ? null : new XCLRDataMethodDefinition(methodDefinition);
            else
                methodDefinitionResult = default(XCLRDataMethodDefinition);

            return hr;
        }

        #endregion
        #region EndEnumMethodDefinitions

        public void EndEnumMethodDefinitions(IntPtr handle)
        {
            TryEndEnumMethodDefinitions(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumMethodDefinitions(IntPtr handle)
        {
            /*HRESULT EndEnumMethodDefinitions(
            [In] IntPtr handle);*/
            return Raw.EndEnumMethodDefinitions(handle);
        }

        #endregion
        #region StartEnumMethodDefinitionsByName

        public IntPtr StartEnumMethodDefinitionsByName(string name, CLRDataByNameFlag flags)
        {
            IntPtr handle;
            TryStartEnumMethodDefinitionsByName(name, flags, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumMethodDefinitionsByName(string name, CLRDataByNameFlag flags, out IntPtr handle)
        {
            /*HRESULT StartEnumMethodDefinitionsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumMethodDefinitionsByName(name, flags, out handle);
        }

        #endregion
        #region EnumMethodDefinitionByName

        public XCLRDataMethodDefinition EnumMethodDefinitionByName(ref IntPtr handle)
        {
            XCLRDataMethodDefinition methodResult;
            TryEnumMethodDefinitionByName(ref handle, out methodResult).ThrowOnNotOK();

            return methodResult;
        }

        public HRESULT TryEnumMethodDefinitionByName(ref IntPtr handle, out XCLRDataMethodDefinition methodResult)
        {
            /*HRESULT EnumMethodDefinitionByName(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataMethodDefinition method);*/
            IXCLRDataMethodDefinition method;
            HRESULT hr = Raw.EnumMethodDefinitionByName(ref handle, out method);

            if (hr == HRESULT.S_OK)
                methodResult = method == null ? null : new XCLRDataMethodDefinition(method);
            else
                methodResult = default(XCLRDataMethodDefinition);

            return hr;
        }

        #endregion
        #region EndEnumMethodDefinitionsByName

        public void EndEnumMethodDefinitionsByName(IntPtr handle)
        {
            TryEndEnumMethodDefinitionsByName(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumMethodDefinitionsByName(IntPtr handle)
        {
            /*HRESULT EndEnumMethodDefinitionsByName(
            [In] IntPtr handle);*/
            return Raw.EndEnumMethodDefinitionsByName(handle);
        }

        #endregion
        #region GetMethodDefinitionByToken

        public XCLRDataMethodDefinition GetMethodDefinitionByToken(mdMethodDef token)
        {
            XCLRDataMethodDefinition methodDefinitionResult;
            TryGetMethodDefinitionByToken(token, out methodDefinitionResult).ThrowOnNotOK();

            return methodDefinitionResult;
        }

        public HRESULT TryGetMethodDefinitionByToken(mdMethodDef token, out XCLRDataMethodDefinition methodDefinitionResult)
        {
            /*HRESULT GetMethodDefinitionByToken(
            [In] mdMethodDef token,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataMethodDefinition methodDefinition);*/
            IXCLRDataMethodDefinition methodDefinition;
            HRESULT hr = Raw.GetMethodDefinitionByToken(token, out methodDefinition);

            if (hr == HRESULT.S_OK)
                methodDefinitionResult = methodDefinition == null ? null : new XCLRDataMethodDefinition(methodDefinition);
            else
                methodDefinitionResult = default(XCLRDataMethodDefinition);

            return hr;
        }

        #endregion
        #region StartEnumInstances

        public IntPtr StartEnumInstances(IXCLRDataAppDomain appDomain)
        {
            IntPtr handle;
            TryStartEnumInstances(appDomain, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumInstances(IXCLRDataAppDomain appDomain, out IntPtr handle)
        {
            /*HRESULT StartEnumInstances(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumInstances(appDomain, out handle);
        }

        #endregion
        #region EnumInstance

        public XCLRDataTypeInstance EnumInstance(ref IntPtr handle)
        {
            XCLRDataTypeInstance instanceResult;
            TryEnumInstance(ref handle, out instanceResult).ThrowOnNotOK();

            return instanceResult;
        }

        public HRESULT TryEnumInstance(ref IntPtr handle, out XCLRDataTypeInstance instanceResult)
        {
            /*HRESULT EnumInstance(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeInstance instance);*/
            IXCLRDataTypeInstance instance;
            HRESULT hr = Raw.EnumInstance(ref handle, out instance);

            if (hr == HRESULT.S_OK)
                instanceResult = instance == null ? null : new XCLRDataTypeInstance(instance);
            else
                instanceResult = default(XCLRDataTypeInstance);

            return hr;
        }

        #endregion
        #region EndEnumInstances

        public void EndEnumInstances(IntPtr handle)
        {
            TryEndEnumInstances(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumInstances(IntPtr handle)
        {
            /*HRESULT EndEnumInstances(
            [In] IntPtr handle);*/
            return Raw.EndEnumInstances(handle);
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
            [In] int flags, //Unused, always 0
            [In] int bufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] nameBuf);*/
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

        public bool IsSameObject(IXCLRDataTypeDefinition type)
        {
            HRESULT hr = TryIsSameObject(type);
            hr.ThrowOnFailed();

            return hr == HRESULT.S_OK;
        }

        public HRESULT TryIsSameObject(IXCLRDataTypeDefinition type)
        {
            /*HRESULT IsSameObject(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTypeDefinition type);*/
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
        #region GetNumFields

        public int GetNumFields(CLRDataFieldFlag flags)
        {
            int numFields;
            TryGetNumFields(flags, out numFields).ThrowOnNotOK();

            return numFields;
        }

        public HRESULT TryGetNumFields(CLRDataFieldFlag flags, out int numFields)
        {
            /*HRESULT GetNumFields(
            [In] CLRDataFieldFlag flags,
            [Out] out int numFields);*/
            return Raw.GetNumFields(flags, out numFields);
        }

        #endregion
        #region StartEnumFields

        public IntPtr StartEnumFields(CLRDataFieldFlag flags)
        {
            IntPtr handle;
            TryStartEnumFields(flags, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumFields(CLRDataFieldFlag flags, out IntPtr handle)
        {
            /*HRESULT StartEnumFields(
            [In] CLRDataFieldFlag flags,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumFields(flags, out handle);
        }

        #endregion
        #region EnumField

        public EnumFieldResult EnumField(ref IntPtr handle)
        {
            EnumFieldResult result;
            TryEnumField(ref handle, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryEnumField(ref IntPtr handle, out EnumFieldResult result)
        {
            /*HRESULT EnumField(
            [In, Out] ref IntPtr handle,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] nameBuf,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition type,
            [Out] out CLRDataFieldFlag flags,
            [Out] out mdFieldDef token);*/
            int nameBufLen = 0;
            int nameLen;
            char[] nameBuf;
            IXCLRDataTypeDefinition type;
            CLRDataFieldFlag flags;
            mdFieldDef token;
            HRESULT hr = Raw.EnumField(ref handle, nameBufLen, out nameLen, null, out type, out flags, out token);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufLen = nameLen;
            nameBuf = new char[nameBufLen];
            hr = Raw.EnumField(ref handle, nameBufLen, out nameLen, nameBuf, out type, out flags, out token);

            if (hr == HRESULT.S_OK)
            {
                result = new EnumFieldResult(CreateString(nameBuf, nameLen), type == null ? null : new XCLRDataTypeDefinition(type), flags, token);

                return hr;
            }

            fail:
            result = default(EnumFieldResult);

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

        public IntPtr StartEnumFieldsByName(string name, CLRDataByNameFlag nameFlags, CLRDataFieldFlag fieldFlags)
        {
            IntPtr handle;
            TryStartEnumFieldsByName(name, nameFlags, fieldFlags, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumFieldsByName(string name, CLRDataByNameFlag nameFlags, CLRDataFieldFlag fieldFlags, out IntPtr handle)
        {
            /*HRESULT StartEnumFieldsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag nameFlags,
            [In] CLRDataFieldFlag fieldFlags,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumFieldsByName(name, nameFlags, fieldFlags, out handle);
        }

        #endregion
        #region EnumFieldByName

        public EnumFieldByNameResult EnumFieldByName(ref IntPtr handle)
        {
            EnumFieldByNameResult result;
            TryEnumFieldByName(ref handle, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryEnumFieldByName(ref IntPtr handle, out EnumFieldByNameResult result)
        {
            /*HRESULT EnumFieldByName(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition type,
            [Out] out CLRDataFieldFlag flags,
            [Out] out mdFieldDef token);*/
            IXCLRDataTypeDefinition type;
            CLRDataFieldFlag flags;
            mdFieldDef token;
            HRESULT hr = Raw.EnumFieldByName(ref handle, out type, out flags, out token);

            if (hr == HRESULT.S_OK)
                result = new EnumFieldByNameResult(type == null ? null : new XCLRDataTypeDefinition(type), flags, token);
            else
                result = default(EnumFieldByNameResult);

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

        public GetFieldByTokenResult GetFieldByToken(mdFieldDef token)
        {
            GetFieldByTokenResult result;
            TryGetFieldByToken(token, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetFieldByToken(mdFieldDef token, out GetFieldByTokenResult result)
        {
            /*HRESULT GetFieldByToken(
            [In] mdFieldDef token,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] nameBuf,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition type,
            [Out] out CLRDataValueFlag flags);*/
            int nameBufLen = 0;
            int nameLen;
            char[] nameBuf;
            IXCLRDataTypeDefinition type;
            CLRDataValueFlag flags;
            HRESULT hr = Raw.GetFieldByToken(token, nameBufLen, out nameLen, null, out type, out flags);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufLen = nameLen;
            nameBuf = new char[nameBufLen];
            hr = Raw.GetFieldByToken(token, nameBufLen, out nameLen, nameBuf, out type, out flags);

            if (hr == HRESULT.S_OK)
            {
                result = new GetFieldByTokenResult(CreateString(nameBuf, nameLen), type == null ? null : new XCLRDataTypeDefinition(type), flags);

                return hr;
            }

            fail:
            result = default(GetFieldByTokenResult);

            return hr;
        }

        #endregion
        #region EnumField2

        public EnumField2Result EnumField2(ref IntPtr handle)
        {
            EnumField2Result result;
            TryEnumField2(ref handle, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryEnumField2(ref IntPtr handle, out EnumField2Result result)
        {
            /*HRESULT EnumField2(
            [In, Out] ref IntPtr handle,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] nameBuf,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition type,
            [Out] out CLRDataFieldFlag flags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);*/
            int nameBufLen = 0;
            int nameLen;
            char[] nameBuf;
            IXCLRDataTypeDefinition type;
            CLRDataFieldFlag flags;
            IXCLRDataModule tokenScope;
            mdFieldDef token;
            HRESULT hr = Raw.EnumField2(ref handle, nameBufLen, out nameLen, null, out type, out flags, out tokenScope, out token);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufLen = nameLen;
            nameBuf = new char[nameBufLen];
            hr = Raw.EnumField2(ref handle, nameBufLen, out nameLen, nameBuf, out type, out flags, out tokenScope, out token);

            if (hr == HRESULT.S_OK)
            {
                result = new EnumField2Result(CreateString(nameBuf, nameLen), type == null ? null : new XCLRDataTypeDefinition(type), flags, tokenScope == null ? null : new XCLRDataModule(tokenScope), token);

                return hr;
            }

            fail:
            result = default(EnumField2Result);

            return hr;
        }

        #endregion
        #region EnumFieldByName2

        public EnumFieldByName2Result EnumFieldByName2(ref IntPtr handle)
        {
            EnumFieldByName2Result result;
            TryEnumFieldByName2(ref handle, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryEnumFieldByName2(ref IntPtr handle, out EnumFieldByName2Result result)
        {
            /*HRESULT EnumFieldByName2(
            [In, Out] ref IntPtr handle,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition type,
            [Out] out CLRDataFieldFlag flags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);*/
            IXCLRDataTypeDefinition type;
            CLRDataFieldFlag flags;
            IXCLRDataModule tokenScope;
            mdFieldDef token;
            HRESULT hr = Raw.EnumFieldByName2(ref handle, out type, out flags, out tokenScope, out token);

            if (hr == HRESULT.S_OK)
                result = new EnumFieldByName2Result(type == null ? null : new XCLRDataTypeDefinition(type), flags, tokenScope == null ? null : new XCLRDataModule(tokenScope), token);
            else
                result = default(EnumFieldByName2Result);

            return hr;
        }

        #endregion
        #region GetFieldByToken2

        public GetFieldByToken2Result GetFieldByToken2(IXCLRDataModule tokenScope, mdFieldDef token)
        {
            GetFieldByToken2Result result;
            TryGetFieldByToken2(tokenScope, token, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetFieldByToken2(IXCLRDataModule tokenScope, mdFieldDef token, out GetFieldByToken2Result result)
        {
            /*HRESULT GetFieldByToken2(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataModule tokenScope,
            [In] mdFieldDef token,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] nameBuf,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeDefinition type,
            [Out] out CLRDataValueFlag flags);*/
            int nameBufLen = 0;
            int nameLen;
            char[] nameBuf;
            IXCLRDataTypeDefinition type;
            CLRDataValueFlag flags;
            HRESULT hr = Raw.GetFieldByToken2(tokenScope, token, nameBufLen, out nameLen, null, out type, out flags);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufLen = nameLen;
            nameBuf = new char[nameBufLen];
            hr = Raw.GetFieldByToken2(tokenScope, token, nameBufLen, out nameLen, nameBuf, out type, out flags);

            if (hr == HRESULT.S_OK)
            {
                result = new GetFieldByToken2Result(CreateString(nameBuf, nameLen), type == null ? null : new XCLRDataTypeDefinition(type), flags);

                return hr;
            }

            fail:
            result = default(GetFieldByToken2Result);

            return hr;
        }

        #endregion
        #endregion
    }
}
