using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeInstance.EnumMethodInstance"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, methodInstance = {methodInstance}")]
    public struct EnumMethodInstanceResult
    {
        public IntPtr handle { get; }

        public XCLRDataMethodInstance methodInstance { get; }

        public EnumMethodInstanceResult(IntPtr handle, XCLRDataMethodInstance methodInstance)
        {
            this.handle = handle;
            this.methodInstance = methodInstance;
        }
    }
}