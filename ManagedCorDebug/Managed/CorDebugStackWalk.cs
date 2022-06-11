using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugStackWalk : ComObject<ICorDebugStackWalk>
    {
        public CorDebugStackWalk(ICorDebugStackWalk raw) : base(raw)
        {
        }

        #region ICorDebugStackWalk
        #region GetFrame

        public CorDebugFrame Frame
        {
            get
            {
                HRESULT hr;
                CorDebugFrame pFrameResult;

                if ((hr = TryGetFrame(out pFrameResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pFrameResult;
            }
        }

        public HRESULT TryGetFrame(out CorDebugFrame pFrameResult)
        {
            /*HRESULT GetFrame([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame pFrame);*/
            ICorDebugFrame pFrame;
            HRESULT hr = Raw.GetFrame(out pFrame);

            if (hr == HRESULT.S_OK)
                pFrameResult = CorDebugFrame.New(pFrame);
            else
                pFrameResult = default(CorDebugFrame);

            return hr;
        }

        #endregion
        #region GetContext

        public GetContextResult GetContext(uint contextFlags, uint contextBufSize)
        {
            HRESULT hr;
            GetContextResult result;

            if ((hr = TryGetContext(contextFlags, contextBufSize, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetContext(uint contextFlags, uint contextBufSize, out GetContextResult result)
        {
            /*HRESULT GetContext(
            [In] uint contextFlags,
            [In] uint contextBufSize,
            out uint contextSize,
            out byte contextBuf);*/
            uint contextSize;
            byte contextBuf;
            HRESULT hr = Raw.GetContext(contextFlags, contextBufSize, out contextSize, out contextBuf);

            if (hr == HRESULT.S_OK)
                result = new GetContextResult(contextSize, contextBuf);
            else
                result = default(GetContextResult);

            return hr;
        }

        #endregion
        #region SetContext

        public void SetContext(CorDebugSetContextFlag flag, uint contextSize, IntPtr context)
        {
            HRESULT hr;

            if ((hr = TrySetContext(flag, contextSize, context)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetContext(CorDebugSetContextFlag flag, uint contextSize, IntPtr context)
        {
            /*HRESULT SetContext([In] CorDebugSetContextFlag flag, [In] uint contextSize, [In] IntPtr context);*/
            return Raw.SetContext(flag, contextSize, context);
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
        #endregion
    }
}