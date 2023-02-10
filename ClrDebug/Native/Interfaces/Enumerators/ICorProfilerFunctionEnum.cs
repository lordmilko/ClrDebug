using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods to sequentially iterate through a collection of functions in the common language runtime.
    /// </summary>
    /// <remarks>
    /// The ICorProfilerFunctionEnum interface is an enumerator. It allows the receiver of an array to pull elements from
    /// the sender at a rate that is appropriate for the receiver. In other words, the receiver is able to explicitly control
    /// the flow of array elements, thereby avoiding the problems associated with passing large arrays as method parameters.
    /// ICorProfilerFunctionEnum enumerates over functions that have already been JIT-compiled, but does not include functions
    /// that are loaded from native images generated with Ngen.exe.
    /// </remarks>
    [Guid("FF71301A-B994-429D-A10B-B345A65280EF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorProfilerFunctionEnum
    {
        /// <summary>
        /// Advances the enumerator's cursor from its current position so that the specified number of elements are skipped.
        /// </summary>
        /// <param name="celt">[in] The number of elements to be skipped.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                                                                             |
        /// | ------- | --------------------------------------------------------------------------------------- |
        /// | S_OK    | celt elements were skipped.                                                             |
        /// | S_FALSE | Fewer than celt elements were skipped, which indicates that there are no more elements. |
        /// </returns>
        /// <remarks>
        /// The new position of this enumerator's cursor is (current position) + celt.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Skip(
            [In] int celt);

        /// <summary>
        /// Moves the enumerator's cursor to the starting position of the sequence.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Reset();

        /// <summary>
        /// Gets an interface pointer to a copy of this <see cref="ICorProfilerFunctionEnum"/> interface.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to the interface pointer, which, in turn, points to the copy of this <see cref="ICorProfilerFunctionEnum"/> interface.<para/>
        /// The copy of the enumerator maintains its own enumeration state separately from this enumerator. However, the copy's initial cursor position is the same as this enumerator's current cursor position.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorProfilerFunctionEnum ppEnum);

        /// <summary>
        /// Gets the number of functions that were loaded by the application or forcibly loaded by the profiler.
        /// </summary>
        /// <param name="pcelt">[out] The number of functions that were loaded.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCount(
            [Out] out int pcelt);

        /// <summary>
        /// Gets the specified number of contiguous functions from a sequential collection of functions, starting at the enumerator's current position in the sequence.
        /// </summary>
        /// <param name="celt">[in] The number of functions to retrieve.</param>
        /// <param name="ids">[out] An array of COR_PRF_FUNCTION values, each of which represents a retrieved function.</param>
        /// <param name="pceltFetched">[out] A pointer to the number of functions actually returned in the ids array.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                                                                               |
        /// | ------- | ----------------------------------------------------------------------------------------- |
        /// | S_OK    | celt elements were returned.                                                              |
        /// | S_FALSE | Fewer than celt elements were returned, which indicates that the enumeration is complete. |
        /// </returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next(
            [In] int celt,
            [Out] out COR_PRF_FUNCTION ids,
            [Out] out int pceltFetched);
    }
}
