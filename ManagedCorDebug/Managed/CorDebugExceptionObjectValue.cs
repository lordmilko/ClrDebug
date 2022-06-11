using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugExceptionObjectValue : ComObject<ICorDebugExceptionObjectValue>
    {
        public CorDebugExceptionObjectValue(ICorDebugExceptionObjectValue raw) : base(raw)
        {
        }

        #region ICorDebugExceptionObjectValue
        #region EnumerateExceptionCallStack

        public CorDebugExceptionObjectCallStackEnum EnumerateExceptionCallStack()
        {
            HRESULT hr;
            CorDebugExceptionObjectCallStackEnum ppCallStackEnumResult;

            if ((hr = TryEnumerateExceptionCallStack(out ppCallStackEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppCallStackEnumResult;
        }

        public HRESULT TryEnumerateExceptionCallStack(out CorDebugExceptionObjectCallStackEnum ppCallStackEnumResult)
        {
            /*HRESULT EnumerateExceptionCallStack(
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugExceptionObjectCallStackEnum ppCallStackEnum);*/
            ICorDebugExceptionObjectCallStackEnum ppCallStackEnum;
            HRESULT hr = Raw.EnumerateExceptionCallStack(out ppCallStackEnum);

            if (hr == HRESULT.S_OK)
                ppCallStackEnumResult = new CorDebugExceptionObjectCallStackEnum(ppCallStackEnum);
            else
                ppCallStackEnumResult = default(CorDebugExceptionObjectCallStackEnum);

            return hr;
        }

        #endregion
        #endregion
    }
}