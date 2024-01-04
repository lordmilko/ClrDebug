using ClrDebug;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any script provider wanting to have pre-filled template content implements this interface per template. Script providers can provide one or more templates which serve as starting points for users to author scripts.<para/>
    /// A debugger application which provides a built-in editor can prefill new scripts with template content as advertised by the provider through this interface.
    /// </summary>
    public class DataModelScriptTemplate : ComObject<IDataModelScriptTemplate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelScriptTemplate"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelScriptTemplate(IDataModelScriptTemplate raw) : base(raw)
        {
        }

        #region IDataModelScriptTemplate
        #region Name

        /// <summary>
        /// The GetName method returns a name of the template. This may fail with E_NOTIMPL if the template does not have a name.<para/>
        /// The single default template (if such exists) is not required to have a name. All other templates are. These names may be presented in a user interface as part of a menu to select which template is to be created.
        /// </summary>
        public string Name
        {
            get
            {
                string templateName;
                TryGetName(out templateName).ThrowDbgEngNotOK();

                return templateName;
            }
        }

        /// <summary>
        /// The GetName method returns a name of the template. This may fail with E_NOTIMPL if the template does not have a name.<para/>
        /// The single default template (if such exists) is not required to have a name. All other templates are. These names may be presented in a user interface as part of a menu to select which template is to be created.
        /// </summary>
        /// <param name="templateName">The name of the template is returned here as a string allocated via the SysAllocString function. The caller is responsible for freeing this string with SysFreeString.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetName(out string templateName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string templateName);*/
            return Raw.GetName(out templateName);
        }

        #endregion
        #region Description

        /// <summary>
        /// The GetDescription method returns a description of the template. Such description would be presented to the user in more descriptive interfaces to help the user understand what the template is designed to do.<para/>
        /// The template may return E_NOTIMPL from this method if it does not have a description.
        /// </summary>
        public string Description
        {
            get
            {
                string templateDescription;
                TryGetDescription(out templateDescription).ThrowDbgEngNotOK();

                return templateDescription;
            }
        }

        /// <summary>
        /// The GetDescription method returns a description of the template. Such description would be presented to the user in more descriptive interfaces to help the user understand what the template is designed to do.<para/>
        /// The template may return E_NOTIMPL from this method if it does not have a description.
        /// </summary>
        /// <param name="templateDescription">The description of the template is returned here as a string allocated via the SysAllocString function. The caller is responsible for freeing this string with SysFreeString.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetDescription(out string templateDescription)
        {
            /*HRESULT GetDescription(
            [Out, MarshalAs(UnmanagedType.BStr)] out string templateDescription);*/
            return Raw.GetDescription(out templateDescription);
        }

        #endregion
        #region Content

        /// <summary>
        /// The GetContent method returns the content (or code) of the template. This is what would be pre-filled into the edit window if a user elected to create a new script from this template.<para/>
        /// The template is responsible for creating (and returning) a standard stream over the content that the client can pull.
        /// </summary>
        public ComStream Content
        {
            get
            {
                ComStream contentStreamResult;
                TryGetContent(out contentStreamResult).ThrowDbgEngNotOK();

                return contentStreamResult;
            }
        }

        /// <summary>
        /// The GetContent method returns the content (or code) of the template. This is what would be pre-filled into the edit window if a user elected to create a new script from this template.<para/>
        /// The template is responsible for creating (and returning) a standard stream over the content that the client can pull.
        /// </summary>
        /// <param name="contentStreamResult">A newly created standard stream over the content (code) for the template. This stream may be backed by memory, a file, or whatever the implementation wishes.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetContent(out ComStream contentStreamResult)
        {
            /*HRESULT GetContent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IStream contentStream);*/
            IStream contentStream;
            HRESULT hr = Raw.GetContent(out contentStream);

            if (hr == HRESULT.S_OK)
                contentStreamResult = contentStream == null ? null : new ComStream(contentStream);
            else
                contentStreamResult = default(ComStream);

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
