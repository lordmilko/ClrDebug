using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RegisterInformationQuery
    {
        public int CanonicalId;
        public int DataOffset;
        public int DataSize;
    }
}
