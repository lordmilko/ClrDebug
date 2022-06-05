using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions]<para/>
    /// Provides a method that configures the debugger to handle in-memory metadata updates in the target process.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9B2C54E4-119F-4D6F-B402-527603266D69")]
    [ComImport]
    public interface ICorDebugProcess7
    {
        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions]<para/>
        /// Configures how the debugger handles in-memory updates to metadata within the target process.
        /// </summary>
        /// <param name="flags">A <see cref="WriteableMetadataUpdateMode"/> enumeration value that specifies whether in-memory updates to metadata in the target process are visible (WriteableMetadataUpdateMode::AlwaysShowUpdates) or not visible (WriteableMetadataUpdateMode::LegacyCompatPolicy) to the debugger.</param>
        /// <remarks>
        /// Updates to the metadata of the target process can come from Edit and Continue, a profiler, or System.Reflection.Emit.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetWriteableMetadataUpdateMode(WriteableMetadataUpdateMode flags);
    }
}