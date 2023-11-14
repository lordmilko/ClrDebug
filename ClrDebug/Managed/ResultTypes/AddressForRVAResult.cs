using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaSession.AddressForRVA"/> method.
    /// </summary>
    [DebuggerDisplay("pISect = {pISect}, pOffset = {pOffset}")]
    public struct AddressForRVAResult
    {
        public int pISect { get; }

        public int pOffset { get; }

        public AddressForRVAResult(int pISect, int pOffset)
        {
            this.pISect = pISect;
            this.pOffset = pOffset;
        }
    }
}
