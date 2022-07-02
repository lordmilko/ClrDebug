using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("rejitID = {rejitID}, flags = {flags.ToString(),nq}, il = {il.ToString(),nq}, ilCodeVersionNodePtr = {ilCodeVersionNodePtr.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpReJitData2
    {
        public int rejitID;
        public DacpReJitDataFlags flags;
        public CLRDATA_ADDRESS il;
        public CLRDATA_ADDRESS ilCodeVersionNodePtr;
    }
}
