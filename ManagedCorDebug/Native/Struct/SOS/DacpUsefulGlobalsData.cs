using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("ArrayMethodTable = {ArrayMethodTable.ToString(),nq}, StringMethodTable = {StringMethodTable.ToString(),nq}, ObjectMethodTable = {ObjectMethodTable.ToString(),nq}, ExceptionMethodTable = {ExceptionMethodTable.ToString(),nq}, FreeMethodTable = {FreeMethodTable.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpUsefulGlobalsData
    {
        public CLRDATA_ADDRESS ArrayMethodTable;
        public CLRDATA_ADDRESS StringMethodTable;
        public CLRDATA_ADDRESS ObjectMethodTable;
        public CLRDATA_ADDRESS ExceptionMethodTable;
        public CLRDATA_ADDRESS FreeMethodTable;
    }
}
