using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("AppDomain = {AppDomain.ToString(),nq}, Handle = {Handle.ToString(),nq}, Secondary = {Secondary.ToString(),nq}, Type = {Type}, StrongReference = {StrongReference}, RefCount = {RefCount}, JupiterRefCount = {JupiterRefCount}, IsPegged = {IsPegged}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SOSHandleData
    {
        public CLRDATA_ADDRESS AppDomain;
        public CLRDATA_ADDRESS Handle;
        public CLRDATA_ADDRESS Secondary;
        public int Type;
        public int StrongReference;
        public int RefCount;
        public int JupiterRefCount;
        public int IsPegged;
    }
}
