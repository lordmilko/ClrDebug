using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("methodTable = {methodTable.ToString(),nq}, interfacePtr = {interfacePtr.ToString(),nq}, comContext = {comContext.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpCOMInterfacePointerData
    {
        public CLRDATA_ADDRESS methodTable;
        public CLRDATA_ADDRESS interfacePtr;
        public CLRDATA_ADDRESS comContext;
    }
}
