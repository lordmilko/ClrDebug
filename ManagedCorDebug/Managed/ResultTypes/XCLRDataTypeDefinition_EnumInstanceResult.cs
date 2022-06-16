using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.EnumInstance"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, instance = {instance}")]
    public struct XCLRDataTypeDefinition_EnumInstanceResult
    {
        public IntPtr handle { get; }

        public XCLRDataTypeInstance instance { get; }

        public XCLRDataTypeDefinition_EnumInstanceResult(IntPtr handle, XCLRDataTypeInstance instance)
        {
            this.handle = handle;
            this.instance = instance;
        }
    }
}