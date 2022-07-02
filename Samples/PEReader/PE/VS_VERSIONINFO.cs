namespace PEReader.PE
{
    public class VS_VERSIONINFO
    {
        public ushort Length;
        public ushort ValueLength;
        public ushort Type;
        public string Key;
        public ushort Padding1;
        public VS_FIXEDFILEINFO Value;

        //VS_VERSIONINFO is a variable length structure. Only the core fields are defined
        //Don't know how to handle Padding2 and Children if ValueLength is 0, since then
        //we won't have Value either.
        //public ushort Padding2;
        //public ushort Children;

        internal VS_VERSIONINFO(PEBinaryReader reader)
        {
            Length = reader.ReadUInt16();
            ValueLength = reader.ReadUInt16();

            Type = reader.ReadUInt16();
            Key = reader.ReadUnicodeString(16); //VS_VERSION_INFO + \0
            Padding1 = reader.ReadUInt16();
            Value = new VS_FIXEDFILEINFO(reader);
        }
    }
}