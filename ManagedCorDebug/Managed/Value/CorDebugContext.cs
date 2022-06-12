using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a context object. This interface has not been implemented yet.
    /// </summary>
    public class CorDebugContext : CorDebugObjectValue
    {
        public CorDebugContext(ICorDebugContext raw) : base(raw)
        {
        }

        #region ICorDebugContext

        public new ICorDebugContext Raw => (ICorDebugContext) base.Raw;

        #endregion
    }
}