using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class XCLRDataStackWalk : ComObject<IXCLRDataStackWalk>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataStackWalk"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataStackWalk(IXCLRDataStackWalk raw) : base(raw)
        {
        }

        #region IXCLRDataStackWalk
        #region StackSizeSkipped

        public long StackSizeSkipped
        {
            get
            {
                HRESULT hr;
                long stackSizeSkipped;

                if ((hr = TryGetStackSizeSkipped(out stackSizeSkipped)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return stackSizeSkipped;
            }
        }

        public HRESULT TryGetStackSizeSkipped(out long stackSizeSkipped)
        {
            /*HRESULT GetStackSizeSkipped(
            [Out] out long stackSizeSkipped);*/
            return Raw.GetStackSizeSkipped(out stackSizeSkipped);
        }

        #endregion
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
        #region Frame

        public XCLRDataFrame Frame
        {
            get
            {
                HRESULT hr;
                XCLRDataFrame frameResult;

                if ((hr = TryGetFrame(out frameResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return frameResult;
            }
        }

        public HRESULT TryGetFrame(out XCLRDataFrame frameResult)
        {
            /*HRESULT GetFrame(
            [Out] out IXCLRDataFrame frame);*/
            IXCLRDataFrame frame;
            HRESULT hr = Raw.GetFrame(out frame);

            if (hr == HRESULT.S_OK)
                frameResult = new XCLRDataFrame(frame);
            else
                frameResult = default(XCLRDataFrame);

            return hr;
        }

        #endregion
        #region GetContext

        public GetContextResult GetContext(int contextFlags, int contextBufSize)
        {
            HRESULT hr;
            GetContextResult result;

            if ((hr = TryGetContext(contextFlags, contextBufSize, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetContext(int contextFlags, int contextBufSize, out GetContextResult result)
        {
            /*HRESULT GetContext(
            [In] int contextFlags,
            [In] int contextBufSize,
            [Out] out int contextSize,
            [Out] out IntPtr contextBuf);*/
            int contextSize;
            IntPtr contextBuf;
            HRESULT hr = Raw.GetContext(contextFlags, contextBufSize, out contextSize, out contextBuf);

            if (hr == HRESULT.S_OK)
                result = new GetContextResult(contextSize, contextBuf);
            else
                result = default(GetContextResult);

            return hr;
        }

        #endregion
        #region SetContext

        public void SetContext(int contextSize, IntPtr context)
        {
            HRESULT hr;

            if ((hr = TrySetContext(contextSize, context)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetContext(int contextSize, IntPtr context)
        {
            /*HRESULT SetContext(
            [In] int contextSize,
            [In] IntPtr context);*/
            return Raw.SetContext(contextSize, context);
        }

        #endregion
        #region Next

        public void Next()
        {
            HRESULT hr;

            if ((hr = TryNext()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryNext()
        {
            /*HRESULT Next();*/
            return Raw.Next();
        }

        #endregion
        #region Request

        public IntPtr Request(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize)
        {
            HRESULT hr;
            IntPtr outBuffer;

            if ((hr = TryRequest(reqCode, inBufferSize, inBuffer, outBufferSize, out outBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return outBuffer;
        }

        public HRESULT TryRequest(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize, out IntPtr outBuffer)
        {
            /*HRESULT Request(
            [In] uint reqCode,
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] out IntPtr outBuffer);*/
            return Raw.Request(reqCode, inBufferSize, inBuffer, outBufferSize, out outBuffer);
        }

        #endregion
        #region SetContext2

        public void SetContext2(int flags, int contextSize, IntPtr context)
        {
            HRESULT hr;

            if ((hr = TrySetContext2(flags, contextSize, context)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetContext2(int flags, int contextSize, IntPtr context)
        {
            /*HRESULT SetContext2(
            [In] int flags,
            [In] int contextSize,
            [In] IntPtr context);*/
            return Raw.SetContext2(flags, contextSize, context);
        }

        #endregion
        #endregion
    }
}