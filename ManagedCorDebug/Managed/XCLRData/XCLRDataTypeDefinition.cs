using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
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
        #region TokenAndScope

        public XCLRDataTypeDefinition_GetTokenAndScopeResult TokenAndScope
        {
            get
            {
                HRESULT hr;
                XCLRDataTypeDefinition_GetTokenAndScopeResult result;

                if ((hr = TryGetTokenAndScope(out result)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return result;
            }
        }

        public HRESULT TryGetTokenAndScope(out XCLRDataTypeDefinition_GetTokenAndScopeResult result)
        {
            /*HRESULT GetTokenAndScope(
            [Out] out mdTypeDef token,
            [Out] out IXCLRDataModule mod);*/
            mdTypeDef token;
            IXCLRDataModule mod;
            HRESULT hr = Raw.GetTokenAndScope(out token, out mod);

            if (hr == HRESULT.S_OK)
                result = new XCLRDataTypeDefinition_GetTokenAndScopeResult(token, new XCLRDataModule(mod));
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
                HRESULT hr;
                CorElementType type;

                if ((hr = TryGetCorElementType(out type)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
        #region ArrayRank

        public int ArrayRank
        {
            get
            {
                HRESULT hr;
                int rank;

                if ((hr = TryGetArrayRank(out rank)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
                HRESULT hr;
                XCLRDataTypeDefinition _baseResult;

                if ((hr = TryGetBase(out _baseResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return _baseResult;
            }
        }

        public HRESULT TryGetBase(out XCLRDataTypeDefinition _baseResult)
        {
            /*HRESULT GetBase(
            [Out] out IXCLRDataTypeDefinition _base);*/
            IXCLRDataTypeDefinition _base;
            HRESULT hr = Raw.GetBase(out _base);

            if (hr == HRESULT.S_OK)
                _baseResult = new XCLRDataTypeDefinition(_base);
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
                HRESULT hr;
                int flags;

                if ((hr = TryGetTypeNotification(out flags)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return flags;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetTypeNotification(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumMethodDefinitions(out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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

        public EnumMethodDefinitionResult EnumMethodDefinition()
        {
            HRESULT hr;
            EnumMethodDefinitionResult result;

            if ((hr = TryEnumMethodDefinition(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumMethodDefinition(out EnumMethodDefinitionResult result)
        {
            /*HRESULT EnumMethodDefinition(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodDefinition methodDefinition);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataMethodDefinition methodDefinition;
            HRESULT hr = Raw.EnumMethodDefinition(ref handle, out methodDefinition);

            if (hr == HRESULT.S_OK)
                result = new EnumMethodDefinitionResult(handle, new XCLRDataMethodDefinition(methodDefinition));
            else
                result = default(EnumMethodDefinitionResult);

            return hr;
        }

        #endregion
        #region EndEnumMethodDefinitions

        public void EndEnumMethodDefinitions(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumMethodDefinitions(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumMethodDefinitions(IntPtr handle)
        {
            /*HRESULT EndEnumMethodDefinitions(
            [In] IntPtr handle);*/
            return Raw.EndEnumMethodDefinitions(handle);
        }

        #endregion
        #region StartEnumMethodDefinitionsByName

        public IntPtr StartEnumMethodDefinitionsByName(string name, int flags)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumMethodDefinitionsByName(name, flags, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumMethodDefinitionsByName(string name, int flags, out IntPtr handle)
        {
            /*HRESULT StartEnumMethodDefinitionsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int flags,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumMethodDefinitionsByName(name, flags, out handle);
        }

        #endregion
        #region EnumMethodDefinitionByName

        public EnumMethodDefinitionByNameResult EnumMethodDefinitionByName()
        {
            HRESULT hr;
            EnumMethodDefinitionByNameResult result;

            if ((hr = TryEnumMethodDefinitionByName(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumMethodDefinitionByName(out EnumMethodDefinitionByNameResult result)
        {
            /*HRESULT EnumMethodDefinitionByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodDefinition method);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataMethodDefinition method;
            HRESULT hr = Raw.EnumMethodDefinitionByName(ref handle, out method);

            if (hr == HRESULT.S_OK)
                result = new EnumMethodDefinitionByNameResult(handle, new XCLRDataMethodDefinition(method));
            else
                result = default(EnumMethodDefinitionByNameResult);

            return hr;
        }

        #endregion
        #region EndEnumMethodDefinitionsByName

        public void EndEnumMethodDefinitionsByName(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumMethodDefinitionsByName(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;
            XCLRDataMethodDefinition methodDefinitionResult;

            if ((hr = TryGetMethodDefinitionByToken(token, out methodDefinitionResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return methodDefinitionResult;
        }

        public HRESULT TryGetMethodDefinitionByToken(mdMethodDef token, out XCLRDataMethodDefinition methodDefinitionResult)
        {
            /*HRESULT GetMethodDefinitionByToken(
            [In] mdMethodDef token,
            [Out] out IXCLRDataMethodDefinition methodDefinition);*/
            IXCLRDataMethodDefinition methodDefinition;
            HRESULT hr = Raw.GetMethodDefinitionByToken(token, out methodDefinition);

            if (hr == HRESULT.S_OK)
                methodDefinitionResult = new XCLRDataMethodDefinition(methodDefinition);
            else
                methodDefinitionResult = default(XCLRDataMethodDefinition);

            return hr;
        }

        #endregion
        #region StartEnumInstances

        public IntPtr StartEnumInstances(IXCLRDataAppDomain appDomain)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumInstances(appDomain, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumInstances(IXCLRDataAppDomain appDomain, out IntPtr handle)
        {
            /*HRESULT StartEnumInstances(
            [In] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumInstances(appDomain, out handle);
        }

        #endregion
        #region EnumInstance

        public XCLRDataTypeDefinition_EnumInstanceResult EnumInstance()
        {
            HRESULT hr;
            XCLRDataTypeDefinition_EnumInstanceResult result;

            if ((hr = TryEnumInstance(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumInstance(out XCLRDataTypeDefinition_EnumInstanceResult result)
        {
            /*HRESULT EnumInstance(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTypeInstance instance);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataTypeInstance instance;
            HRESULT hr = Raw.EnumInstance(ref handle, out instance);

            if (hr == HRESULT.S_OK)
                result = new XCLRDataTypeDefinition_EnumInstanceResult(handle, new XCLRDataTypeInstance(instance));
            else
                result = default(XCLRDataTypeDefinition_EnumInstanceResult);

            return hr;
        }

        #endregion
        #region EndEnumInstances

        public void EndEnumInstances(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumInstances(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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

        public bool IsSameObject(IXCLRDataTypeDefinition type)
        {
            HRESULT hr;

            if ((hr = TryIsSameObject(type)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return hr == HRESULT.S_OK;
        }

        public HRESULT TryIsSameObject(IXCLRDataTypeDefinition type)
        {
            /*HRESULT IsSameObject(
            [In] IXCLRDataTypeDefinition type);*/
            return Raw.IsSameObject(type);
        }

        #endregion
        #region Request

        public void Request(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize, IntPtr outBuffer)
        {
            HRESULT hr;

            if ((hr = TryRequest(reqCode, inBufferSize, inBuffer, outBufferSize, outBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
        #region GetNumFields

        public int GetNumFields(int flags)
        {
            HRESULT hr;
            int numFields;

            if ((hr = TryGetNumFields(flags, out numFields)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return numFields;
        }

        public HRESULT TryGetNumFields(int flags, out int numFields)
        {
            /*HRESULT GetNumFields(
            [In] int flags,
            [Out] out int numFields);*/
            return Raw.GetNumFields(flags, out numFields);
        }

        #endregion
        #region StartEnumFields

        public IntPtr StartEnumFields(int flags)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumFields(flags, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumFields(int flags, out IntPtr handle)
        {
            /*HRESULT StartEnumFields(
            [In] int flags,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumFields(flags, out handle);
        }

        #endregion
        #region EnumField

        public EnumFieldResult EnumField()
        {
            HRESULT hr;
            EnumFieldResult result;

            if ((hr = TryEnumField(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumField(out EnumFieldResult result)
        {
            /*HRESULT EnumField(
            [In, Out] ref IntPtr handle,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out IXCLRDataTypeDefinition type,
            [Out] out int flags,
            [Out] out mdFieldDef token);*/
            IntPtr handle = default(IntPtr);
            int nameBufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            IXCLRDataTypeDefinition type;
            int flags;
            mdFieldDef token;
            HRESULT hr = Raw.EnumField(ref handle, nameBufLen, out nameLen, nameBuf, out type, out flags, out token);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.EnumField(ref handle, nameBufLen, out nameLen, nameBuf, out type, out flags, out token);

            if (hr == HRESULT.S_OK)
            {
                result = new EnumFieldResult(handle, nameBuf.ToString(), new XCLRDataTypeDefinition(type), flags, token);

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
            HRESULT hr;

            if ((hr = TryEndEnumFields(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumFields(IntPtr handle)
        {
            /*HRESULT EndEnumFields(
            [In] IntPtr handle);*/
            return Raw.EndEnumFields(handle);
        }

        #endregion
        #region StartEnumFieldsByName

        public IntPtr StartEnumFieldsByName(string name, int nameFlags, int fieldFlags)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumFieldsByName(name, nameFlags, fieldFlags, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumFieldsByName(string name, int nameFlags, int fieldFlags, out IntPtr handle)
        {
            /*HRESULT StartEnumFieldsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int nameFlags,
            [In] int fieldFlags,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumFieldsByName(name, nameFlags, fieldFlags, out handle);
        }

        #endregion
        #region EnumFieldByName

        public EnumFieldByNameResult EnumFieldByName()
        {
            HRESULT hr;
            EnumFieldByNameResult result;

            if ((hr = TryEnumFieldByName(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumFieldByName(out EnumFieldByNameResult result)
        {
            /*HRESULT EnumFieldByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTypeDefinition type,
            [Out] out int flags,
            [Out] out mdFieldDef token);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataTypeDefinition type;
            int flags;
            mdFieldDef token;
            HRESULT hr = Raw.EnumFieldByName(ref handle, out type, out flags, out token);

            if (hr == HRESULT.S_OK)
                result = new EnumFieldByNameResult(handle, new XCLRDataTypeDefinition(type), flags, token);
            else
                result = default(EnumFieldByNameResult);

            return hr;
        }

        #endregion
        #region EndEnumFieldsByName

        public void EndEnumFieldsByName(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumFieldsByName(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;
            GetFieldByTokenResult result;

            if ((hr = TryGetFieldByToken(token, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetFieldByToken(mdFieldDef token, out GetFieldByTokenResult result)
        {
            /*HRESULT GetFieldByToken(
            [In] mdFieldDef token,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out IXCLRDataTypeDefinition type,
            [Out] out int flags);*/
            int nameBufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            IXCLRDataTypeDefinition type;
            int flags;
            HRESULT hr = Raw.GetFieldByToken(token, nameBufLen, out nameLen, nameBuf, out type, out flags);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.GetFieldByToken(token, nameBufLen, out nameLen, nameBuf, out type, out flags);

            if (hr == HRESULT.S_OK)
            {
                result = new GetFieldByTokenResult(nameBuf.ToString(), new XCLRDataTypeDefinition(type), flags);

                return hr;
            }

            fail:
            result = default(GetFieldByTokenResult);

            return hr;
        }

        #endregion
        #region EnumField2

        public EnumField2Result EnumField2()
        {
            HRESULT hr;
            EnumField2Result result;

            if ((hr = TryEnumField2(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumField2(out EnumField2Result result)
        {
            /*HRESULT EnumField2(
            [In, Out] ref IntPtr handle,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out IXCLRDataTypeDefinition type,
            [Out] out int flags,
            [Out] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);*/
            IntPtr handle = default(IntPtr);
            int nameBufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            IXCLRDataTypeDefinition type;
            int flags;
            IXCLRDataModule tokenScope;
            mdFieldDef token;
            HRESULT hr = Raw.EnumField2(ref handle, nameBufLen, out nameLen, nameBuf, out type, out flags, out tokenScope, out token);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.EnumField2(ref handle, nameBufLen, out nameLen, nameBuf, out type, out flags, out tokenScope, out token);

            if (hr == HRESULT.S_OK)
            {
                result = new EnumField2Result(handle, nameBuf.ToString(), new XCLRDataTypeDefinition(type), flags, new XCLRDataModule(tokenScope), token);

                return hr;
            }

            fail:
            result = default(EnumField2Result);

            return hr;
        }

        #endregion
        #region EnumFieldByName2

        public EnumFieldByName2Result EnumFieldByName2()
        {
            HRESULT hr;
            EnumFieldByName2Result result;

            if ((hr = TryEnumFieldByName2(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumFieldByName2(out EnumFieldByName2Result result)
        {
            /*HRESULT EnumFieldByName2(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTypeDefinition type,
            [Out] out int flags,
            [Out] out IXCLRDataModule tokenScope,
            [Out] out mdFieldDef token);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataTypeDefinition type;
            int flags;
            IXCLRDataModule tokenScope;
            mdFieldDef token;
            HRESULT hr = Raw.EnumFieldByName2(ref handle, out type, out flags, out tokenScope, out token);

            if (hr == HRESULT.S_OK)
                result = new EnumFieldByName2Result(handle, new XCLRDataTypeDefinition(type), flags, new XCLRDataModule(tokenScope), token);
            else
                result = default(EnumFieldByName2Result);

            return hr;
        }

        #endregion
        #region GetFieldByToken2

        public GetFieldByToken2Result GetFieldByToken2(IXCLRDataModule tokenScope, mdFieldDef token)
        {
            HRESULT hr;
            GetFieldByToken2Result result;

            if ((hr = TryGetFieldByToken2(tokenScope, token, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetFieldByToken2(IXCLRDataModule tokenScope, mdFieldDef token, out GetFieldByToken2Result result)
        {
            /*HRESULT GetFieldByToken2(
            [In] IXCLRDataModule tokenScope,
            [In] mdFieldDef token,
            [In] int nameBufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out IXCLRDataTypeDefinition type,
            [Out] out int flags);*/
            int nameBufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            IXCLRDataTypeDefinition type;
            int flags;
            HRESULT hr = Raw.GetFieldByToken2(tokenScope, token, nameBufLen, out nameLen, nameBuf, out type, out flags);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.GetFieldByToken2(tokenScope, token, nameBufLen, out nameLen, nameBuf, out type, out flags);

            if (hr == HRESULT.S_OK)
            {
                result = new GetFieldByToken2Result(nameBuf.ToString(), new XCLRDataTypeDefinition(type), flags);

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