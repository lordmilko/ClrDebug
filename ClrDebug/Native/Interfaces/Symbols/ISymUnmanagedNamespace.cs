using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Represents a namespace.
    /// </summary>
    [Guid("0DFF7289-54F8-11D3-BD28-0000F80849BD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISymUnmanagedNamespace
    {
        /// <summary>
        /// Gets the name of this namespace.
        /// </summary>
        /// <param name="cchName">[in] A ULONG32 that indicates the size of the szName buffer.</param>
        /// <param name="pcchName">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the namespace name, including the null termination.</param>
        /// <param name="szName">[out] A pointer to a buffer that contains the namespace name.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT GetName(
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);

        /// <summary>
        /// Gets the children of this namespace.
        /// </summary>
        /// <param name="cNameSpaces">[in] A ULONG32 that indicates the size of the namespaces array.</param>
        /// <param name="pcNameSpaces">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the namespaces.</param>
        /// <param name="namespaces">[out] A pointer to the buffer that contains the namespaces.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT GetNamespaces(
            [In] int cNameSpaces,
            [Out] out int pcNameSpaces,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Out] ISymUnmanagedNamespace[] namespaces);

        /// <summary>
        /// Returns all variables defined at global scope within this namespace.
        /// </summary>
        /// <param name="cVars">[in] A ULONG32 that indicates the size of the pVars array.</param>
        /// <param name="pcVars">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the namespaces.</param>
        /// <param name="pVars">[out] A pointer to a buffer that contains the namespaces.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT GetVariables(
            [In] int cVars,
            [Out] out int pcVars,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedVariable[] pVars);
    }
}
