using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Defines the basic information about a given profiler-instrumented method.
    /// </summary>
    /// <remarks>
    /// This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define
    /// the structure as specified above. The structure must also be defined using ms_struct packing if not using the Microsoft
    /// compilers.
    /// </remarks>
    [DebuggerDisplay("rejitID = {rejitID.ToString(),nq}, flags = {flags.ToString(),nq}, NativeCodeAddr = {NativeCodeAddr.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpReJitData
    {
        /// <summary>
        /// The ReJit revision number for a method.
        /// </summary>
        public CLRDATA_ADDRESS rejitID;

        /// <summary>
        /// A flag indicating the current state of the method's ReJit instrumentation for the given version.
        /// </summary>
        public DacpReJitDataFlags flags;

        /// <summary>
        /// The base address of the method's rejitted implementation.
        /// </summary>
        public CLRDATA_ADDRESS NativeCodeAddr;
    }
}
