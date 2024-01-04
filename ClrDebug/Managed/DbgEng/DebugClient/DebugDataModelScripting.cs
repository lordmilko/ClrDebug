using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugDataModelScripting : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugDataModelScripting = new Guid("5DBA6ACF-1E01-400D-B164-838034F71ACE");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugDataModelScriptingVtbl* Vtbl => (IDebugDataModelScriptingVtbl*) base.Vtbl;

        #endregion

        public DebugDataModelScripting(IntPtr raw) : base(raw, IID_IDebugDataModelScripting)
        {
        }

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
            InitDelegate(ref getProviders, Vtbl->GetProviders);

            /*HRESULT GetProviders(
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);*/
            return getProviders(Raw, stream);
        }

        #endregion
        #region GetScriptTemplateContent

        public void GetScriptTemplateContent(string scriptExtension, string templateName, IDebugOutputStream templateContent)
        {
            TryGetScriptTemplateContent(scriptExtension, templateName, templateContent).ThrowDbgEngNotOK();
        }

        public HRESULT TryGetScriptTemplateContent(string scriptExtension, string templateName, IDebugOutputStream templateContent)
        {
            InitDelegate(ref getScriptTemplateContent, Vtbl->GetScriptTemplateContent);

            /*HRESULT GetScriptTemplateContent(
            [MarshalAs(UnmanagedType.LPWStr), In] string scriptExtension,
            [MarshalAs(UnmanagedType.LPWStr), In] string templateName,
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream templateContent);*/
            return getScriptTemplateContent(Raw, scriptExtension, templateName, templateContent);
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
            InitDelegate(ref createScript, Vtbl->CreateScript);
            /*HRESULT CreateScript(
            [MarshalAs(UnmanagedType.LPWStr), In] string scriptExtension,
            [MarshalAs(UnmanagedType.Interface), Out] out IDebugDataModelScriptReference scriptReference);*/
            IDebugDataModelScriptReference scriptReference;
            HRESULT hr = createScript(Raw, scriptExtension, out scriptReference);

            if (hr == HRESULT.S_OK)
                scriptReferenceResult = scriptReference == null ? null : new DebugDataModelScriptReference(scriptReference);
            else
                scriptReferenceResult = default(DebugDataModelScriptReference);

            return hr;
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugDataModelScripting

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetProvidersDelegate getProviders;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetScriptTemplateContentDelegate getScriptTemplateContent;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CreateScriptDelegate createScript;

        #endregion
        #endregion
        #region Delegates
        #region IDebugDataModelScripting

        private delegate HRESULT GetProvidersDelegate(IntPtr self, [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);
        private delegate HRESULT GetScriptTemplateContentDelegate(IntPtr self, [MarshalAs(UnmanagedType.LPWStr), In] string scriptExtension, [MarshalAs(UnmanagedType.LPWStr), In] string templateName, [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream templateContent);
        private delegate HRESULT CreateScriptDelegate(IntPtr self, [MarshalAs(UnmanagedType.LPWStr), In] string scriptExtension, [MarshalAs(UnmanagedType.Interface), Out] out IDebugDataModelScriptReference scriptReference);

        #endregion
        #endregion
    }
}
