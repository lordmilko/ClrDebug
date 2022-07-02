using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides an enumerator to the local variables and arguments in a function.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugVariableHomeEnum"/> interface implements the <see cref="ICorDebugEnum"/> interface. An <see cref="ICorDebugVariableHomeEnum"/> instance
    /// is populated with <see cref="ICorDebugVariableHome"/> instances by calling the <see cref="ICorDebugCode4.EnumerateVariableHomes"/>
    /// method. Each <see cref="ICorDebugVariableHome"/> instance in the collection represents a local variable or argument
    /// in a function. The <see cref="ICorDebugVariableHome"/> objects in the collection can be enumerated by calling the
    /// <see cref="Next"/> method.
    /// </remarks>
    [Guid("E76B7A57-4F7A-4309-85A7-5D918C3DEAF7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugVariableHomeEnum : ICorDebugEnum
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
        /// Gets the specified number of <see cref="ICorDebugVariableHome"/> instances that contain information about the local variables and arguments in a function.
        /// </summary>
        /// <param name="celt">[in] The number of objects to be retrieved.</param>
        /// <param name="homes">An array of pointers, each of which points to a <see cref="ICorDebugVariableHome"/> object that provides information about a local variable or argument of a function.</param>
        /// <param name="pceltFetched">[out] The number of instances actually returned in objects.</param>
        /// <returns>
        /// The method returns the following values.
        /// 
        /// | HRESULT | Description                                                                                                             |
        /// | ------- | ----------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK    | The method completed successfully.                                                                                      |
        /// | S_FALSE | The actual number of instances retrieved, as reflected in pceltFetched, is less than the number of instances requested. |
        /// </returns>
        /// <remarks>
        /// The <see cref="Next"/> method retrieves a maximum of celt objects starting at the current position of the enumerator.
        /// When the method returns, pceltFetched contains the actual number of objects retrieved.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next(
            [In] int celt,
            [MarshalAs(UnmanagedType.Interface), Out] out ICorDebugVariableHome homes,
            [Out] out int pceltFetched);
    }
}