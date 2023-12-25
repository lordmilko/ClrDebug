using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Represents a lexical scope within a method. This interface extends the <see cref="ISymUnmanagedScope"/> interface with methods that get information about constants defined within the scope.
    /// </summary>
    [Guid("AE932FBA-3FD8-4DBA-8232-30A2309B02DB")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISymUnmanagedScope2 : ISymUnmanagedScope
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Gets the method that contains this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to the returned <see cref="ISymUnmanagedMethod"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetMethod(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod pRetVal);

        /// <summary>
        /// Gets the parent scope of this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to the returned <see cref="ISymUnmanagedScope"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetParent(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedScope pRetVal);

        /// <summary>
        /// Gets the children of this scope.
        /// </summary>
        /// <param name="cChildren">[in] A ULONG32 that indicates the size of the children array.</param>
        /// <param name="pcChildren">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the children.</param>
        /// <param name="children">[out] The returned array of children.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetChildren(
            [In] int cChildren,
            [Out] out int pcChildren,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedScope[] children);

        /// <summary>
        /// Gets the start offset for this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that contains the starting offset.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetStartOffset(
            [Out] out int pRetVal);

        /// <summary>
        /// Gets the end offset for this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the end offset.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetEndOffset(
            [Out] out int pRetVal);

        /// <summary>
        /// Gets a count of the local variables defined within this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the count of local variables.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetLocalCount(
            [Out] out int pRetVal);

        /// <summary>
        /// Gets the local variables defined within this scope.
        /// </summary>
        /// <param name="cLocals">[in] A ULONG32 that indicates the size of the locals array.</param>
        /// <param name="pcLocals">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the local variables.</param>
        /// <param name="locals">[out] The array that receives the local variables.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetLocals(
            [In] int cLocals,
            [Out] out int pcLocals,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedVariable[] locals);

        /// <summary>
        /// Gets the namespaces that are being used within this scope.
        /// </summary>
        /// <param name="cNameSpaces">[in] The size of the namespaces array.</param>
        /// <param name="pcNameSpaces">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the namespaces.</param>
        /// <param name="namespaces">[out] The array that receives the namespaces.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetNamespaces(
            [In] int cNameSpaces,
            [Out] out int pcNameSpaces,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedNamespace[] namespaces);
#endif

        /// <summary>
        /// Gets a count of the constants defined within this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the constants.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT GetConstantCount(
            [Out] out int pRetVal);

        /// <summary>
        /// Gets the local constants defined within this scope.
        /// </summary>
        /// <param name="cConstants">[in] The length of the buffer that the pcConstants parameter points to.</param>
        /// <param name="pcConstants">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the constants.</param>
        /// <param name="constants">[out] The buffer that stores the constants.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT GetConstants(
            [In] int cConstants,
            [Out] out int pcConstants,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), SRI.Out] ISymUnmanagedConstant[] constants);
    }
}
