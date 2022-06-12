using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides functions for the Edit and Continue feature.
    /// </summary>
    [Guid("E502D2DD-8671-4338-8F2A-FC08229628C4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedENCUpdate
    {
        /// <summary>
        /// Allows a compiler to omit functions that have not been modified from the program database (PDB) stream, provided the line information meets the requirements.<para/>
        /// The correct line information can be determined with the old PDB line information and one delta for all lines in the function.
        /// </summary>
        /// <param name="pIStream">[in] A pointer to an <see cref="IStream"/> that contains the line information.</param>
        /// <param name="pDeltaLines">[in] A pointer to a <see cref="SYMLINEDELTA"/> structure that contains the lines that have changed.</param>
        /// <param name="cDeltaLines">[in] A ULONG that represents the number of lines that have changed.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UpdateSymbolStore2([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream, [In] ref SYMLINEDELTA pDeltaLines, [In] int cDeltaLines);

        /// <summary>
        /// Gets the number of local variables.
        /// </summary>
        /// <param name="mdMethodToken">[in] The metadata token of methods.</param>
        /// <param name="pcLocals">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the number of local variables.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLocalVariableCount([In] mdMethodDef mdMethodToken, out int pcLocals);

        /// <summary>
        /// Gets the local variables.
        /// </summary>
        /// <param name="mdMethodToken">[in] The metadata token of the method.</param>
        /// <param name="cLocals">[in] A ULONG that indicates the size of the rgLocals parameter.</param>
        /// <param name="rgLocals">[out] The returned array of <see cref="ISymUnmanagedVariable"/> instances.</param>
        /// <param name="pceltFetched">[out] A pointer to a ULONG that receives the size of the rgLocals buffer required to contain the locals.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLocalVariables(
            [In] mdMethodDef mdMethodToken,
            [In] int cLocals,
            [Out] IntPtr rgLocals, //ISymUnmanagedVariable
            out int pceltFetched);

        /// <summary>
        /// Allows method boundaries to be computed before the first call to the <see cref="UpdateSymbolStore2"/> method.
        /// </summary>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT InitializeForEnc();

        /// <summary>
        /// Allows updating the line information for a method that has not been recompiled, but whose lines have moved independently.<para/>
        /// A delta for each statement is allowed.
        /// </summary>
        /// <param name="mdMethodToken">[in] The metadata of the method token.</param>
        /// <param name="pDeltas">[in] An array of INT32 values that indicates deltas for each sequence point in the method.</param>
        /// <param name="cDeltas">[in] A ULONG containing the size of the pDeltas parameter.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UpdateMethodLines([In] mdMethodDef mdMethodToken, [In] ref int pDeltas, [In] int cDeltas);
    }
}