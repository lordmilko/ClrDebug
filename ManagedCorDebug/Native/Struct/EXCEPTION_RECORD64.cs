using System.Runtime.InteropServices;
namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct EXCEPTION_RECORD64
	{
		public int ExceptionCode;
		public int ExceptionFlags;
		public long ExceptionRecord;
		public long ExceptionAddress;
		public int NumberParameters;
		public int __unusedAlignment;
		public fixed ulong ExceptionInformation[15];
	}
}
