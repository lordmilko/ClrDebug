using System;
using System.Diagnostics;
using System.Text;

namespace ClrDebug
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
                GetFrameTypeResult result;
                TryGetFrameType(out result).ThrowOnNotOK();

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
                XCLRDataAppDomain appDomainResult;
                TryGetAppDomain(out appDomainResult).ThrowOnNotOK();

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
                int numArgs;
                TryGetNumArguments(out numArgs).ThrowOnNotOK();

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
                int numLocals;
                TryGetNumLocalVariables(out numLocals).ThrowOnNotOK();

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
                XCLRDataMethodInstance methodResult;
                TryGetMethodInstance(out methodResult).ThrowOnNotOK();

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
        #region GetContext

        public int GetContext(ContextFlags contextFlags, int contextBufSize, IntPtr contextBuf)
        {
            int contextSize;
            TryGetContext(contextFlags, contextBufSize, out contextSize, contextBuf).ThrowOnNotOK();

            return contextSize;
        }

        public HRESULT TryGetContext(ContextFlags contextFlags, int contextBufSize, out int contextSize, IntPtr contextBuf)
        {
            /*HRESULT GetContext(
            [In] ContextFlags contextFlags,
            [In] int contextBufSize,
            [Out] out int contextSize,
            [Out] IntPtr contextBuf);*/
            return Raw.GetContext(contextFlags, contextBufSize, out contextSize, contextBuf);
        }

        #endregion
        #region GetArgumentByIndex

        public GetArgumentByIndexResult GetArgumentByIndex(int index)
        {
            GetArgumentByIndexResult result;
            TryGetArgumentByIndex(index, out result).ThrowOnNotOK();

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
            StringBuilder name;
            HRESULT hr = Raw.GetArgumentByIndex(index, out arg, bufLen, out nameLen, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            name = new StringBuilder(bufLen);
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
            GetLocalVariableByIndexResult result;
            TryGetLocalVariableByIndex(index, out result).ThrowOnNotOK();

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
            StringBuilder name;
            HRESULT hr = Raw.GetLocalVariableByIndex(index, out localVariable, bufLen, out nameLen, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            name = new StringBuilder(bufLen);
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
            string nameBufResult;
            TryGetCodeName(flags, out nameBufResult).ThrowOnNotOK();

            return nameBufResult;
        }

        public HRESULT TryGetCodeName(int flags, out string nameBufResult)
        {
            /*HRESULT GetCodeName(
            [In] int flags, //Unused, must be 0
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);*/
            int bufLen = 0;
            int nameLen;
            StringBuilder nameBuf;
            HRESULT hr = Raw.GetCodeName(flags, bufLen, out nameLen, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new StringBuilder(bufLen);
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
                XCLRDataValue genericTokenResult;
                TryGetExactGenericArgsToken(out genericTokenResult).ThrowOnNotOK();

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
