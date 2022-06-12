using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides source server data for a module. Obtain this interface by calling QueryInterface on an object that implements the <see cref="ISymUnmanagedReader"/> interface.
    /// </summary>
    public class SymUnmanagedSourceServerModule : ComObject<ISymUnmanagedSourceServerModule>
    {
        public SymUnmanagedSourceServerModule(ISymUnmanagedSourceServerModule raw) : base(raw)
        {
        }

        #region ISymUnmanagedSourceServerModule
        #region GetSourceServerData

        /// <summary>
        /// Returns the source server data for the module. The caller must free resources by using CoTaskMemFree.
        /// </summary>
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

        /// <summary>
        /// Returns the source server data for the module. The caller must free resources by using CoTaskMemFree.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSourceServerData(out GetSourceServerDataResult result)
        {
            /*HRESULT GetSourceServerData(out int pDataByteCount, [Out] IntPtr ppData);*/
            int pDataByteCount;
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