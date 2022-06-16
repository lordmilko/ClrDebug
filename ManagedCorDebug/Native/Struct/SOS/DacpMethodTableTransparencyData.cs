using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpMethodTableTransparencyData
	{
		public int bHasCriticalTransparentInfo;
		public int bIsCritical;
		public int bIsTreatAsSafe;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetMethodTableTransparencyData(addr, out this);
        }
    }
}
