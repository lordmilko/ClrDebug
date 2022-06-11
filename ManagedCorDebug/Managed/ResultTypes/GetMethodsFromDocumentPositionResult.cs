using System;

namespace ManagedCorDebug
{
    public struct GetMethodsFromDocumentPositionResult
    {
        public uint PcMethod { get; }

        public IntPtr PRetVal { get; }

        public GetMethodsFromDocumentPositionResult(uint pcMethod, IntPtr pRetVal)
        {
            PcMethod = pcMethod;
            PRetVal = pRetVal;
        }
    }
}