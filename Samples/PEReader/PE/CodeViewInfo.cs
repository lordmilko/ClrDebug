using System;

namespace PEReader.PE
{
    //RSDSIH has the dwSig, guidSig, and age. Path isn't part of the struct...but I guess it follows it?

    public struct CodeViewInfo
    {
        /// <summary>
        /// GUID (Globally Unique Identifier) of the associated PDB.
        /// </summary>
        public Guid Signature { get; }

        /// <summary>
        /// Iteration of the PDB. The first iteration is 1. The iteration is incremented each time the PDB content is augmented.
        /// </summary>
        public int Age { get; }

        /// <summary>
        /// Path to the .pdb file containing debug information for the PE/COFF file.
        /// </summary>
        public string Path { get; }

        internal CodeViewInfo(PEBinaryReader reader)
        {
            if (reader.ReadByte() != (byte)'R' ||
                reader.ReadByte() != (byte)'S' ||
                reader.ReadByte() != (byte)'D' ||
                reader.ReadByte() != (byte)'S')
            {
                throw new BadImageFormatException("Unexpected CodeView data signature value.");
            }

            Signature = reader.ReadGuid();
            Age = reader.ReadInt32();
            Path = reader.ReadSZString();
        }
    }
}