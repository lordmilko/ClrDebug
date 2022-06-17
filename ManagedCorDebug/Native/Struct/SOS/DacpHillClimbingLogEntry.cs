using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("TickCount = {TickCount}, Transition = {Transition}, NewControlSetting = {NewControlSetting}, LastHistoryCount = {LastHistoryCount}, LastHistoryMean = {LastHistoryMean}")]
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
