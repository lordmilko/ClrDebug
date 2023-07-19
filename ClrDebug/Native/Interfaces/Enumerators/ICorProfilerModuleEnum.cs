using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides methods to sequentially iterate through a collection of modules loaded by the application or the profiler.
    /// </summary>
    /// <remarks>
    /// The ICorProfilerModuleEnum interface is an enumerator. It allows the receiver of an array to pull elements from
    /// the sender at a rate that is appropriate for the receiver. In other words, the receiver is able to explicitly control
    /// the flow of array elements, thereby avoiding the problems associated with passing large arrays as method parameters.
    /// </remarks>
    [Guid("B0266D75-2081-4493-AF7F-028BA34DB891")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorProfilerModuleEnum
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
        HRESULT Skip(
            [In] int celt);

        /// <summary>
        /// Moves this enumerator's cursor to the starting position of the sequence.
        /// </summary>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Gets an interface pointer to a copy of this <see cref="ICorProfilerModuleEnum"/> interface.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to the interface pointer that in turn points to the copy of this <see cref="ICorProfilerModuleEnum"/> interface.<para/>
        /// The copy of the enumerator maintains its own enumeration state separately from this enumerator. However, the copy's initial cursor position is the same as this enumerator's current cursor position.</param>
        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorProfilerModuleEnum ppEnum);

        /// <summary>
        /// Gets the number of managed modules that were loaded into the application.
        /// </summary>
        /// <param name="pcelt">[out] The number of runtime modules in the collection.</param>
        [PreserveSig]
        HRESULT GetCount(
            [Out] out int pcelt);

        /// <summary>
        /// Gets the specified number of contiguous modules from a sequential collection of modules, starting at the enumerator's current position in the sequence.
        /// </summary>
        /// <param name="celt">[in] The number of modules to retrieve.</param>
        /// <param name="ids">[out] An array of ModuleID values, each of which represents a retrieved module.</param>
        /// <param name="pceltFetched">[out] A pointer to the number of elements actually returned in the ids array.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                                                                               |
        /// | ------- | ----------------------------------------------------------------------------------------- |
        /// | S_OK    | celt elements were returned.                                                              |
        /// | S_FALSE | Fewer than celt elements were returned, which indicates that the enumeration is complete. |
        /// </returns>
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [Out] out ModuleID ids,
            [Out] out int pceltFetched);
    }
}
