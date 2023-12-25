using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides access to unmanaged constants.
    /// </summary>
    [Guid("48B25ED8-5BAD-41BC-9CEE-CD62FABC74E9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISymUnmanagedConstant
    {
        /// <summary>
        /// Gets the name of the constant.
        /// </summary>
        /// <param name="cchName">[in] The length of the buffer that the szName parameter points to.</param>
        /// <param name="pcchName">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the name, including the null termination.</param>
        /// <param name="szName">[out] The buffer that stores the name.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT GetName(
            [In] int cchName,
            [Out] out int pcchName,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);

        /// <summary>
        /// Gets the value of the constant.
        /// </summary>
        /// <param name="pValue">[out] A pointer to a variable that receives the value.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT GetValue(
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.Struct)]
#else
            [MarshalUsing(typeof(VariantMarshaller))]
#endif
            out object pValue);

        /// <summary>
        /// Gets the signature of the constant.
        /// </summary>
        /// <param name="cSig">[in] The length of the buffer that the pcSig parameter points to.</param>
        /// <param name="pcSig">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the signature.</param>
        /// <param name="sig">[out] The buffer that stores the signature.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT GetSignature(
            [In] int cSig,
            [Out] out int pcSig,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), SRI.Out] byte[] sig);
    }
}
