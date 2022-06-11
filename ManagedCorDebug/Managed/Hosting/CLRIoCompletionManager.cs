using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CLRIoCompletionManager : ComObject<ICLRIoCompletionManager>
    {
        public CLRIoCompletionManager(ICLRIoCompletionManager raw) : base(raw)
        {
        }

        #region ICLRIoCompletionManager
        #region OnComplete

        public void OnComplete(HRESULT dwErrorCode, uint numberOfBytesTransferred, IntPtr pvOverlapped)
        {
            HRESULT hr;

            if ((hr = TryOnComplete(dwErrorCode, numberOfBytesTransferred, pvOverlapped)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOnComplete(HRESULT dwErrorCode, uint numberOfBytesTransferred, IntPtr pvOverlapped)
        {
            /*HRESULT OnComplete(
            [In] HRESULT dwErrorCode,
            [In] uint NumberOfBytesTransferred,
            [In] IntPtr pvOverlapped);*/
            return Raw.OnComplete(dwErrorCode, numberOfBytesTransferred, pvOverlapped);
        }

        #endregion
        #endregion
    }
}