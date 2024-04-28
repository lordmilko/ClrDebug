using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("ec = {ec}, szError = {szError}")]
    public struct PDB1_QueryLastErrorResult
    {
        public EC ec;
        public string szError;

        public PDB1_QueryLastErrorResult(EC ec, string szError)
        {
            this.ec = ec;
            this.szError = szError;
        }
    }
}
