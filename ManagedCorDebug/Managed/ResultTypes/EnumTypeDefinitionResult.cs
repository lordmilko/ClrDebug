using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataModule.EnumTypeDefinition"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, typeDefinition = {typeDefinition}")]
    public struct EnumTypeDefinitionResult
    {
        public IntPtr handle { get; }

        public XCLRDataTypeDefinition typeDefinition { get; }

        public EnumTypeDefinitionResult(IntPtr handle, XCLRDataTypeDefinition typeDefinition)
        {
            this.handle = handle;
            this.typeDefinition = typeDefinition;
        }
    }
}