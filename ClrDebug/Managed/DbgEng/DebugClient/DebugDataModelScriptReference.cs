namespace ClrDebug.DbgEng
{
    public class DebugDataModelScriptReference : ComObject<IDebugDataModelScriptReference>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugDataModelScriptReference"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
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
            /*HRESULT Populate(
            [MarshalAs(UnmanagedType.LPWStr), In] string contents);*/
            return Raw.Populate(contents);
        }

        #endregion
        #region Execute

        public void Execute(IDebugOutputStream executionResult)
        {
            TryExecute(executionResult).ThrowDbgEngNotOK();
        }

        public HRESULT TryExecute(IDebugOutputStream executionResult)
        {
            /*HRESULT Execute(
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream executionResult);*/
            return Raw.Execute(executionResult);
        }

        #endregion
        #region Unlink

        public void Unlink()
        {
            TryUnlink().ThrowDbgEngNotOK();
        }

        public HRESULT TryUnlink()
        {
            /*HRESULT Unlink();*/
            return Raw.Unlink();
        }

        #endregion
        #region InvokeMain

        public void InvokeMain(IDebugOutputStream executionResult)
        {
            TryInvokeMain(executionResult).ThrowDbgEngNotOK();
        }

        public HRESULT TryInvokeMain(IDebugOutputStream executionResult)
        {
            /*HRESULT InvokeMain(
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream executionResult);*/
            return Raw.InvokeMain(executionResult);
        }

        #endregion
        #region Rename

        public void Rename(string name)
        {
            TryRename(name).ThrowDbgEngNotOK();
        }

        public HRESULT TryRename(string name)
        {
            /*HRESULT Rename(
            [MarshalAs(UnmanagedType.LPWStr), In] string name);*/
            return Raw.Rename(name);
        }

        #endregion
        #endregion
    }
}
