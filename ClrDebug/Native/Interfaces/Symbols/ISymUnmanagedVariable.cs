using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Represents a variable, such as a parameter, a local variable, or a field.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9F60EEBE-2D9A-3F7C-BF58-80BC991C60BB")]
    [ComImport]
    public interface ISymUnmanagedVariable
    {
        /// <summary>
        /// Gets the name of this variable.
        /// </summary>
        /// <param name="cchName">[in] The length of the buffer that the pcchName parameter points to.</param>
        /// <param name="pcchName">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the name, including the null termination.</param>
        /// <param name="szName">[out] The buffer that stores the name.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName(
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);

        /// <summary>
        /// Gets the attribute flags for this variable.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the attributes. The returned value will be one of the values defined in the <see cref="CorSymVarFlag"/> enumeration.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAttributes(
            [Out] out CorSymVarFlag pRetVal);

        /// <summary>
        /// Gets the signature of this variable.
        /// </summary>
        /// <param name="cSig">[in] The length of the buffer pointed to by the sig parameter.</param>
        /// <param name="pcSig">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the signature.</param>
        /// <param name="sig">[out] The buffer that stores the signature.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSignature(
            [In] int cSig,
            [Out] out int pcSig,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Out] byte[] sig);

        /// <summary>
        /// Gets the kind of address of this variable.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the value. The possible values are defined in the <see cref="CorSymAddrKind"/> enumeration.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAddressKind(
            [Out] out CorSymAddrKind pRetVal);

        /// <summary>
        /// Gets the first address field for this variable. Its meaning depends on the kind of address.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the first address field.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAddressField1(
            [Out] out int pRetVal);

        /// <summary>
        /// Gets the second address field for this variable. Its meaning depends on the kind of address.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the second address field.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAddressField2(
            [Out] out int pRetVal);

        /// <summary>
        /// Gets the third address field for this variable. Its meaning depends on the kind of address.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the third address field.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAddressField3(
            [Out] out int pRetVal);

        /// <summary>
        /// Gets the start offset of this variable within its parent. If this is a local variable within a scope, the start offset will fall within the offsets defined for the scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the start offset.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetStartOffset(
            [Out] out int pRetVal);

        /// <summary>
        /// Gets the end offset of this variable within its parent. If this is a local variable within a scope, the end offset will fall within the offsets defined for the scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the end offset.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetEndOffset(
            [Out] out int pRetVal);
    }
}
