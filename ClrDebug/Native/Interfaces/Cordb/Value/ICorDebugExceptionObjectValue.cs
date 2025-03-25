using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Extends the "ICorDebugObjectValue" interface to provide stack trace information from a managed exception object.
    /// </summary>
    /// <remarks>
    /// The call to QueryInterface will succeed for managed objects that derive from <see cref="Exception"/>.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("AE4CA65D-59DD-42A2-83A5-57E8A08D8719")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugExceptionObjectValue
    {
        /// <summary>
        /// Gets an enumerator to the call stack embedded in an exception object.
        /// </summary>
        /// <param name="ppCallStackEnum">[out] A pointer to the address of an <see cref="ICorDebugExceptionObjectCallStackEnum"/> interface object that is a stack trace enumerator for a managed exception object.</param>
        /// <remarks>
        /// If no call stack information is available, the method returns S_OK, and <see cref="ICorDebugExceptionObjectCallStackEnum"/>
        /// is a valid enumerator with a length of 0. If the method is unable to retrieve stack trace information, the return
        /// value is E_FAIL and no enumerator is returned. The <see cref="ICorDebugExceptionObjectCallStackEnum"/> object is
        /// responsible for decoding the stack trace data from the _stackTrace field of the exception object.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumerateExceptionCallStack(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugExceptionObjectCallStackEnum ppCallStackEnum);
    }
}
