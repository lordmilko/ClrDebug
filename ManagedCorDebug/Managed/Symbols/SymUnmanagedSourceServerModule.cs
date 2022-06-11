using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class SymUnmanagedSourceServerModule : ComObject<ISymUnmanagedSourceServerModule>
    {
        public SymUnmanagedSourceServerModule(ISymUnmanagedSourceServerModule raw) : base(raw)
        {
        }

        #region ISymUnmanagedSourceServerModule
        #region GetSourceServerData

        public GetSourceServerDataResult SourceServerData
        {
            get
            {
                HRESULT hr;
                GetSourceServerDataResult result;

                if ((hr = TryGetSourceServerData(out result)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return result;
            }
        }

        public HRESULT TryGetSourceServerData(out GetSourceServerDataResult result)
        {
            /*HRESULT GetSourceServerData(out uint pDataByteCount, [Out] IntPtr ppData);*/
            uint pDataByteCount;
            IntPtr ppData = default(IntPtr);
            HRESULT hr = Raw.GetSourceServerData(out pDataByteCount, ppData);

            if (hr == HRESULT.S_OK)
                result = new GetSourceServerDataResult(pDataByteCount, ppData);
            else
                result = default(GetSourceServerDataResult);

            return hr;
        }

        #endregion
        #endregion
    }
}