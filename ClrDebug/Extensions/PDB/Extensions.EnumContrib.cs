using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    public unsafe class EnumContrib : Enum
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private EnumContribVtbl* vtbl;

        #region Get

        //virtual void get(OUT USHORT* pimod, OUT USHORT* pisect, OUT long* poff, OUT long* pcb, OUT ULONG* pdwCharacteristics) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate void GetDelegate(
            [In] IntPtr @this,
            [Out] out short pimod,
            [Out] out short pisect,
            [Out] out int poff,
            [Out] out int pcb,
            [Out] out int pdwCharacteristics);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetDelegate get;

        public EnumContrib_GetResult Get
        {
            get
            {
                InitDelegate(ref get, vtbl->get);

                get(Raw, out var pimod, out var pisect, out var poff, out var pcb, out var pdwCharacteristics);

                return new EnumContrib_GetResult(pimod, pisect, poff, pcb, pdwCharacteristics);
            }
        }

        #endregion
        #region GetCrcs

        //virtual void getCrcs(OUT DWORD* pcrcData, OUT DWORD* pcrcReloc ) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate void GetCrcsDelegate(
        //    [In] IntPtr @this,
        //    [Out] out IntPtr pcrcData,
        //    [Out] out int pcrcReloc);

        //private GetCrcsDelegate getCrcs;

        //public GetCrcsResult GetCrcs
        //{
        //    get
        //    {
        //        InitDelegate(ref getCrcs, vtbl->getCrcs);

        //        getCrcs(Raw, out var pcrcData, out var pcrcReloc);

        //        return new GetCrcsResult(pcrcData, pcrcReloc);
        //    }
        //}

        #endregion
        #region fUpdate

        //virtual bool fUpdate(IN long off, IN long cb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool fUpdateDelegate(
            [In] IntPtr @this,
            [In] int off,
            [In] int cb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private fUpdateDelegate fUpdate;

        public bool TryFUpdate(int off, int cb)
        {
            InitDelegate(ref fUpdate, vtbl->fUpdate);

            return fUpdate(Raw, off, cb);
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

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool CloneDelegate(
            [In] IntPtr @this,
            [Out] out IntPtr ppEnum);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CloneDelegate clone;

        public bool TryClone(out EnumContrib ppEnum)
        {
            InitDelegate(ref clone, vtbl->clone);

            var result = clone(Raw, out var ppEnumRaw);

            ppEnum = ppEnumRaw != IntPtr.Zero ? new EnumContrib(ppEnumRaw) : null;

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
        #region Get2

        //virtual void get2(OUT USHORT* pimod, OUT USHORT* pisect, OUT DWORD* poff, OUT DWORD* pisectCoff, OUT DWORD* pcb, OUT ULONG* pdwCharacteristics) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate void Get2Delegate(
            [In] IntPtr @this,
            [Out] out short pimod,
            [Out] out short pisect,
            [Out] out int poff,
            [Out] out int pisectCoff,
            [Out] out int pcb,
            [Out] out int pdwCharacteristics);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Get2Delegate get2;

        public EnumContrib_Get2Result Get2
        {
            get
            {
                InitDelegate(ref get2, vtbl->get2);

                get2(Raw, out var pimod, out var pisect, out var poff, out var pisectCoff, out var pcb, out var pdwCharacteristics);

                return new EnumContrib_Get2Result(pimod, pisect, poff, pisectCoff, pcb, pdwCharacteristics);
            }
        }

        #endregion

        public EnumContrib(IntPtr raw) : base(raw)
        {
            vtbl = *(EnumContribVtbl**) raw;
        }
    }
}
