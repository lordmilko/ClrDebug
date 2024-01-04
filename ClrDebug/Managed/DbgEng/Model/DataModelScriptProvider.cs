namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any script provider implementing a bridge between a dynamic language and the data model must implement this interface to represent the provider.
    /// </summary>
    public class DataModelScriptProvider : ComObject<IDataModelScriptProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelScriptProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelScriptProvider(IDataModelScriptProvider raw) : base(raw)
        {
        }

        #region IDataModelScriptProvider
        #region Name

        /// <summary>
        /// The GetName method returns the name of the type of (or language of) scripts which the provider manages as a string allocated via the SysAllocString method.<para/>
        /// The caller is responsible for freeing the returned string via SysFreeString. Examples of strings which might be returned from this method are "JavaScript" or "NatVis".<para/>
        /// The returned string is likely to appear in the user interface of the debugger application which is hosting the data model.<para/>
        /// No two script providers may return the same name (case insensitive).
        /// </summary>
        public string Name
        {
            get
            {
                string name;
                TryGetName(out name).ThrowDbgEngNotOK();

                return name;
            }
        }

        /// <summary>
        /// The GetName method returns the name of the type of (or language of) scripts which the provider manages as a string allocated via the SysAllocString method.<para/>
        /// The caller is responsible for freeing the returned string via SysFreeString. Examples of strings which might be returned from this method are "JavaScript" or "NatVis".<para/>
        /// The returned string is likely to appear in the user interface of the debugger application which is hosting the data model.<para/>
        /// No two script providers may return the same name (case insensitive).
        /// </summary>
        /// <param name="name">The name of the type of (or language of) scripts managed via the provider. The string is allocated via SysAllocString and the caller is responsible for freeing it via SysFreeString.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetName(out string name)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string name);*/
            return Raw.GetName(out name);
        }

        #endregion
        #region Extension

        /// <summary>
        /// The GetExtension method returns the file extension for scripts managed by this provider (without the dot) as a string allocated via the SysAllocString method.<para/>
        /// The debugger application hosting the data model (with scripting support) will delegate opening of script files with this extension to the script provider.<para/>
        /// The caller is responsible for freeing the returned string via SysFreeString. Examples of strings which might be returned from this method are "js" or "NatVis".<para/>
        /// No two script providers may return the same file extension (case insensitive). A provider which wishes to handle multiple file extensions must implement multiple <see cref="IDataModelScriptProvider"/> interfaces and provide unique names and file extensions to the script manager via the implementation of these methods.
        /// </summary>
        public string Extension
        {
            get
            {
                string extension;
                TryGetExtension(out extension).ThrowDbgEngNotOK();

                return extension;
            }
        }

        /// <summary>
        /// The GetExtension method returns the file extension for scripts managed by this provider (without the dot) as a string allocated via the SysAllocString method.<para/>
        /// The debugger application hosting the data model (with scripting support) will delegate opening of script files with this extension to the script provider.<para/>
        /// The caller is responsible for freeing the returned string via SysFreeString. Examples of strings which might be returned from this method are "js" or "NatVis".<para/>
        /// No two script providers may return the same file extension (case insensitive). A provider which wishes to handle multiple file extensions must implement multiple <see cref="IDataModelScriptProvider"/> interfaces and provide unique names and file extensions to the script manager via the implementation of these methods.
        /// </summary>
        /// <param name="extension">The file extension of script files which managed by this provider is returned here. The string is allocated via SysAllocString and the caller is responsible for freeing it via SysFreeString.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetExtension(out string extension)
        {
            /*HRESULT GetExtension(
            [Out, MarshalAs(UnmanagedType.BStr)] out string extension);*/
            return Raw.GetExtension(out extension);
        }

        #endregion
        #region DefaultTemplateContent

        /// <summary>
        /// The GetDefaultTemplateContent method returns an interface for the default template content of the provider. This is content that the script provider would like pre-populated in an edit window for a newly created script.<para/>
        /// If the script provider has no templates (or has no template content which is designated as the default content), the script provider may return E_NOTIMPL from this method.
        /// </summary>
        public DataModelScriptTemplate DefaultTemplateContent
        {
            get
            {
                DataModelScriptTemplate templateContentResult;
                TryGetDefaultTemplateContent(out templateContentResult).ThrowDbgEngNotOK();

                return templateContentResult;
            }
        }

        /// <summary>
        /// The GetDefaultTemplateContent method returns an interface for the default template content of the provider. This is content that the script provider would like pre-populated in an edit window for a newly created script.<para/>
        /// If the script provider has no templates (or has no template content which is designated as the default content), the script provider may return E_NOTIMPL from this method.
        /// </summary>
        /// <param name="templateContentResult">The default template content for the script provider is returned here as a component implementing the <see cref="IDataModelScriptTemplate"/> interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetDefaultTemplateContent(out DataModelScriptTemplate templateContentResult)
        {
            /*HRESULT GetDefaultTemplateContent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptTemplate templateContent);*/
            IDataModelScriptTemplate templateContent;
            HRESULT hr = Raw.GetDefaultTemplateContent(out templateContent);

            if (hr == HRESULT.S_OK)
                templateContentResult = templateContent == null ? null : new DataModelScriptTemplate(templateContent);
            else
                templateContentResult = default(DataModelScriptTemplate);

            return hr;
        }

        #endregion
        #region CreateScript

        /// <summary>
        /// The CreateScript method is called to create a new script. The script provider must return a new and empty script represented by the returned <see cref="IDataModelScript"/> interface whenever this method is called.<para/>
        /// Note that this method is called regardless of whether a user interface is creating a new blank script for editing by the user or whether the debugger application is loading a script from disk.<para/>
        /// The provider does not get involved in file I/O. It merely handles the requests from the hosting application via streams passed to methods on <see cref="IDataModelScript"/>.
        /// </summary>
        /// <returns>A new and empty script will be returned here as a component implementing the <see cref="IDataModelScript"/> interface.</returns>
        public DataModelScript CreateScript()
        {
            DataModelScript scriptResult;
            TryCreateScript(out scriptResult).ThrowDbgEngNotOK();

            return scriptResult;
        }

        /// <summary>
        /// The CreateScript method is called to create a new script. The script provider must return a new and empty script represented by the returned <see cref="IDataModelScript"/> interface whenever this method is called.<para/>
        /// Note that this method is called regardless of whether a user interface is creating a new blank script for editing by the user or whether the debugger application is loading a script from disk.<para/>
        /// The provider does not get involved in file I/O. It merely handles the requests from the hosting application via streams passed to methods on <see cref="IDataModelScript"/>.
        /// </summary>
        /// <param name="scriptResult">A new and empty script will be returned here as a component implementing the <see cref="IDataModelScript"/> interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateScript(out DataModelScript scriptResult)
        {
            /*HRESULT CreateScript(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScript script);*/
            IDataModelScript script;
            HRESULT hr = Raw.CreateScript(out script);

            if (hr == HRESULT.S_OK)
                scriptResult = script == null ? null : new DataModelScript(script);
            else
                scriptResult = default(DataModelScript);

            return hr;
        }

        #endregion
        #region EnumerateTemplates

        /// <summary>
        /// The EnumerateTemplates method returns an enumerator which is capable of enumerating the variety of templates that are provided by the script provider.<para/>
        /// Template content is what the script provider wants to be "prefilled" into an edit window when creating a new script.<para/>
        /// If there are multiple different templates supported, those templates can be named (e.g.: "Imperative Script", "Extension Script") and the debugger application hosting the data model can choose how to present the "templates" to the user.<para/>
        /// A script provider which has no template content may return E_NOTIMPL here.
        /// </summary>
        /// <returns>An enumerator which enumerates all template content of the script provider must be returned here as a component implementing the <see cref="IDataModelScriptTemplateEnumerator"/> interface.</returns>
        public DataModelScriptTemplateEnumerator EnumerateTemplates()
        {
            DataModelScriptTemplateEnumerator enumeratorResult;
            TryEnumerateTemplates(out enumeratorResult).ThrowDbgEngNotOK();

            return enumeratorResult;
        }

        /// <summary>
        /// The EnumerateTemplates method returns an enumerator which is capable of enumerating the variety of templates that are provided by the script provider.<para/>
        /// Template content is what the script provider wants to be "prefilled" into an edit window when creating a new script.<para/>
        /// If there are multiple different templates supported, those templates can be named (e.g.: "Imperative Script", "Extension Script") and the debugger application hosting the data model can choose how to present the "templates" to the user.<para/>
        /// A script provider which has no template content may return E_NOTIMPL here.
        /// </summary>
        /// <param name="enumeratorResult">An enumerator which enumerates all template content of the script provider must be returned here as a component implementing the <see cref="IDataModelScriptTemplateEnumerator"/> interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryEnumerateTemplates(out DataModelScriptTemplateEnumerator enumeratorResult)
        {
            /*HRESULT EnumerateTemplates(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptTemplateEnumerator enumerator);*/
            IDataModelScriptTemplateEnumerator enumerator;
            HRESULT hr = Raw.EnumerateTemplates(out enumerator);

            if (hr == HRESULT.S_OK)
                enumeratorResult = enumerator == null ? null : new DataModelScriptTemplateEnumerator(enumerator);
            else
                enumeratorResult = default(DataModelScriptTemplateEnumerator);

            return hr;
        }

        #endregion
        #endregion

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
