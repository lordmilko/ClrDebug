using System;

namespace ManagedCorDebug
{
    public struct GetMetadataResult
    {
        public IntPtr Buffer { get; }

        public int DataSize { get; }

        public GetMetadataResult(IntPtr buffer, int dataSize)
        {
            Buffer = buffer;
            DataSize = dataSize;
        }
    }
}