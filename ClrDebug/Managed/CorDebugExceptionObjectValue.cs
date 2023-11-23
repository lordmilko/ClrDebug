using System;
using System.Linq;

namespace ClrDebug
{
    /// <summary>
    /// Extends the "ICorDebugObjectValue" interface to provide stack trace information from a managed exception object.
    /// </summary>
    /// <remarks>
    /// The call to QueryInterface will succeed for managed objects that derive from <see cref="Exception"/>.
    /// </remarks>
    public class CorDebugExceptionObjectValue : ComObject<ICorDebugExceptionObjectValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugExceptionObjectValue"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugExceptionObjectValue(ICorDebugExceptionObjectValue raw) : base(raw)
        {
        }

        #region ICorDebugExceptionObjectValue
        #region EnumerateExceptionCallStack

        /// <summary>
        /// Gets an enumerator to the call stack embedded in an exception object.
        /// </summary>
        public CorDebugExceptionObjectStackFrame[] ExceptionCallStacks => EnumerateExceptionCallStack().ToArray();

        /// <summary>
        /// Gets an enumerator to the call stack embedded in an exception object.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugExceptionObjectCallStackEnum"/> interface object that is a stack trace enumerator for a managed exception object.</returns>
        /// <remarks>
        /// If no call stack information is available, the method returns S_OK, and <see cref="ICorDebugExceptionObjectCallStackEnum"/>
        /// is a valid enumerator with a length of 0. If the method is unable to retrieve stack trace information, the return
        /// value is E_FAIL and no enumerator is returned. The <see cref="ICorDebugExceptionObjectCallStackEnum"/> object is
        /// responsible for decoding the stack trace data from the _stackTrace field of the exception object.
        /// </remarks>
        public CorDebugExceptionObjectCallStackEnum EnumerateExceptionCallStack()
        {
            CorDebugExceptionObjectCallStackEnum ppCallStackEnumResult;
            TryEnumerateExceptionCallStack(out ppCallStackEnumResult).ThrowOnNotOK();

            return ppCallStackEnumResult;
        }

        /// <summary>
        /// Gets an enumerator to the call stack embedded in an exception object.
        /// </summary>
        /// <param name="ppCallStackEnumResult">[out] A pointer to the address of an <see cref="ICorDebugExceptionObjectCallStackEnum"/> interface object that is a stack trace enumerator for a managed exception object.</param>
        /// <remarks>
        /// If no call stack information is available, the method returns S_OK, and <see cref="ICorDebugExceptionObjectCallStackEnum"/>
        /// is a valid enumerator with a length of 0. If the method is unable to retrieve stack trace information, the return
        /// value is E_FAIL and no enumerator is returned. The <see cref="ICorDebugExceptionObjectCallStackEnum"/> object is
        /// responsible for decoding the stack trace data from the _stackTrace field of the exception object.
        /// </remarks>
        public HRESULT TryEnumerateExceptionCallStack(out CorDebugExceptionObjectCallStackEnum ppCallStackEnumResult)
        {
            /*HRESULT EnumerateExceptionCallStack(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugExceptionObjectCallStackEnum ppCallStackEnum);*/
            ICorDebugExceptionObjectCallStackEnum ppCallStackEnum;
            HRESULT hr = Raw.EnumerateExceptionCallStack(out ppCallStackEnum);

            if (hr == HRESULT.S_OK)
                ppCallStackEnumResult = ppCallStackEnum == null ? null : new CorDebugExceptionObjectCallStackEnum(ppCallStackEnum);
            else
                ppCallStackEnumResult = default(CorDebugExceptionObjectCallStackEnum);

            return hr;
        }

        #endregion
        #endregion
    }
}
