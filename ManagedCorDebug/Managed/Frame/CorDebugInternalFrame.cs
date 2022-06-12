using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a runtime-internal frame on the stack. This interface is a subclass of the <see cref="ICorDebugFrame"/> interface.
    /// </summary>
    public class CorDebugInternalFrame : CorDebugFrame
    {
        public CorDebugInternalFrame(ICorDebugInternalFrame raw) : base(raw)
        {
        }

        #region ICorDebugInternalFrame

        public new ICorDebugInternalFrame Raw => (ICorDebugInternalFrame) base.Raw;

        #region GetFrameType

        /// <summary>
        /// Gets the type of this internal frame.
        /// </summary>
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

        /// <summary>
        /// Gets the type of this internal frame.
        /// </summary>
        /// <param name="pType">[out] A pointer to a value of the <see cref="CorDebugInternalFrameType"/> enumeration that indicates the type of internal frame represented by this <see cref="ICorDebugInternalFrame"/> object.</param>
        /// <remarks>
        /// The internal frame type will never be STUBFRAME_NONE. Debuggers should gracefully ignore unrecognized internal
        /// frame types.
        /// </remarks>
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

        public long Address
        {
            get
            {
                HRESULT hr;
                long pAddress;

                if ((hr = TryGetAddress(out pAddress)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pAddress;
            }
        }

        public HRESULT TryGetAddress(out long pAddress)
        {
            /*HRESULT GetAddress(out long pAddress);*/
            return Raw2.GetAddress(out pAddress);
        }

        #endregion
        #region IsCloserToLeaf

        /// <summary>
        /// Checks whether the this internal frame is closer to the leaf than the specified <see cref="ICorDebugFrame"/> object.
        /// </summary>
        /// <param name="pFrameToCompare">[in] A pointer to the comparison <see cref="ICorDebugFrame"/> object.</param>
        /// <returns>[out] true if the this internal frame is closer to the leaf than the frame specified by pFrameToCompare; otherwise, false.</returns>
        /// <remarks>
        /// IsCloserToLeaf can be used to implement a policy for interleaving internal frames with other frames on the stack.
        /// </remarks>
        public int IsCloserToLeaf(ICorDebugFrame pFrameToCompare)
        {
            HRESULT hr;
            int pIsCloser;

            if ((hr = TryIsCloserToLeaf(pFrameToCompare, out pIsCloser)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pIsCloser;
        }

        /// <summary>
        /// Checks whether the this internal frame is closer to the leaf than the specified <see cref="ICorDebugFrame"/> object.
        /// </summary>
        /// <param name="pFrameToCompare">[in] A pointer to the comparison <see cref="ICorDebugFrame"/> object.</param>
        /// <param name="pIsCloser">[out] true if the this internal frame is closer to the leaf than the frame specified by pFrameToCompare; otherwise, false.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT      | Description                                |
        /// | ------------ | ------------------------------------------ |
        /// | S_OK         | The comparison was successfully performed. |
        /// | E_FAIL       | The comparison could not be performed.     |
        /// | E_INVALIDARG | pFrameToCompare or pIsCloser is null.      |
        /// </returns>
        /// <remarks>
        /// IsCloserToLeaf can be used to implement a policy for interleaving internal frames with other frames on the stack.
        /// </remarks>
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