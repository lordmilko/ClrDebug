using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Represents and provides information about an application domain.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D6315C8F-5A6A-11D3-8F84-00A0C9B4D50C")]
    [ComImport]
    public interface ICorPublishAppDomain
    {
        /// <summary>
        /// Gets the unique identifier for this <see cref="ICorPublishAppDomain"/>.
        /// </summary>
        /// <param name="puId">[out] A pointer to the identifier of the application domain.</param>
        /// <remarks>
        /// The identifier is unique only in the scope of the containing process.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetID(
            [Out] out int puId);

        /// <summary>
        /// Gets the name of the application domain that is represented by this <see cref="ICorPublishAppDomain"/>.
        /// </summary>
        /// <param name="cchName">[in] The size of the szName array.</param>
        /// <param name="pcchName">[out] A pointer to the number of wide characters, including the null character, returned in the szName array.</param>
        /// <param name="szName">[out] An array in which to store the name.</param>
        /// <remarks>
        /// If szName is non-null, the GetName method copies up to cchName characters (including the null terminator) into
        /// szName. If a non-null is returned in pcchName, the actual number of characters in the name (including the null
        /// terminator) is stored in the szName array. The GetName method returns an S_OK HRESULT regardless of how many characters
        /// were copied.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName(
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);
    }
}
