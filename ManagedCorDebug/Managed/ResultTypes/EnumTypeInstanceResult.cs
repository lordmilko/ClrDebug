using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataModule.EnumTypeInstance"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, typeInstance = {typeInstance}")]
    public struct EnumTypeInstanceResult
    {
        public IntPtr handle { get; }

        public XCLRDataTypeInstance typeInstance { get; }

        public EnumTypeInstanceResult(IntPtr handle, XCLRDataTypeInstance typeInstance)
        {
            this.handle = handle;
            this.typeInstance = typeInstance;
        }
    }
}