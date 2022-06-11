using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class SymUnmanagedDocumentWriter : ComObject<ISymUnmanagedDocumentWriter>
    {
        public SymUnmanagedDocumentWriter(ISymUnmanagedDocumentWriter raw) : base(raw)
        {
        }

        #region ISymUnmanagedDocumentWriter
        #region SetSource

        public void SetSource(uint sourceSize, IntPtr source)
        {
            HRESULT hr;

            if ((hr = TrySetSource(sourceSize, source)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetSource(uint sourceSize, IntPtr source)
        {
            /*HRESULT SetSource([In] uint sourceSize, [In] IntPtr source);*/
            return Raw.SetSource(sourceSize, source);
        }

        #endregion
        #region SetCheckSum

        public void SetCheckSum(Guid algorithmId, uint checkSumSize, IntPtr checkSum)
        {
            HRESULT hr;

            if ((hr = TrySetCheckSum(algorithmId, checkSumSize, checkSum)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetCheckSum(Guid algorithmId, uint checkSumSize, IntPtr checkSum)
        {
            /*HRESULT SetCheckSum([In] Guid algorithmId, [In] uint checkSumSize, [In] IntPtr checkSum);*/
            return Raw.SetCheckSum(algorithmId, checkSumSize, checkSum);
        }

        #endregion
        #endregion
    }
}