using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("wNumInstanceFields = {wNumInstanceFields}, wNumStaticFields = {wNumStaticFields}, wNumThreadStaticFields = {wNumThreadStaticFields}, FirstField = {FirstField.ToString(),nq}, wContextStaticOffset = {wContextStaticOffset}, wContextStaticsSize = {wContextStaticsSize}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpMethodTableFieldData
    {
        public ushort wNumInstanceFields;
        public ushort wNumStaticFields;
        public ushort wNumThreadStaticFields;
        public CLRDATA_ADDRESS FirstField;
        public ushort wContextStaticOffset;
        public ushort wContextStaticsSize;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetMethodTableFieldData(addr, out this);
        }
    }
}
