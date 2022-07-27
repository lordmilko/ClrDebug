using System.Collections.Specialized;

namespace ClrDebug.DbgEng
{
    public struct DumpSymbolInfoResult
    {
        public long ModBase { get; }

        public int TypeId { get; }

        public int TypeSize { get; }

        public BitVector32 Flags { get; }

        public DumpSymbolInfoResult(long modbase, int typeId, int typeSize, BitVector32 flags)
        {
            ModBase = modbase;
            TypeId = typeId;
            TypeSize = typeSize;
            Flags = flags;
        }
    }
}
