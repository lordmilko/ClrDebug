using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("GCInfo = {GCInfo.ToString(),nq}, JITType = {JITType.ToString(),nq}, MethodDescPtr = {MethodDescPtr.ToString(),nq}, MethodStart = {MethodStart.ToString(),nq}, MethodSize = {MethodSize}, ColdRegionStart = {ColdRegionStart.ToString(),nq}, ColdRegionSize = {ColdRegionSize}, HotRegionSize = {HotRegionSize}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpCodeHeaderData
    {
        public CLRDATA_ADDRESS GCInfo;
        public JITTypes JITType;
        public CLRDATA_ADDRESS MethodDescPtr;
        public CLRDATA_ADDRESS MethodStart;
        public int MethodSize;
        public CLRDATA_ADDRESS ColdRegionStart;
        public int ColdRegionSize;
        public int HotRegionSize;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS IPAddr)
        {
            return sos.GetCodeHeaderData(IPAddr, out this);
        }
    }
}
