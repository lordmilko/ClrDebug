using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions]<para/>
    /// Logically extends the <see cref="ICorDebugILCode"/> interface to provide methods that return the token for a function's local variable signature, and that map a profiler's instrumented intermediate language (IL) offsets to original method IL offsets.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("46586093-D3F5-4DB6-ACDB-955BCE228C15")]
    [ComImport]
    public interface ICorDebugILCode2
    {
        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions]<para/>
        /// Gets the metadata token for the local variable signature for the function that is represented by this instance.
        /// </summary>
        /// <param name="pmdSig">[out] A pointer to the mdSignature token for the local variable signature for this function, or mdSignatureNil if there is no signature (that is, if the function doesn't have any local variables).</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLocalVarSigToken(out uint pmdSig);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetInstrumentedILMap([In] uint cMap, out uint pcMap, [MarshalAs(UnmanagedType.LPArray), Out] COR_IL_MAP[] map);
    }
}