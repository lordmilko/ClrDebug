using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions] Provides a method that configures the debugger to handle in-memory metadata updates in the target process.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9B2C54E4-119F-4D6F-B402-527603266D69")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugProcess7
    {
        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Configures how the debugger handles in-memory updates to metadata within the target process.
        /// </summary>
        /// <param name="flags">A <see cref="WriteableMetadataUpdateMode"/> enumeration value that specifies whether in-memory updates to metadata in the target process are visible (WriteableMetadataUpdateMode::AlwaysShowUpdates) or not visible (WriteableMetadataUpdateMode::LegacyCompatPolicy) to the debugger.</param>
        /// <remarks>
        /// Updates to the metadata of the target process can come from Edit and Continue, a profiler, or <see cref="System.Reflection.Emit"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT SetWriteableMetadataUpdateMode(
            [In] WriteableMetadataUpdateMode flags);
    }
}
