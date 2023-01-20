using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("AppDomain = {AppDomain.ToString(),nq}, Handle = {Handle.ToString(),nq}, Secondary = {Secondary.ToString(),nq}, Type = {Type}, StrongReference = {StrongReference}, RefCount = {RefCount}, JupiterRefCount = {JupiterRefCount}, IsPegged = {IsPegged}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SOSHandleData
    {
        public CLRDATA_ADDRESS AppDomain;
        public CLRDATA_ADDRESS Handle;
        public CLRDATA_ADDRESS Secondary;
        public HandleType Type;
        public bool StrongReference;
        public int RefCount;
        public int JupiterRefCount;
        public bool IsPegged;
    }
}
