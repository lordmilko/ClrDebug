using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.6 and later versions] Logically extends the <see cref="ICorDebugProcess"/> interface to enable or disable certain types of <see cref="ICorDebugManagedCallback2"/> exception callbacks.
    /// </summary>
    [Guid("2E6F28C1-85EB-4141-80AD-0A90944B9639")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugProcess8
    {
        /// <summary>
        /// [Supported in the .NET Framework 4.6 and later versions] Enables or disables certain types of <see cref="ICorDebugManagedCallback2"/> exception callbacks.
        /// </summary>
        /// <param name="enableExceptionsOutsideOfJMC">[in]</param>
        /// <remarks>
        /// If the value of enableExceptionsOutsideOfJMC is false: The default value of enableExceptionsOutsideOfJMC is true.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnableExceptionCallbacksOutsideOfMyCode([In] int enableExceptionsOutsideOfJMC);
    }
}