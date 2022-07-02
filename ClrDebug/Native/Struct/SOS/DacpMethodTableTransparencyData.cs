using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("bHasCriticalTransparentInfo = {bHasCriticalTransparentInfo}, bIsCritical = {bIsCritical}, bIsTreatAsSafe = {bIsTreatAsSafe}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpMethodTableTransparencyData
    {
        public bool bHasCriticalTransparentInfo;
        public bool bIsCritical;
        public bool bIsTreatAsSafe;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetMethodTableTransparencyData(addr, out this);
        }
    }
}
