using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class XCLRDataFrame : ComObject<IXCLRDataFrame>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataFrame"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataFrame(IXCLRDataFrame raw) : base(raw)
        {
        }

        #region IXCLRDataFrame
        #region FrameType

        public GetFrameTypeResult FrameType
        {
            get
            {
                HRESULT hr;
                GetFrameTypeResult result;

                if ((hr = TryGetFrameType(out result)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return result;
            }
        }

        public HRESULT TryGetFrameType(out GetFrameTypeResult result)
        {
            /*HRESULT GetFrameType(
            [Out] out CLRDataSimpleFrameType simpleType,
            [Out] out CLRDataDetailedFrameType detailedType);*/
            CLRDataSimpleFrameType simpleType;
            CLRDataDetailedFrameType detailedType;
            HRESULT hr = Raw.GetFrameType(out simpleType, out detailedType);

            if (hr == HRESULT.S_OK)
                result = new GetFrameTypeResult(simpleType, detailedType);
            else
                result = default(GetFrameTypeResult);

            return hr;
        }

        #endregion
        #region AppDomain

        public XCLRDataAppDomain AppDomain
        {
            get
            {
                HRESULT hr;
                XCLRDataAppDomain appDomainResult;

                if ((hr = TryGetAppDomain(out appDomainResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return appDomainResult;
            }
        }

        public HRESULT TryGetAppDomain(out XCLRDataAppDomain appDomainResult)
        {
            /*HRESULT GetAppDomain(
            [Out] out IXCLRDataAppDomain appDomain);*/
            IXCLRDataAppDomain appDomain;
            HRESULT hr = Raw.GetAppDomain(out appDomain);

            if (hr == HRESULT.S_OK)
                appDomainResult = new XCLRDataAppDomain(appDomain);
            else
                appDomainResult = default(XCLRDataAppDomain);

            return hr;
        }

        #endregion
        #region NumArguments

        public int NumArguments
        {
            get
            {
                HRESULT hr;
                int numArgs;

                if ((hr = TryGetNumArguments(out numArgs)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return numArgs;
            }
        }

        public HRESULT TryGetNumArguments(out int numArgs)
        {
            /*HRESULT GetNumArguments(
            [Out] out int numArgs);*/
            return Raw.GetNumArguments(out numArgs);
        }

        #endregion
        #region NumLocalVariables

        public int NumLocalVariables
        {
            get
            {
                HRESULT hr;
                int numLocals;

                if ((hr = TryGetNumLocalVariables(out numLocals)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return numLocals;
            }
        }

        public HRESULT TryGetNumLocalVariables(out int numLocals)
        {
            /*HRESULT GetNumLocalVariables(
            [Out] out int numLocals);*/
            return Raw.GetNumLocalVariables(out numLocals);
        }

        #endregion
        #region MethodInstance

        public XCLRDataMethodInstance MethodInstance
        {
            get
            {
                HRESULT hr;
                XCLRDataMethodInstance methodResult;

                if ((hr = TryGetMethodInstance(out methodResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return methodResult;
            }
        }

        public HRESULT TryGetMethodInstance(out XCLRDataMethodInstance methodResult)
        {
            /*HRESULT GetMethodInstance(
            [Out] out IXCLRDataMethodInstance method);*/
            IXCLRDataMethodInstance method;
            HRESULT hr = Raw.GetMethodInstance(out method);

            if (hr == HRESULT.S_OK)
                methodResult = new XCLRDataMethodInstance(method);
            else
                methodResult = default(XCLRDataMethodInstance);

            return hr;
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
        #region GetContext

        public int GetContext(int contextFlags, int contextBufSize, IntPtr contextBuf)
        {
            HRESULT hr;
            int contextSize;

            if ((hr = TryGetContext(contextFlags, contextBufSize, out contextSize, contextBuf)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return contextSize;
        }

        public HRESULT TryGetContext(int contextFlags, int contextBufSize, out int contextSize, IntPtr contextBuf)
        {
            /*HRESULT GetContext(
            [In] int contextFlags,
            [In] int contextBufSize,
            [Out] out int contextSize,
            [Out] IntPtr contextBuf);*/
            return Raw.GetContext(contextFlags, contextBufSize, out contextSize, contextBuf);
        }

        #endregion
        #region GetArgumentByIndex

        public GetArgumentByIndexResult GetArgumentByIndex(int index)
        {
            HRESULT hr;
            GetArgumentByIndexResult result;

            if ((hr = TryGetArgumentByIndex(index, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetArgumentByIndex(int index, out GetArgumentByIndexResult result)
        {
            /*HRESULT GetArgumentByIndex(
            [In] int index,
            [Out] out IXCLRDataValue arg,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name);*/
            IXCLRDataValue arg;
            int bufLen = 0;
            int nameLen;
            StringBuilder name = null;
            HRESULT hr = Raw.GetArgumentByIndex(index, out arg, bufLen, out nameLen, name);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            name = new StringBuilder(nameLen);
            hr = Raw.GetArgumentByIndex(index, out arg, bufLen, out nameLen, name);

            if (hr == HRESULT.S_OK)
            {
                result = new GetArgumentByIndexResult(new XCLRDataValue(arg), name.ToString());

                return hr;
            }

            fail:
            result = default(GetArgumentByIndexResult);

            return hr;
        }

        #endregion
        #region GetLocalVariableByIndex

        public GetLocalVariableByIndexResult GetLocalVariableByIndex(int index)
        {
            HRESULT hr;
            GetLocalVariableByIndexResult result;

            if ((hr = TryGetLocalVariableByIndex(index, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetLocalVariableByIndex(int index, out GetLocalVariableByIndexResult result)
        {
            /*HRESULT GetLocalVariableByIndex(
            [In] int index,
            [Out] out IXCLRDataValue localVariable,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name);*/
            IXCLRDataValue localVariable;
            int bufLen = 0;
            int nameLen;
            StringBuilder name = null;
            HRESULT hr = Raw.GetLocalVariableByIndex(index, out localVariable, bufLen, out nameLen, name);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            name = new StringBuilder(nameLen);
            hr = Raw.GetLocalVariableByIndex(index, out localVariable, bufLen, out nameLen, name);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLocalVariableByIndexResult(new XCLRDataValue(localVariable), name.ToString());

                return hr;
            }

            fail:
            result = default(GetLocalVariableByIndexResult);

            return hr;
        }

        #endregion
        #region GetCodeName

        public string GetCodeName(int flags)
        {
            HRESULT hr;
            string nameBufResult;

            if ((hr = TryGetCodeName(flags, out nameBufResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return nameBufResult;
        }

        public HRESULT TryGetCodeName(int flags, out string nameBufResult)
        {
            /*HRESULT GetCodeName(
            [In] int flags,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);*/
            int bufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            HRESULT hr = Raw.GetCodeName(flags, bufLen, out nameLen, nameBuf);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.GetCodeName(flags, bufLen, out nameLen, nameBuf);

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
        #endregion
        #region IXCLRDataFrame2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IXCLRDataFrame2 Raw2 => (IXCLRDataFrame2) Raw;

        #region ExactGenericArgsToken

        public XCLRDataValue ExactGenericArgsToken
        {
            get
            {
                HRESULT hr;
                XCLRDataValue genericTokenResult;

                if ((hr = TryGetExactGenericArgsToken(out genericTokenResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return genericTokenResult;
            }
        }

        public HRESULT TryGetExactGenericArgsToken(out XCLRDataValue genericTokenResult)
        {
            /*HRESULT GetExactGenericArgsToken(
            [Out] out IXCLRDataValue genericToken);*/
            IXCLRDataValue genericToken;
            HRESULT hr = Raw2.GetExactGenericArgsToken(out genericToken);

            if (hr == HRESULT.S_OK)
                genericTokenResult = new XCLRDataValue(genericToken);
            else
                genericTokenResult = default(XCLRDataValue);

            return hr;
        }

        #endregion
        #endregion
    }
}