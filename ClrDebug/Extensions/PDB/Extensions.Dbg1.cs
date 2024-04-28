using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Provides access to miscellaneous debug data within the PDB (FPO, OMAP, etc).
    /// </summary>
    public unsafe class Dbg1 : IDisposable
    {
        public IntPtr Raw { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Dbg1Vtbl* vtbl;

        #region Close

        //virtual BOOL Close() pure;

        delegate bool CloseDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CloseDelegate close;

        public void Close()
        {
            if (!TryClose())
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());
        }

        public bool TryClose()
        {
            InitDelegate(ref close, vtbl->Close);

            return close(Raw);
        }

        #endregion
        #region QuerySize

        //virtual long QuerySize() pure;

        delegate int QuerySizeDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QuerySizeDelegate querySize;

        public int Size
        {
            get
            {
                InitDelegate(ref querySize, vtbl->QuerySize);

                return querySize(Raw);
            }
        }

        #endregion
        #region Reset

        //virtual void Reset() pure;

        delegate void ResetDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ResetDelegate reset;

        public void Reset()
        {
            InitDelegate(ref reset, vtbl->Reset);
        }

        #endregion
        #region Skip

        //virtual BOOL Skip(ULONG celt) pure;

        delegate bool SkipDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SkipDelegate skip;

        public bool TrySkip()
        {
            InitDelegate(ref skip, vtbl->Skip);

            return skip(Raw);
        }

        #endregion
        #region QueryNext

        //virtual BOOL QueryNext(ULONG celt, OUT void* rgelt) pure;

        delegate bool QueryNextDelegate(
            [In] IntPtr @this,
            [In] int celt,
            [Out] IntPtr rgelt);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryNextDelegate queryNext;

        public void QueryNext(int celt, IntPtr rgelt)
        {
            if (!TryQueryNext(celt, rgelt))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());
        }

        public bool TryQueryNext(int celt, IntPtr rgelt)
        {
            InitDelegate(ref queryNext, vtbl->QueryNext);

            return queryNext(Raw, celt, rgelt);
        }

        #endregion
        #region Find

        //virtual BOOL Find(IN OUT void* pelt) pure;

        delegate bool FindDelegate(
            [In] IntPtr @this,
            [In, Out] IntPtr pelt);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FindDelegate find;

        public bool TryFind(IntPtr pelt)
        {
            InitDelegate(ref find, vtbl->Find);

            return find(Raw, pelt);
        }

        #endregion
        #region Clear

        //virtual BOOL Clear() pure;

        delegate bool ClearDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ClearDelegate clear;

        public bool TryClear()
        {
            InitDelegate(ref clear, vtbl->Clear);

            return clear(Raw);
        }

        #endregion
        #region Append

        //virtual BOOL Append(ULONG celt, const void* rgelt) pure;

        delegate bool AppendDelegate(
            [In] IntPtr @this,
            [In] int celt,
            [In] IntPtr rgelt);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AppendDelegate append;

        public bool TryAppend(int celt, IntPtr rgelt)
        {
            InitDelegate(ref append, vtbl->Append);

            return append(Raw, celt, rgelt);
        }

        #endregion
        #region ReplaceNext

        //virtual BOOL ReplaceNext(ULONG celt, const void* rgelt) pure;

        delegate bool ReplaceNextDelegate(
            [In] IntPtr @this,
            [In] int celt,
            [In] IntPtr rgelt);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReplaceNextDelegate replaceNext;

        public bool TryReplaceNext(int celt, IntPtr rgelt)
        {
            InitDelegate(ref replaceNext, vtbl->ReplaceNext);

            return replaceNext(Raw, celt, rgelt);
        }

        #endregion
        #region Clone

        //virtual BOOL Clone(Dbg** ppDbg) pure;

        delegate bool CloneDelegate(
            [In] IntPtr @this,
            [Out] out IntPtr ppDbg);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CloneDelegate clone;

        public bool TryClone(out Dbg1 ppDbg)
        {
            InitDelegate(ref clone, vtbl->Clone);

            var result = clone(Raw, out var ppDbgRaw);

            ppDbg = ppDbgRaw != IntPtr.Zero ? new Dbg1(ppDbgRaw) : null;

            return result;
        }

        #endregion
        #region QueryElementSize

        //virtual long QueryElementSize() pure;

        delegate int QueryElementSizeDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryElementSizeDelegate queryElementSize;

        public int ElementSize
        {
            get
            {
                InitDelegate(ref queryElementSize, vtbl->QueryElementSize);

                return queryElementSize(Raw);
            }
        }

        #endregion

        public Dbg1(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
            vtbl = *(Dbg1Vtbl**) raw;
        }

        public void Dispose()
        {
            Close();
        }
    }
}
