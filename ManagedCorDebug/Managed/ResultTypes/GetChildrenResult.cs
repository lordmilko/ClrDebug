using System;

namespace ManagedCorDebug
{
    public struct GetChildrenResult
    {
        public int PcChildren { get; }

        public IntPtr Children { get; }

        public GetChildrenResult(int pcChildren, IntPtr children)
        {
            PcChildren = pcChildren;
            Children = children;
        }
    }
}