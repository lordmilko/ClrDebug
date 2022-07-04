using System;

namespace ClrDebug
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
                long stackSizeSkipped;
                TryGetStackSizeSkipped(out stackSizeSkipped).ThrowOnNotOK();

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
        #region Frame

        public XCLRDataFrame Frame
        {
            get
            {
                XCLRDataFrame frameResult;
                TryGetFrame(out frameResult).ThrowOnNotOK();

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

        public int GetContext(int contextFlags, int contextBufSize, IntPtr contextBuf)
        {
            int contextSize;
            TryGetContext(contextFlags, contextBufSize, out contextSize, contextBuf).ThrowOnNotOK();

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
        #region SetContext

        public void SetContext(int contextSize, IntPtr context)
        {
            TrySetContext(contextSize, context).ThrowOnNotOK();
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
            TryNext().ThrowOnNotOK();
        }

        public HRESULT TryNext()
        {
            /*HRESULT Next();*/
            return Raw.Next();
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
        #region SetContext2

        public void SetContext2(int flags, int contextSize, IntPtr context)
        {
            TrySetContext2(flags, contextSize, context).ThrowOnNotOK();
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
