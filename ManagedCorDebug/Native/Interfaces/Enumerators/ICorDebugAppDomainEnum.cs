using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides the Next method, which returns a specified number of <see cref="ICorDebugAppDomainEnum"/> values starting at the next location in the enumeration.<para/>
    /// This interface is a subclass of "ICorDebugEnum".
    /// </summary>
    [Guid("63CA1B24-4359-4883-BD57-13F815F58744")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugAppDomainEnum : ICorDebugEnum
    {
        /// <summary>
        /// Moves the cursor forward in the enumeration by the specified number of items.
        /// </summary>
        /// <param name="celt">[in] The number of items by which to move the cursor forward.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Skip([In] int celt);

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
        new HRESULT Clone([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugEnum ppEnum);

        /// <summary>
        /// Gets the number of items in the enumeration.
        /// </summary>
        /// <param name="pcelt">[out] A pointer to the number of items in the enumeration.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCount([Out] out int pcelt);

        /// <summary>
        /// Gets the specified number of application domains from the collection, starting at the current cursor position.
        /// </summary>
        /// <param name="celt">[in] The number of application domains to be retrieved.</param>
        /// <param name="values">[out] An array of pointers, each of which points to an <see cref="ICorDebugAppDomain"/> object that represents an application domain.</param>
        /// <param name="pceltFetched">[out] A pointer to the number of application domains actually returned. This value may be null if celt is one.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next([In] int celt, [MarshalAs(UnmanagedType.Interface), Out] out ICorDebugAppDomain values, [Out] out int pceltFetched);
    }
}