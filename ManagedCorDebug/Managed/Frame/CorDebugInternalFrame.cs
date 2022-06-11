using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugInternalFrame : CorDebugFrame
    {
        public CorDebugInternalFrame(ICorDebugInternalFrame raw) : base(raw)
        {
        }

        #region ICorDebugInternalFrame

        public new ICorDebugInternalFrame Raw => (ICorDebugInternalFrame) base.Raw;

        #region GetFrameType

        public CorDebugInternalFrameType FrameType
        {
            get
            {
                HRESULT hr;
                CorDebugInternalFrameType pType;

                if ((hr = TryGetFrameType(out pType)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pType;
            }
        }

        public HRESULT TryGetFrameType(out CorDebugInternalFrameType pType)
        {
            /*HRESULT GetFrameType(out CorDebugInternalFrameType pType);*/
            return Raw.GetFrameType(out pType);
        }

        #endregion
        #endregion
        #region ICorDebugInternalFrame2

        public ICorDebugInternalFrame2 Raw2 => (ICorDebugInternalFrame2) Raw;

        #region GetAddress

        public ulong Address
        {
            get
            {
                HRESULT hr;
                ulong pAddress;

                if ((hr = TryGetAddress(out pAddress)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pAddress;
            }
        }

        public HRESULT TryGetAddress(out ulong pAddress)
        {
            /*HRESULT GetAddress(out ulong pAddress);*/
            return Raw2.GetAddress(out pAddress);
        }

        #endregion
        #region IsCloserToLeaf

        public int IsCloserToLeaf(ICorDebugFrame pFrameToCompare)
        {
            HRESULT hr;
            int pIsCloser;

            if ((hr = TryIsCloserToLeaf(pFrameToCompare, out pIsCloser)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pIsCloser;
        }

        public HRESULT TryIsCloserToLeaf(ICorDebugFrame pFrameToCompare, out int pIsCloser)
        {
            /*HRESULT IsCloserToLeaf([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrameToCompare, out int pIsCloser);*/
            return Raw2.IsCloserToLeaf(pFrameToCompare, out pIsCloser);
        }

        #endregion
        #endregion
    }
}