using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Implements "ICorDebugEnum" methods, and enumerates "ICorDebugCode" arrays.
    /// </summary>
    [Guid("55E96461-9645-45E4-A2FF-0367877ABCDE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugCodeEnum : ICorDebugEnum
    {
        /// <summary>
        /// Moves the cursor forward in the enumeration by the specified number of items.
        /// </summary>
        /// <param name="celt">[in] The number of items by which to move the cursor forward.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Skip(
            [In] int celt);

        /// <summary>
        /// Moves the cursor to the beginning of the enumeration.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Reset();

        /// <summary>
        /// Creates a copy of this <see cref="ICorDebugEnum"/> object.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to the address of an <see cref="ICorDebugEnum"/> object that is a copy of this <see cref="ICorDebugEnum"/> object.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugEnum ppEnum);

        /// <summary>
        /// Gets the number of items in the enumeration.
        /// </summary>
        /// <param name="pcelt">[out] A pointer to the number of items in the enumeration.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCount(
            [Out] out int pcelt);

        /// <summary>
        /// Gets the specified number of "ICorDebugCode" instances from the enumeration, starting at the current position.
        /// </summary>
        /// <param name="celt">[in] The number of <see cref="ICorDebugCode"/> instances to be retrieved.</param>
        /// <param name="values">[out] An array of pointers, each of which points to an <see cref="ICorDebugCode"/> object.</param>
        /// <param name="pceltFetched">[out] A pointer to the number of <see cref="ICorDebugCode"/> instances actually returned. This value may be null if celt is one.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next(
            [In] int celt,
            [MarshalAs(UnmanagedType.Interface), Out] out ICorDebugCode values,
            [Out] out int pceltFetched);
    }
}
