using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    public unsafe class EnumThunk : Enum
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new EnumThunkVtbl* vtbl;

        #region Get

        //virtual void get( OUT USHORT* pisect, OUT long* poff, OUT long* pcb ) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate void GetDelegate(
            [In] IntPtr @this,
            [Out] out ushort pisect,
            [Out] out int poff,
            [Out] out int pcb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetDelegate get;

        //Do not access Get prior to calling Next(), or you may AV
        public EnumThunk_GetResult Get
        {
            get
            {
                Extensions.InitDelegate(ref get, vtbl->get);

                get(Raw, out var pisect, out var poff, out var pcb);

                return new EnumThunk_GetResult(pisect, poff, pcb);
            }
        }

        #endregion

        public EnumThunk(IntPtr raw) : base(raw)
        {
            vtbl = *(EnumThunkVtbl**) raw;
        }
    }
}
