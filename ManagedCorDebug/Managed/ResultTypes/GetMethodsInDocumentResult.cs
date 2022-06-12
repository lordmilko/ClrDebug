using System;

namespace ManagedCorDebug
{
    public struct GetMethodsInDocumentResult
    {
        public int PcMethod { get; }

        public IntPtr PRetVal { get; }

        public GetMethodsInDocumentResult(int pcMethod, IntPtr pRetVal)
        {
            PcMethod = pcMethod;
            PRetVal = pRetVal;
        }
    }
}