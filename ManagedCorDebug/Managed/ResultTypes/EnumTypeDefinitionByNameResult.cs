using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataModule.EnumTypeDefinitionByName"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, type = {type}")]
    public struct EnumTypeDefinitionByNameResult
    {
        public IntPtr handle { get; }

        public XCLRDataTypeDefinition type { get; }

        public EnumTypeDefinitionByNameResult(IntPtr handle, XCLRDataTypeDefinition type)
        {
            this.handle = handle;
            this.type = type;
        }
    }
}