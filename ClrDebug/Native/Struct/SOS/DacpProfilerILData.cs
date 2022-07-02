using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("Type = {Type.ToString(),nq}, il = {il.ToString(),nq}, rejitID = {rejitID}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpProfilerILData
    {
        public ModificationType Type;
        public CLRDATA_ADDRESS il;
        public int rejitID;
    }
}
