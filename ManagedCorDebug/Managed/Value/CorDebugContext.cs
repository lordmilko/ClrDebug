using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
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