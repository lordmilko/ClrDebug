using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESSORINFO
    {
        ushort Processor;                // current processor
        ushort NumberProcessors;         // total number of processors
    }
}