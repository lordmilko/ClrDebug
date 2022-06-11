using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugVirtualUnwinder : ComObject<ICorDebugVirtualUnwinder>
    {
        public CorDebugVirtualUnwinder(ICorDebugVirtualUnwinder raw) : base(raw)
        {
        }

        #region ICorDebugVirtualUnwinder
        #region GetContext

        public GetContextResult GetContext(uint contextFlags, uint cbContextBuf)
        {
            HRESULT hr;
            GetContextResult result;

            if ((hr = TryGetContext(contextFlags, cbContextBuf, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetContext(uint contextFlags, uint cbContextBuf, out GetContextResult result)
        {
            /*HRESULT GetContext(
            [In] uint contextFlags,
            [In] uint cbContextBuf,
            out uint contextSize,
            out byte contextBuf);*/
            uint contextSize;
            byte contextBuf;
            HRESULT hr = Raw.GetContext(contextFlags, cbContextBuf, out contextSize, out contextBuf);

            if (hr == HRESULT.S_OK)
                result = new GetContextResult(contextSize, contextBuf);
            else
                result = default(GetContextResult);

            return hr;
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