using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataProcess.EnumTask"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, task = {task}")]
    public struct EnumTaskResult
    {
        public IntPtr handle { get; }

        public XCLRDataTask task { get; }

        public EnumTaskResult(IntPtr handle, XCLRDataTask task)
        {
            this.handle = handle;
            this.task = task;
        }
    }
}