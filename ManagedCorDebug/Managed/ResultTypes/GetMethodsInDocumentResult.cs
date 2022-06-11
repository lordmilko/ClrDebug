using System;

namespace ManagedCorDebug
{
    public struct GetMethodsInDocumentResult
    {
        public uint PcMethod { get; }

        public IntPtr PRetVal { get; }

        public GetMethodsInDocumentResult(uint pcMethod, IntPtr pRetVal)
        {
            PcMethod = pcMethod;
            PRetVal = pRetVal;
        }
    }
}