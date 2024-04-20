using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("CanonicalId = {CanonicalId}, DataOffset = {DataOffset}, DataSize = {DataSize}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct RegisterInformationQuery
    {
        public int CanonicalId;
        public int DataOffset;
        public int DataSize;
    }
}
