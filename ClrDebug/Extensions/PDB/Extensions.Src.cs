using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    public unsafe class Src : IDisposable
    {
        public IntPtr Raw { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SrcVtbl* vtbl;

        public Src(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
            vtbl = *(SrcVtbl**) raw;
        }

        #region Close

        //virtual bool Close() pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool CloseDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CloseDelegate close;

        public void Close()
        {
            InitDelegate(ref close, vtbl->Close);

            if (!close(Raw))
                throw new NotImplementedException();
        }

        #endregion
        #region Add

        //virtual bool Add(IN PCSrcHeader psrcheader, IN const void* pvData) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool AddDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddDelegate add;

        public void Add()
        {
            InitDelegate(ref add, vtbl->Add);

            throw new NotImplementedException();
        }

        #endregion
        #region Remove

        //virtual bool Remove(IN SZ_CONST szFile) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool RemoveDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveDelegate remove;

        public void Remove()
        {
            InitDelegate(ref remove, vtbl->Remove);

            throw new NotImplementedException();
        }

        #endregion
        #region QueryByName

        //virtual bool QueryByName(IN SZ_CONST szFile, OUT PSrcHeaderOut psrcheaderOut) const pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryByNameDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryByNameDelegate queryByName;

        public void QueryByName()
        {
            InitDelegate(ref queryByName, vtbl->QueryByName);

            throw new NotImplementedException();
        }

        #endregion
        #region GetData

        //virtual bool GetData(IN PCSrcHeaderOut pcsrcheader, OUT void * pvData) const pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool GetDataDelegate(
            [In] IntPtr @this,
            [In] ref SrcHeaderOut pcsrcheader,
            [In] IntPtr pvData);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetDataDelegate getData;

        public void GetData(SrcHeaderOut pcsrcheader, IntPtr pvData)
        {
            InitDelegate(ref getData, vtbl->GetData);

            if (!getData(Raw, ref pcsrcheader, pvData))
                throw new NotImplementedException();
        }

        #endregion
        #region GetEnum

        //virtual bool GetEnum(OUT EnumSrc ** ppenum) const pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool GetEnumDelegate(
            [In] IntPtr @this,
            [Out] out IntPtr ppenum);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEnumDelegate getEnum;

        public bool TryGetEnum(out EnumSrc enumSrc)
        {
            InitDelegate(ref getEnum, vtbl->GetEnum);

            if (!getEnum(Raw, out var ppenum))
            {
                enumSrc = default;
                return false;
            }

            enumSrc = new EnumSrc(ppenum);
            return true;
        }

        #endregion
        #region GetHeaderBlock

        //virtual bool GetHeaderBlock(SrcHeaderBlock & shb) const pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool GetHeaderBlockDelegate(
            [In] IntPtr @this,
            [Out] out SrcHeaderBlock shb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetHeaderBlockDelegate getHeaderBlock;

        public SrcHeaderBlock HeaderBlock
        {
            get
            {
                InitDelegate(ref getHeaderBlock, vtbl->GetHeaderBlock);

                if (!getHeaderBlock(Raw, out var shb))
                    throw new NotImplementedException();

                return shb;
            }
        }

        #endregion
        #region RemoveW

        //virtual bool RemoveW(_In_z_ IN wchar_t *wcsFile) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool RemoveWDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveWDelegate removeW;

        public void RemoveW()
        {
            InitDelegate(ref removeW, vtbl->RemoveW);

            throw new NotImplementedException();
        }

        #endregion
        #region QueryByNameW

        //virtual bool QueryByNameW(_In_z_ IN wchar_t *wcsFile, OUT PSrcHeaderOut psrcheaderOut) const pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryByNameWDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPWStr)] string wcsFile,
            [Out] out SrcHeaderOut psrcheaderout);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryByNameWDelegate queryByNameW;

        public SrcHeaderOut QueryByNameW(string wcsFile)
        {
            if (!TryQueryByNameW(wcsFile, out var psrcheaderout))
                throw new NotImplementedException();

            return psrcheaderout;
        }

        //The name that is specified is queried against the name table (/names). This is the
        //raw name of the file, e.g. C:\foo\bar.cpp. SrcImpl::GetData then prepends /src/files/
        //to the name of this file to locate the stream containing its data
        public bool TryQueryByNameW(string wcsFile, out SrcHeaderOut psrcheaderout)
        {
            InitDelegate(ref queryByNameW, vtbl->QueryByNameW);

            return queryByNameW(Raw, wcsFile, out psrcheaderout);
        }

        #endregion
        #region AddW

        //virtual bool AddW(IN PCSrcHeaderW psrcheader, IN const void * pvData) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool AddWDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddWDelegate addW;

        public void AddW()
        {
            InitDelegate(ref addW, vtbl->AddW);

            throw new NotImplementedException();
        }

        #endregion

        public void Dispose()
        {
            Close();
        }
    }
}
