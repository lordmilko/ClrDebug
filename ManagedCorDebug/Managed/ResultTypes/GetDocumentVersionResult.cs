using System;

namespace ManagedCorDebug
{
    public struct GetDocumentVersionResult
    {
        public int Version { get; }

        public int PbCurrent { get; }

        public GetDocumentVersionResult(int version, int pbCurrent)
        {
            Version = version;
            PbCurrent = pbCurrent;
        }
    }
}