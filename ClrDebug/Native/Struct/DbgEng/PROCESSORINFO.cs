using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("Processor = {Processor}, NumberProcessors = {NumberProcessors}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESSORINFO
    {
        ushort Processor;                // current processor
        ushort NumberProcessors;         // total number of processors
    }
}
