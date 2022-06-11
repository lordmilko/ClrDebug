using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugRuntimeUnwindableFrame : CorDebugFrame
    {
        public CorDebugRuntimeUnwindableFrame(ICorDebugRuntimeUnwindableFrame raw) : base(raw)
        {
        }

        #region ICorDebugRuntimeUnwindableFrame

        public new ICorDebugRuntimeUnwindableFrame Raw => (ICorDebugRuntimeUnwindableFrame) base.Raw;

        #endregion
    }
}