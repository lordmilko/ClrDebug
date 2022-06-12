using System;

namespace ManagedCorDebug
{
    public struct GetCustomAttributePropsResult
    {
        public mdToken PtkObj { get; }

        public mdToken PtkType { get; }

        public IntPtr PpBlob { get; }

        public int PcbSize { get; }

        public GetCustomAttributePropsResult(mdToken ptkObj, mdToken ptkType, IntPtr ppBlob, int pcbSize)
        {
            PtkObj = ptkObj;
            PtkType = ptkType;
            PpBlob = ppBlob;
            PcbSize = pcbSize;
        }
    }
}