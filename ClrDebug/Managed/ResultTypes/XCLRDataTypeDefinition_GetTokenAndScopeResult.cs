using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.TokenAndScope"/> property.
    /// </summary>
    [DebuggerDisplay("token = {token.ToString(),nq}, mod = {mod.ToString(),nq}")]
    public struct XCLRDataTypeDefinition_GetTokenAndScopeResult
    {
        public mdTypeDef token { get; }

        public XCLRDataModule mod { get; }

        public XCLRDataTypeDefinition_GetTokenAndScopeResult(mdTypeDef token, XCLRDataModule mod)
        {
            this.token = token;
            this.mod = mod;
        }
    }
}
