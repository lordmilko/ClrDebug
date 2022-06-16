using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
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
