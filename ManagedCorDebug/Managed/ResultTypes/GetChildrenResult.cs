using System;

namespace ManagedCorDebug
{
    public struct GetChildrenResult
    {
        public uint PcChildren { get; }

        public IntPtr Children { get; }

        public GetChildrenResult(uint pcChildren, IntPtr children)
        {
            PcChildren = pcChildren;
            Children = children;
        }
    }
}