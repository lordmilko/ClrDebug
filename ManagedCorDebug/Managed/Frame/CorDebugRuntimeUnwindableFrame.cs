using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides support for unmanaged methods that require the common language runtime (CLR) to unwind a frame.
    /// </summary>
    /// <remarks>
    /// <see cref="ICorDebugRuntimeUnwindableFrame"/> is a specialized version of the <see cref="ICorDebugFrame"/> interface. It is used by unmanaged
    /// methods that require the runtime to unwind a frame on the current stack. Existing unwinding conventions do not
    /// work, because they do not use JIT-compiled code. When the debugger sees an unwindable frame, it should use the
    /// <see cref="CorDebugStackWalk.Next"/> method to unwind it, but it should perform inspection itself. When the debugger
    /// receives an <see cref="ICorDebugRuntimeUnwindableFrame"/>, it can call the <see cref="CorDebugStackWalk.GetContext"/> method
    /// to retrieve the context of the frame.
    /// </remarks>
    public class CorDebugRuntimeUnwindableFrame : CorDebugFrame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugRuntimeUnwindableFrame"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugRuntimeUnwindableFrame(ICorDebugRuntimeUnwindableFrame raw) : base(raw)
        {
        }

        #region ICorDebugRuntimeUnwindableFrame

        public new ICorDebugRuntimeUnwindableFrame Raw => (ICorDebugRuntimeUnwindableFrame) base.Raw;

        #endregion
    }
}