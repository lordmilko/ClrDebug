using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

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
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugInstanceFieldSymbol
    {
        /// <summary>
        /// Gets the name of the instance field.
        /// </summary>
        /// <param name="cchName">[in] The number of characters in the szName buffer.</param>
        /// <param name="pcchName">[out] A pointer to the number of characters actually written to the szName buffer.</param>
        /// <param name="szName">[out] A character array that stores the returned name.</param>
        [PreserveSig]
        HRESULT GetName(
            [In] int cchName,
            [Out] out int pcchName,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);

        /// <summary>
        /// Gets the size in bytes of the instance field.
        /// </summary>
        /// <param name="pcbSize">[out] A pointer to length of the field.</param>
        [PreserveSig]
        HRESULT GetSize(
            [Out] out int pcbSize);

        /// <summary>
        /// Gets the offset in bytes of this instance field in its parent class.
        /// </summary>
        /// <param name="pcbOffset">A pointer to the number of bytes that this instance field is offset in its parent class.</param>
        [PreserveSig]
        HRESULT GetOffset(
            [Out] out int pcbOffset);
    }
}
