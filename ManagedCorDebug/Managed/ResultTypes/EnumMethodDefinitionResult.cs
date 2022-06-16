using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.EnumMethodDefinition"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, methodDefinition = {methodDefinition}")]
    public struct EnumMethodDefinitionResult
    {
        public IntPtr handle { get; }

        public XCLRDataMethodDefinition methodDefinition { get; }

        public EnumMethodDefinitionResult(IntPtr handle, XCLRDataMethodDefinition methodDefinition)
        {
            this.handle = handle;
            this.methodDefinition = methodDefinition;
        }
    }
}