using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataMethodDefinition.EnumInstance"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, instance = {instance}")]
    public struct EnumInstanceResult
    {
        public IntPtr handle { get; }

        public XCLRDataMethodInstance instance { get; }

        public EnumInstanceResult(IntPtr handle, XCLRDataMethodInstance instance)
        {
            this.handle = handle;
            this.instance = instance;
        }
    }
}