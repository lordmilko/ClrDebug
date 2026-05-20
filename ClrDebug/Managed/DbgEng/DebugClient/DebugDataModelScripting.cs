namespace ClrDebug.DbgEng
{
    public class DebugDataModelScripting : ComObject<IDebugDataModelScripting>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugDataModelScripting"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugDataModelScripting(IDebugDataModelScripting raw) : base(raw)
        {
        }

        #region IDebugDataModelScripting
        #region GetProviders

        public void GetProviders(IDebugOutputStream stream)
        {
            TryGetProviders(stream).ThrowDbgEngNotOK();
        }

        public HRESULT TryGetProviders(IDebugOutputStream stream)
        {
            /*HRESULT GetProviders(
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);*/
            return Raw.GetProviders(stream);
        }

        #endregion
        #region GetScriptTemplateContent

        public void GetScriptTemplateContent(string scriptExtension, string templateName, IDebugOutputStream templateContent)
        {
            TryGetScriptTemplateContent(scriptExtension, templateName, templateContent).ThrowDbgEngNotOK();
        }

        public HRESULT TryGetScriptTemplateContent(string scriptExtension, string templateName, IDebugOutputStream templateContent)
        {
            /*HRESULT GetScriptTemplateContent(
            [MarshalAs(UnmanagedType.LPWStr), In] string scriptExtension,
            [MarshalAs(UnmanagedType.LPWStr), In] string templateName,
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream templateContent);*/
            return Raw.GetScriptTemplateContent(scriptExtension, templateName, templateContent);
        }

        #endregion
        #region CreateScript

        public DebugDataModelScriptReference CreateScript(string scriptExtension)
        {
            DebugDataModelScriptReference scriptReferenceResult;
            TryCreateScript(scriptExtension, out scriptReferenceResult).ThrowDbgEngNotOK();

            return scriptReferenceResult;
        }

        public HRESULT TryCreateScript(string scriptExtension, out DebugDataModelScriptReference scriptReferenceResult)
        {
            /*HRESULT CreateScript(
            [MarshalAs(UnmanagedType.LPWStr), In] string scriptExtension,
            [MarshalAs(UnmanagedType.Interface), Out] out IDebugDataModelScriptReference scriptReference);*/
            IDebugDataModelScriptReference scriptReference;
            HRESULT hr = Raw.CreateScript(scriptExtension, out scriptReference);

            if (hr == HRESULT.S_OK)
                scriptReferenceResult = scriptReference == null ? null : new DebugDataModelScriptReference(scriptReference);
            else
                scriptReferenceResult = default(DebugDataModelScriptReference);

            return hr;
        }

        #endregion
        #endregion
    }
}
