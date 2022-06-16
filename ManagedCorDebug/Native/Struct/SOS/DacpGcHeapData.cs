using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpGcHeapData
	{
		public int bServerMode;
		public int bGcStructuresValid;
		public int HeapCount;
		public int g_max_generation;

        public HRESULT Request(ISOSDacInterface sos)
        {
            return sos.GetGCHeapData(out this);
        }
    }
}
