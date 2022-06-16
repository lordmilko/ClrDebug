using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeInstance.EnumMethodInstanceByName"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, method = {method}")]
    public struct EnumMethodInstanceByNameResult
    {
        public IntPtr handle { get; }

        public XCLRDataMethodInstance method { get; }

        public EnumMethodInstanceByNameResult(IntPtr handle, XCLRDataMethodInstance method)
        {
            this.handle = handle;
            this.method = method;
        }
    }
}