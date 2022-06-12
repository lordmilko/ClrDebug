using System;

namespace ManagedCorDebug
{
    public struct GetMethodsFromDocumentPositionResult
    {
        public int PcMethod { get; }

        public IntPtr PRetVal { get; }

        public GetMethodsFromDocumentPositionResult(int pcMethod, IntPtr pRetVal)
        {
            PcMethod = pcMethod;
            PRetVal = pRetVal;
        }
    }
}