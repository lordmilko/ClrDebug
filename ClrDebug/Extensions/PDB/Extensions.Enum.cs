using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    public abstract unsafe class Enum : IDisposable
    {
        public IntPtr Raw { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private EnumVtbl* vtbl;

        #region Release

        delegate void ReleaseDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReleaseDelegate release;

        public void Release()
        {
            InitDelegate(ref release, vtbl->release);

            release(Raw);
        }

        #endregion
        #region Reset

        delegate void ResetDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ResetDelegate reset;

        public void Reset()
        {
            InitDelegate(ref reset, vtbl->reset);

            reset(Raw);
        }

        #endregion
        #region Next

        delegate bool NextDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private NextDelegate next;

        public void Next()
        {
            if (!TryNext())
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());
        }

        public bool TryNext()
        {
            InitDelegate(ref next, vtbl->next);

            return next(Raw);
        }

        #endregion

        public Enum(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
            vtbl = *(EnumVtbl**) raw;
        }

        public void Dispose()
        {
            Release();
        }
    }
}
