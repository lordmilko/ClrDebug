using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedScope.GetChildren"/> method.
    /// </summary>
    [DebuggerDisplay("pcChildren = {pcChildren}, children = {children}")]
    public struct GetChildrenResult
    {
        /// <summary>
        /// A pointer to a ULONG32 that receives the size of the buffer required to contain the children.
        /// </summary>
        public int pcChildren { get; }

        /// <summary>
        /// The returned array of children.
        /// </summary>
        public IntPtr children { get; }

        public GetChildrenResult(int pcChildren, IntPtr children)
        {
            this.pcChildren = pcChildren;
            this.children = children;
        }
    }
}