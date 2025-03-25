using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    public unsafe class EnumSyms : Enum
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new EnumSymsVtbl* vtbl;

        #region Get

        //virtual void get( BYTE** ppbSym ) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate void GetDelegate(
            [In] IntPtr @this,
            [Out] out SYMTYPE* ppbSym);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetDelegate get;

        //Do not access Get prior to calling Next(), or you may AV
        public SYMTYPE* Get
        {
            get
            {
                InitDelegate(ref get, vtbl->get);

                get(Raw, out var ppbSym);

                return ppbSym;
            }
        }

        #endregion
        #region Prev

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool PrevDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PrevDelegate prev;

        public bool TryPrev()
        {
            InitDelegate(ref prev, vtbl->prev);

            return prev(Raw);
        }

        #endregion
        #region Clone

        //virtual BOOL clone( OUT EnumSyms **ppEnum ) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool CloneDelegate(
            [In] IntPtr @this,
            [Out] out IntPtr ppEnum);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CloneDelegate clone;

        public bool TryClone(out EnumSyms ppEnum)
        {
            InitDelegate(ref clone, vtbl->clone);

            var result = clone(Raw, out var ppEnumRaw);

            ppEnum = ppEnumRaw != IntPtr.Zero ? new EnumSyms(ppEnumRaw) : null;

            return result;
        }

        #endregion
        #region Locate

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool LocateDelegate(
            [In] IntPtr @this,
            [In] int isect,
            [In] int off);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private LocateDelegate locate;

        public void Locate(int isect, int off)
        {
            if (!TryLocate(isect, off))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());
        }

        public bool TryLocate(int isect, int off)
        {
            InitDelegate(ref locate, vtbl->locate);

            return locate(Raw, isect, off);
        }

        #endregion

        public EnumSyms(IntPtr raw) : base(raw)
        {
            vtbl = *(EnumSymsVtbl**) raw;
        }
    }
}
