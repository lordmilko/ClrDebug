using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides a method that enables a debugger to enumerate the local variables and arguments in a function.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("18221FA4-20CB-40FA-B19D-9F91C4FA8C14")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugCode4
    {
        /// <summary>
        /// Gets an enumerator to the local variables and arguments in a function.
        /// </summary>
        /// <param name="ppEnum">A pointer to the address of an <see cref="ICorDebugVariableHomeEnum"/> interface object that is an enumerator for the local variables and arguments in a function.</param>
        /// <remarks>
        /// The <see cref="ICorDebugVariableHomeEnum"/> interface object is a standard enumerator derived from the "ICorDebugEnum"
        /// interface that allows you to enumerate <see cref="ICorDebugVariableHome"/> objects. The collection may include
        /// multiple <see cref="ICorDebugVariableHome"/> objects for the same slot or argument index if they have different
        /// homes at different points in the function.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateVariableHomes(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugVariableHomeEnum ppEnum);
    }
}
