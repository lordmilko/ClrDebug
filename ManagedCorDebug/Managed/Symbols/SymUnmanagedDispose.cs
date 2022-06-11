using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class SymUnmanagedDispose : ComObject<ISymUnmanagedDispose>
    {
        public SymUnmanagedDispose(ISymUnmanagedDispose raw) : base(raw)
        {
        }

        #region ISymUnmanagedDispose
        #region Destroy

        public void Destroy()
        {
            HRESULT hr;

            if ((hr = TryDestroy()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDestroy()
        {
            /*HRESULT Destroy();*/
            return Raw.Destroy();
        }

        #endregion
        #endregion
    }
}