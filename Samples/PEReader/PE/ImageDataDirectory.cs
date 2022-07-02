using System.Diagnostics;

namespace PEReader.PE
{
    /// <summary>
    /// Describes the location and size of a data directory that may exist in the image.<para/>
    /// Not to be confused with <see cref="ImageDebugDirectory"/>, which represents an entry within
    /// _the_ debug directory region that may be pointed to by a given <see cref="ImageDataDirectory"/>.
    /// </summary>
    [DebuggerDisplay("RVA = {RelativeVirtualAddress}, Size = {Size}")]
    public struct ImageDataDirectory
    {
        public readonly int RelativeVirtualAddress;
        public readonly int Size;

        internal ImageDataDirectory(PEBinaryReader reader)
        {
            RelativeVirtualAddress = reader.ReadInt32();
            Size = reader.ReadInt32();
        }
    }
}
