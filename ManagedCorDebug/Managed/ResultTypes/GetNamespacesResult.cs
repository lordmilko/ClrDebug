using System;

namespace ManagedCorDebug
{
    public struct GetNamespacesResult
    {
        public uint PcNameSpaces { get; }

        public IntPtr Namespaces { get; }

        public GetNamespacesResult(uint pcNameSpaces, IntPtr namespaces)
        {
            PcNameSpaces = pcNameSpaces;
            Namespaces = namespaces;
        }
    }
}