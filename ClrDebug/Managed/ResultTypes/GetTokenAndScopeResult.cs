using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataMethodInstance.TokenAndScope"/> property.
    /// </summary>
    [DebuggerDisplay("token = {token.ToString(),nq}, mod = {mod?.ToString(),nq}")]
    public struct GetTokenAndScopeResult
    {
        public mdMethodDef token { get; }

        public XCLRDataModule mod { get; }

        public GetTokenAndScopeResult(mdMethodDef token, XCLRDataModule mod)
        {
            this.token = token;
            this.mod = mod;
        }
    }
}
