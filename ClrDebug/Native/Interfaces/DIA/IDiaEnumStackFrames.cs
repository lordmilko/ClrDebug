using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various stack frames available.
    /// </summary>
    /// <remarks>
    /// Obtain this interface by calling the IDiaStackWalker or IDiaStackWalker methods.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("EC9D461D-CE74-4711-A020-7D8F9A1DD255")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaEnumStackFrames
    {
        /// <summary>
        /// Retrieves a specified number of stack frame elements from the enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of stackframe elements in the enumerator to be retrieved.</param>
        /// <param name="rgelt">[out] An array that is to be filled in with the requested IDiaStackFrame objects.</param>
        /// <param name="pceltFetched">[out] Returns the number of stack frame elements in the fetched enumerator.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no more stack frames. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaStackFrame rgelt,
            [Out] out int pceltFetched);

        /// <summary>
        /// Resets the enumeration sequence to the beginning.
        /// </summary>
        /// <returns>Returns S_OK.</returns>
        [PreserveSig]
        HRESULT Reset();
    }
}
