using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("cb = {cb}, MajorRuntimeVersion = {MajorRuntimeVersion}, MinorRuntimeVersion = {MinorRuntimeVersion}, MetaData = {MetaData.ToString(),nq}, Flags = {Flags.ToString(),nq}, EntryPointTokenOrRVA = {EntryPointTokenOrRVA}, Resources = {Resources.ToString(),nq}, StrongNameSignature = {StrongNameSignature.ToString(),nq}, CodeManagerTable = {CodeManagerTable.ToString(),nq}, VTableFixups = {VTableFixups.ToString(),nq}, ExportAddressTableJumps = {ExportAddressTableJumps.ToString(),nq}, ManagedNativeHeader = {ManagedNativeHeader.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_COR20_HEADER
    {
        // Header versioning
        public int cb;
        public ushort MajorRuntimeVersion;
        public ushort MinorRuntimeVersion;

        // Symbol table and startup information
        public IMAGE_DATA_DIRECTORY MetaData;
        public COMIMAGE_FLAGS Flags;

        // The main program if it is an EXE (not used if a DLL?)
        // If COMIMAGE_FLAGS_NATIVE_ENTRYPOINT is not set, EntryPointToken represents a managed entrypoint.
        // If COMIMAGE_FLAGS_NATIVE_ENTRYPOINT is set, EntryPointRVA represents an RVA to a native entrypoint
        // (deprecated for DLLs, use modules constructors instead).
        public int EntryPointTokenOrRVA;

        // This is the blob of managed resources. Fetched using code:AssemblyNative.GetResource and
        // code:PEAssembly.GetResource and accessible from managed code from
        // System.Assembly.GetManifestResourceStream.  The meta data has a table that maps names to offsets into
        // this blob, so logically the blob is a set of resources.
        public IMAGE_DATA_DIRECTORY Resources;
        // IL assemblies can be signed with a public-private key to validate who created it.  The signature goes
        // here if this feature is used.
        public IMAGE_DATA_DIRECTORY StrongNameSignature;

        public IMAGE_DATA_DIRECTORY CodeManagerTable; // Deprecated, not used
        // Used for manged code that has unmanaged code inside it (or exports methods as unmanaged entry points)
        public IMAGE_DATA_DIRECTORY VTableFixups;
        public IMAGE_DATA_DIRECTORY ExportAddressTableJumps;

        // null for ordinary IL images.
        // In Ready2Run images it points to a READYTORUN_HEADER.
        public IMAGE_DATA_DIRECTORY ManagedNativeHeader;
    }
}
