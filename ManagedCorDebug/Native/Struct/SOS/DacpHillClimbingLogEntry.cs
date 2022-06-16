using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpHillClimbingLogEntry
	{
		public int TickCount;
		public int Transition;
		public int NewControlSetting;
		public int LastHistoryCount;
		public double LastHistoryMean;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS entry)
        {
            return sos.GetHillClimbingLogEntry(entry, out this);
        }
    }
}
