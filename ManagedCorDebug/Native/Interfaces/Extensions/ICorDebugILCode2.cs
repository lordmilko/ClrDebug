using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions] Logically extends the <see cref="ICorDebugILCode"/> interface to provide methods that return the token for a function's local variable signature, and that map a profiler's instrumented intermediate language (IL) offsets to original method IL offsets.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("46586093-D3F5-4DB6-ACDB-955BCE228C15")]
    [ComImport]
    public interface ICorDebugILCode2
    {
        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets the metadata token for the local variable signature for the function that is represented by this instance.
        /// </summary>
        /// <param name="pmdSig">[out] A pointer to the mdSignature token for the local variable signature for this function, or mdSignatureNil if there is no signature (that is, if the function doesn't have any local variables).</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLocalVarSigToken(out mdSignature pmdSig);

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Returns a map from profiler-instrumented intermediate language (IL) offsets to original method IL offsets for this instance.
        /// </summary>
        /// <param name="cMap">[in] The storage capacity of the map array. See the Remarks section for more information.</param>
        /// <param name="pcMap">[out] The number of COR_IL_MAP values written to the map array.</param>
        /// <param name="map">[out] An array of COR_IL_MAP values that provide information on mappings from profiler-instrumented IL to the IL of the original method.</param>
        /// <remarks>
        /// If the profiler sets the mapping by calling the ICorProfilerInfo.SetILInstrumentedCodeMap method, the debugger
        /// can call this method to retrieve the mapping and to use the mapping internally when calculating IL offsets for
        /// stack traces and variable lifetimes. If cMap is 0 and pcMap is non-null, pcMap is set to the number of available
        /// COR_IL_MAP values. If cMap is non-zero, it represents the storage capacity of the map array. When the method returns,
        /// map contains a maximum of cMap items, and pcMap is set to the number of COR_IL_MAP values actually written to the
        /// map array. If the IL hasn't been instrumented or the mapping wasn't provided by a profiler, this method returns
        /// S_OK and sets pcMap to 0.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetInstrumentedILMap([In] uint cMap, out uint pcMap, [MarshalAs(UnmanagedType.LPArray), Out] COR_IL_MAP[] map);
    }
}