using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.TokenAndScope"/> property.
    /// </summary>
    [DebuggerDisplay("token = {token}, mod = {mod}")]
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