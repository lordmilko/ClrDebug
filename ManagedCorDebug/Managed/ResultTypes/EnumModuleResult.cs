using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataProcess.EnumModule"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, mod = {mod}")]
    public struct EnumModuleResult
    {
        public IntPtr handle { get; }

        public XCLRDataModule mod { get; }

        public EnumModuleResult(IntPtr handle, XCLRDataModule mod)
        {
            this.handle = handle;
            this.mod = mod;
        }
    }
}