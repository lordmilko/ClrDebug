using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Logically extends the ICorDebugFunction interface to provide support for Just My Code step-through debugging, which skips non-user code.
    /// </summary>
    [Guid("EF0C490B-94C3-4E4D-B629-DDC134C532D8")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugFunction2
    {
        /// <summary>
        /// Marks the function represented by this ICorDebugFunction2 for Just My Code stepping.
        /// </summary>
        /// <param name="bIsJustMyCode">[in] Set to true to mark the function as user code; otherwise, set to false.</param>
        /// <returns>
        /// | HRESULT                          | Description                                                                  |
        /// | -------------------------------- | ---------------------------------------------------------------------------- |
        /// | S_OK                             | The function was successfully marked.                                        |
        /// | CORDBG_E_FUNCTION_NOT_DEBUGGABLE | The function could not be marked as user code because it cannot be debugged. |
        /// </returns>
        /// <remarks>
        /// A Just My Code stepper will skip non-user code. User code must be a subset of debuggable code.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetJMCStatus([In] int bIsJustMyCode);

        /// <summary>
        /// Gets a value that indicates whether the function that is represented by this ICorDebugFunction2 object is marked as user code.
        /// </summary>
        /// <param name="pbIsJustMyCode">[out] A pointer to a Boolean value that is true, if this function is marked as user code; otherwise, the value is false.</param>
        /// <remarks>
        /// If the function represented by this ICorDebugFunction2 cannot be debugged, pbIsJustMyCode will always be false.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetJMCStatus(out int pbIsJustMyCode);

        /// <summary>
        /// Gets an interface pointer to an ICorDebugCodeEnum object that contains the native code statements in the function referenced by this ICorDebugFunction2 object.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateNativeCode([MarshalAs(UnmanagedType.Interface)] out ICorDebugCodeEnum ppCodeEnum);

        /// <summary>
        /// Gets the Edit and Continue version of this function.
        /// </summary>
        /// <param name="pnVersion">[out] A pointer to an integer that is the version number of the function that is represented by this ICorDebugFunction2 object.</param>
        /// <remarks>
        /// The runtime keeps track of the number of edits that have taken place to each module during a debug session. The
        /// version number of a function is one more than the number of the edit that introduced the function. The function's
        /// original version is version 1. The number is incremented for a module every time <see cref="ICorDebugModule2.ApplyChanges"/>
        /// is called on that module. Thus, if a function’s body was replaced in the first and third call to ICorDebugModule2::ApplyChanges,
        /// GetVersionNumber may return version 1, 2, or 4 for that function, but not version 3. (That function would have
        /// no version 3.) The version number is tracked separately for each module. So, if you perform four edits on Module
        /// 1, and none on Module 2, your next edit on Module 1 will assign a version number of 6 to all the edited functions
        /// in Module 1. If the same edit touches Module 2, the functions in Module 2 will get a version number of 2. The version
        /// number obtained by the GetVersionNumber method may be lower than that obtained by <see cref="ICorDebugFunction.GetCurrentVersionNumber"/>.
        /// The <see cref="ICorDebugCode.GetVersionNumber"/> method performs the same operation as ICorDebugFunction2::GetVersionNumber.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVersionNumber(out uint pnVersion);
    }
}