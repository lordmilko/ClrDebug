using System;

namespace ManagedCorDebug
{
    public struct GetMetadataResult
    {
        public IntPtr Buffer { get; }

        public uint DataSize { get; }

        public GetMetadataResult(IntPtr buffer, uint dataSize)
        {
            Buffer = buffer;
            DataSize = dataSize;
        }
    }
}