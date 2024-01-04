using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugDataModelScriptReference : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugDataModelScriptReference = new Guid("FD5D43CB-9A6D-418E-8804-4EDE27CFC3A4");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugDataModelScriptReferenceVtbl* Vtbl => (IDebugDataModelScriptReferenceVtbl*) base.Vtbl;

        #endregion

        public DebugDataModelScriptReference(IntPtr raw) : base(raw, IID_IDebugDataModelScriptReference)
        {
        }

        public DebugDataModelScriptReference(IDebugDataModelScriptReference raw) : base(raw)
        {
        }

        #region IDebugDataModelScriptReference
        #region Populate

        public void Populate(string contents)
        {
            TryPopulate(contents).ThrowDbgEngNotOK();
        }

        public HRESULT TryPopulate(string contents)
        {
            InitDelegate(ref populate, Vtbl->Populate);

            /*HRESULT Populate(
            [MarshalAs(UnmanagedType.LPWStr), In] string contents);*/
            return populate(Raw, contents);
        }

        #endregion
        #region Execute

        public void Execute(IDebugOutputStream executionResult)
        {
            TryExecute(executionResult).ThrowDbgEngNotOK();
        }

        public HRESULT TryExecute(IDebugOutputStream executionResult)
        {
            InitDelegate(ref execute, Vtbl->Execute);

            /*HRESULT Execute(
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream executionResult);*/
            return execute(Raw, executionResult);
        }

        #endregion
        #region Unlink

        public void Unlink()
        {
            TryUnlink().ThrowDbgEngNotOK();
        }

        public HRESULT TryUnlink()
        {
            InitDelegate(ref unlink, Vtbl->Unlink);

            /*HRESULT Unlink();*/
            return unlink(Raw);
        }

        #endregion
        #region InvokeMain

        public void InvokeMain(IDebugOutputStream executionResult)
        {
            TryInvokeMain(executionResult).ThrowDbgEngNotOK();
        }

        public HRESULT TryInvokeMain(IDebugOutputStream executionResult)
        {
            InitDelegate(ref invokeMain, Vtbl->InvokeMain);

            /*HRESULT InvokeMain(
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream executionResult);*/
            return invokeMain(Raw, executionResult);
        }

        #endregion
        #region Rename

        public void Rename(string name)
        {
            TryRename(name).ThrowDbgEngNotOK();
        }

        public HRESULT TryRename(string name)
        {
            InitDelegate(ref rename, Vtbl->Rename);

            /*HRESULT Rename(
            [MarshalAs(UnmanagedType.LPWStr), In] string name);*/
            return rename(Raw, name);
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugDataModelScriptReference

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PopulateDelegate populate;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ExecuteDelegate execute;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private UnlinkDelegate unlink;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private InvokeMainDelegate invokeMain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RenameDelegate rename;

        #endregion
        #endregion
        #region Delegates
        #region IDebugDataModelScriptReference

        private delegate HRESULT PopulateDelegate(IntPtr self, [MarshalAs(UnmanagedType.LPWStr), In] string contents);
        private delegate HRESULT ExecuteDelegate(IntPtr self, [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream executionResult);
        private delegate HRESULT UnlinkDelegate(IntPtr self);
        private delegate HRESULT InvokeMainDelegate(IntPtr self, [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream executionResult);
        private delegate HRESULT RenameDelegate(IntPtr self, [MarshalAs(UnmanagedType.LPWStr), In] string name);

        #endregion
        #endregion
    }
}
