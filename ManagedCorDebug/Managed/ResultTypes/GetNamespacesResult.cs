using System;

namespace ManagedCorDebug
{
    public struct GetNamespacesResult
    {
        public int PcNameSpaces { get; }

        public IntPtr Namespaces { get; }

        public GetNamespacesResult(int pcNameSpaces, IntPtr namespaces)
        {
            PcNameSpaces = pcNameSpaces;
            Namespaces = namespaces;
        }
    }
}