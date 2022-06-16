using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.EnumMethodDefinitionByName"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, method = {method}")]
    public struct EnumMethodDefinitionByNameResult
    {
        public IntPtr handle { get; }

        public XCLRDataMethodDefinition method { get; }

        public EnumMethodDefinitionByNameResult(IntPtr handle, XCLRDataMethodDefinition method)
        {
            this.handle = handle;
            this.method = method;
        }
    }
}