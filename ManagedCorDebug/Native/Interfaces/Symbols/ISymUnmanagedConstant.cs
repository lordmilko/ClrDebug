using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides access to unmanaged constants.
    /// </summary>
    [Guid("48B25ED8-5BAD-41BC-9CEE-CD62FABC74E9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedConstant
    {
        /// <summary>
        /// Gets the name of the constant.
        /// </summary>
        /// <param name="cchName">[in] The length of the buffer that the szName parameter points to.</param>
        /// <param name="pcchName">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the name, including the null termination.</param>
        /// <param name="szName">[out] The buffer that stores the name.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName([In] uint cchName, out uint pcchName, [Out] StringBuilder szName);

        /// <summary>
        /// Gets the value of the constant.
        /// </summary>
        /// <param name="pValue">[out] A pointer to a variable that receives the value.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetValue([MarshalAs(UnmanagedType.Struct)] ref object pValue);

        /// <summary>
        /// Gets the signature of the constant.
        /// </summary>
        /// <param name="cSig">[in] The length of the buffer that the pcSig parameter points to.</param>
        /// <param name="pcSig">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the signature.</param>
        /// <param name="sig">[out] The buffer that stores the signature.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSignature([In] uint cSig, out uint pcSig, [MarshalAs(UnmanagedType.LPArray), Out] byte[] sig);
    }
}