using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("codeHeapType = {codeHeapType}, LoaderHeap = {LoaderHeap.ToString(),nq}, baseAddr = {baseAddr.ToString(),nq}, currentAddr = {currentAddr.ToString(),nq}")]
    [StructLayout(LayoutKind.Explicit)]
    public struct DacpJitCodeHeapInfo
    {
        [FieldOffset(0)]
        public int codeHeapType;

        //if CODEHEAP_LOADER

        [FieldOffset(4)]
        public CLRDATA_ADDRESS LoaderHeap;

        //if CODEHEAP_HOST

        [FieldOffset(4)]
        public CLRDATA_ADDRESS baseAddr;

        [FieldOffset(8)]
        public CLRDATA_ADDRESS currentAddr;
    }
}
