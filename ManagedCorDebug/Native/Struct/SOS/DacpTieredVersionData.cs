using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("NativeCodeAddr = {NativeCodeAddr.ToString(),nq}, OptimizationTier = {OptimizationTier.ToString(),nq}, NativeCodeVersionNodePtr = {NativeCodeVersionNodePtr.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpTieredVersionData
    {
        public CLRDATA_ADDRESS NativeCodeAddr;
        public OptimizationTier OptimizationTier;
        public CLRDATA_ADDRESS NativeCodeVersionNodePtr;
    }
}
