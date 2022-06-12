using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// A subclass of "ICorDebugHeapValue" that represents a boxed value class object.
    /// </summary>
    public class CorDebugBoxValue : CorDebugHeapValue
    {
        public CorDebugBoxValue(ICorDebugBoxValue raw) : base(raw)
        {
        }

        #region ICorDebugBoxValue

        public new ICorDebugBoxValue Raw => (ICorDebugBoxValue) base.Raw;

        #region Object

        /// <summary>
        /// Gets the boxed value.
        /// </summary>
        public CorDebugObjectValue Object
        {
            get
            {
                HRESULT hr;
                CorDebugObjectValue ppObjectResult;

                if ((hr = TryGetObject(out ppObjectResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppObjectResult;
            }
        }

        /// <summary>
        /// Gets the boxed value.
        /// </summary>
        /// <param name="ppObjectResult">[out] A pointer to the address of an <see cref="ICorDebugObjectValue"/> object that represents the boxed value.</param>
        public HRESULT TryGetObject(out CorDebugObjectValue ppObjectResult)
        {
            /*HRESULT GetObject([MarshalAs(UnmanagedType.Interface)] out ICorDebugObjectValue ppObject);*/
            ICorDebugObjectValue ppObject;
            HRESULT hr = Raw.GetObject(out ppObject);

            if (hr == HRESULT.S_OK)
                ppObjectResult = CorDebugObjectValue.New(ppObject);
            else
                ppObjectResult = default(CorDebugObjectValue);

            return hr;
        }

        #endregion
        #endregion
    }
}