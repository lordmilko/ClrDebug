using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// CodeView Debug OMF signature. The signature at the end of the file is
    /// a negative offset from the end of the file to another signature. At
    /// the negative offset (base address) is another signature whose filepos
    /// field points to the first OMFDirHeader in a chain of directories.
    /// The NB05 signature is used by the link utility to indicated a completely
    /// unpacked file. The NB06 signature is used by ilink to indicate that the
    /// executable has had CodeView information from an incremental link appended
    /// to the executable. The NB08 signature is used by cvpack to indicate that
    /// the CodeView Debug OMF has been packed. CodeView will only process
    /// executables with the NB08 signature.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct OMFSignature
    {
        /// <summary>
        /// "NBxx"
        /// </summary>
        public fixed byte Signature[4];

        /// <summary>
        /// offset in file
        /// </summary>
        public int filepos;
    }
}
