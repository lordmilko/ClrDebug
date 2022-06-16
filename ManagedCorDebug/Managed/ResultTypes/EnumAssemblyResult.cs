using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataProcess.EnumAssembly"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, assembly = {assembly}")]
    public struct EnumAssemblyResult
    {
        public IntPtr handle { get; }

        public XCLRDataAssembly assembly { get; }

        public EnumAssemblyResult(IntPtr handle, XCLRDataAssembly assembly)
        {
            this.handle = handle;
            this.assembly = assembly;
        }
    }
}