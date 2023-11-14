using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaStackWalkHelper.AddressForVA"/> method.
    /// </summary>
    [DebuggerDisplay("pISect = {pISect}, pOffset = {pOffset}")]
    public struct AddressForVAResult
    {
        public int pISect { get; }

        public int pOffset { get; }

        public AddressForVAResult(int pISect, int pOffset)
        {
            this.pISect = pISect;
            this.pOffset = pOffset;
        }
    }
}
