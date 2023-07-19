using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.6 and later versions] Logically extends the <see cref="ICorDebugProcess"/> interface to enable or disable certain types of <see cref="ICorDebugManagedCallback2"/> exception callbacks.
    /// </summary>
    [Guid("2E6F28C1-85EB-4141-80AD-0A90944B9639")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugProcess8
    {
        /// <summary>
        /// [Supported in the .NET Framework 4.6 and later versions] Enables or disables certain types of <see cref="ICorDebugManagedCallback2"/> exception callbacks.
        /// </summary>
        /// <param name="enableExceptionsOutsideOfJMC">[in]</param>
        /// <remarks>
        /// If the value of enableExceptionsOutsideOfJMC is false: The default value of enableExceptionsOutsideOfJMC is true.
        /// </remarks>
        [PreserveSig]
        HRESULT EnableExceptionCallbacksOutsideOfMyCode(
            [In] int enableExceptionsOutsideOfJMC);
    }
}
