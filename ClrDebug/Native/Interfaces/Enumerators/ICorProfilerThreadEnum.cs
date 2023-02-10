using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods to sequentially iterate through a collection of threads in the common language runtime.
    /// </summary>
    /// <remarks>
    /// The ICorProfilerThreadEnum interface is an enumerator. It allows the receiver of an array to pull elements from
    /// the sender at a rate that is appropriate for the receiver. In other words, the receiver is able to explicitly control
    /// the flow of array elements, thereby avoiding the problems associated with passing large arrays as method parameters.
    /// </remarks>
    [Guid("571194F7-25ED-419F-AA8B-7016B3159701")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorProfilerThreadEnum
    {
        /// <summary>
        /// Advances the enumerator's cursor from its current position to skip the specified number of elements.
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
        /// Gets an interface pointer to a copy of this <see cref="ICorProfilerThreadEnum"/> interface.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to the interface pointer, which, in turn, points to the copy of this <see cref="ICorProfilerThreadEnum"/> interface.<para/>
        /// The copy of the enumerator maintains its own enumeration state separately from this enumerator. However, the initial cursor position of the copy is the same as this current cursor position of the enumerator.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorProfilerThreadEnum ppEnum);

        /// <summary>
        /// Gets the number of threads that are used by the application.
        /// </summary>
        /// <param name="pcelt">[out] The number of threads used by the application.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCount(
            [Out] out int pcelt);

        /// <summary>
        /// Gets the specified number of contiguous threads from a sequential collection of threads, starting at the enumerator's current position in the sequence.
        /// </summary>
        /// <param name="celt">[in] The number of threads to retrieve.</param>
        /// <param name="ids">[out] An array of ThreadID values, each of which represents a retrieved thread.</param>
        /// <param name="pceltFetched">[out] A pointer to the number of threads actually returned in the ids array.</param>
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
            [Out] out ThreadID ids,
            [Out] out int pceltFetched);
    }
}
