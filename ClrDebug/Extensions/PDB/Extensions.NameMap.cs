using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    public unsafe class NameMap : IDisposable
    {
        public IntPtr Raw { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private NameMapVtbl* vtbl;

        #region close

        //virtual BOOL close() pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool CloseDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CloseDelegate close;

        public bool Close()
        {
            InitDelegate(ref close, vtbl->close);

            throw new NotImplementedException();
        }

        #endregion
        #region Reinitialize

        //virtual BOOL reinitialize() pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool ReinitializeDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReinitializeDelegate reinitialize;

        public bool Reinitialize()
        {
            InitDelegate(ref reinitialize, vtbl->reinitialize);

            throw new NotImplementedException();
        }

        #endregion
        #region GetNi

        //virtual BOOL getNi(_In_z_ const char* sz, OUT NI* pni) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool GetNiDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStr)] string sz,
            [Out] out int pni);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNiDelegate getNi;

        public int GetNi(string sz)
        {
            if (!TryGetNi(sz, out var pni))
                throw new NotImplementedException();

            return pni;
        }

        public bool TryGetNi(string sz, out int pni)
        {
            InitDelegate(ref getNi, vtbl->getNi);

            return getNi(Raw, sz, out pni);
        }

        #endregion
        #region GetName

        //virtual BOOL getName(NI ni, _Deref_out_z_ OUT const char** psz) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool GetNameDelegate(
            [In] IntPtr @this,
            [In] int ni,
            [Out] out IntPtr psz);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNameDelegate getName;

        public bool TryGetName(int ni, out string psz)
        {
            InitDelegate(ref getName, vtbl->getName);

            if (getName(Raw, ni, out var rawName))
            {
                psz = Marshal.PtrToStringAnsi(rawName);
                return true;
            }

            psz = default;
            return false;
        }

        #endregion
        #region GetEnumNameMap

        //virtual BOOL getEnumNameMap(OUT Enum** ppenum) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool GetEnumNameMapDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEnumNameMapDelegate getEnumNameMap;

        public bool GetEnumNameMap()
        {
            InitDelegate(ref getEnumNameMap, vtbl->getEnumNameMap);

            throw new NotImplementedException();
        }

        #endregion
        #region Contains

        //virtual BOOL contains(_In_z_ const char* sz, OUT NI* pni) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool ContainsDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ContainsDelegate contains;

        public bool Contains()
        {
            InitDelegate(ref contains, vtbl->contains);

            throw new NotImplementedException();
        }

        #endregion
        #region Commit

        //virtual BOOL commit() pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool CommitDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CommitDelegate commit;

        public bool Commit()
        {
            InitDelegate(ref commit, vtbl->commit);

            throw new NotImplementedException();
        }

        #endregion
        #region Foo

        //virtual BOOL isValidNi(NI ni) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool IsValidNiDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IsValidNiDelegate isValidNi;

        public bool IsValidNi()
        {
            InitDelegate(ref isValidNi, vtbl->isValidNi);

            throw new NotImplementedException();
        }

        #endregion
        #region GetNiW

        //virtual BOOL getNiW(_In_z_ const wchar_t* sz, OUT NI* pni) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool GetNiWDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNiWDelegate getNiW;

        public bool GetNiW()
        {
            InitDelegate(ref getNiW, vtbl->getNiW);

            throw new NotImplementedException();
        }

        #endregion
        #region GetNameW

        //virtual BOOL getNameW(NI ni, _Out_opt_capcount_(*pcch) OUT wchar_t* szName, IN OUT size_t * pcch) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool GetNameWDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNameWDelegate getNameW;

        public bool GetNameW()
        {
            InitDelegate(ref getNameW, vtbl->getNameW);

            throw new NotImplementedException();
        }

        #endregion
        #region ContainsW

        //virtual BOOL containsW(_In_z_ const wchar_t *sz, OUT NI* pni) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool ContainsWDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ContainsWDelegate containsW;

        public bool ContainsW()
        {
            InitDelegate(ref containsW, vtbl->containsW);

            throw new NotImplementedException();
        }

        #endregion
        #region Foo

        //virtual BOOL containsUTF8(_In_z_ const char* sz, OUT NI* pni) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool ContainsUTF8Delegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ContainsUTF8Delegate containsUTF8;

        public bool ContainsUTF8()
        {
            InitDelegate(ref containsUTF8, vtbl->containsUTF8);

            throw new NotImplementedException();
        }

        #endregion
        #region Foo

        //virtual BOOL getNiUTF8(_In_z_ const char *sz, OUT NI* pni) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool GetNiUTF8Delegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNiUTF8Delegate getNiUTF8;

        public bool GetNiUTF8()
        {
            InitDelegate(ref getNiUTF8, vtbl->getNiUTF8);

            throw new NotImplementedException();
        }

        #endregion
        #region Foo

        //virtual BOOL getNameA(NI ni, _Pre_notnull_ _Post_z_ OUT const char ** psz) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool GetNameADelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNameADelegate getNameA;

        public bool GetNameA()
        {
            InitDelegate(ref getNameA, vtbl->getNameA);

            throw new NotImplementedException();
        }

        #endregion
        #region Foo

        //virtual BOOL getNameW2(NI ni, _Pre_notnull_ _Post_z_ OUT const wchar_t ** pwsz) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool GetNameW2Delegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNameW2Delegate getNameW2;

        public bool GetNameW2()
        {
            InitDelegate(ref getNameW2, vtbl->getNameW2);

            throw new NotImplementedException();
        }

        #endregion

        public NameMap(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
            vtbl = *(NameMapVtbl**) raw;
        }

        public void Dispose()
        {
            Close();
        }
    }
}
