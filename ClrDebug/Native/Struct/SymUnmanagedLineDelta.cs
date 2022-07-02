using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Line deltas allow a compiler to omit functions that have not been modified from
    /// the pdb stream provided the line information meets the following condition.
    /// The correct line information can be determined with the old pdb line info and
    /// one delta for all lines in the function.
    /// </summary>
    [DebuggerDisplay("MethodToken = {MethodToken}, Delta = {Delta}")]
    public struct SymUnmanagedLineDelta
    {
        public readonly int MethodToken;
        public readonly int Delta;

        public SymUnmanagedLineDelta(int methodToken, int delta)
        {
            MethodToken = methodToken;
            Delta = delta;
        }
    }
}
