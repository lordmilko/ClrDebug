using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("Function = {Function.ToString(),nq}, Context = {Context.ToString(),nq}, NextWorkRequest = {NextWorkRequest.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpWorkRequestData
    {
        public CLRDATA_ADDRESS Function;
        public CLRDATA_ADDRESS Context;
        public CLRDATA_ADDRESS NextWorkRequest;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetWorkRequestData(addr, out this);
        }
    }
}
