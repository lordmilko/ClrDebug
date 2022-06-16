using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct GcEvtArgs
	{
		public GcEvt_t Typ;
		public int CondemnedGeneration;
	}
}
