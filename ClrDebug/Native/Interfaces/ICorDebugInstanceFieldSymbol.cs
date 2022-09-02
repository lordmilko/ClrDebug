using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Represents the debug symbol information for an instance field.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugInstanceFieldSymbol"/> interface is used to retrieve the debug symbol information for an instance field.
    /// </remarks>
    [Guid("A074096B-3ADC-4485-81DA-68C7A4EA52DB")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugInstanceFieldSymbol
    {
        /// <summary>
        /// Gets the name of the instance field.
        /// </summary>
        /// <param name="cchName">[in] The number of characters in the szName buffer.</param>
        /// <param name="pcchName">[out] A pointer to the number of characters actually written to the szName buffer.</param>
        /// <param name="szName">[out] A character array that stores the returned name.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName(
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);

        /// <summary>
        /// Gets the size in bytes of the instance field.
        /// </summary>
        /// <param name="pcbSize">[out] A pointer to length of the field.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSize(
            [Out] out int pcbSize);

        /// <summary>
        /// Gets the offset in bytes of this instance field in its parent class.
        /// </summary>
        /// <param name="pcbOffset">A pointer to the number of bytes that this instance field is offset in its parent class.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetOffset(
            [Out] out int pcbOffset);
    }
}
