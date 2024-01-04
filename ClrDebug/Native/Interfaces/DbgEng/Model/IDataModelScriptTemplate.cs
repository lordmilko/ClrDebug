using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any script provider wanting to have pre-filled template content implements this interface per template. Script providers can provide one or more templates which serve as starting points for users to author scripts.<para/>
    /// A debugger application which provides a built-in editor can prefill new scripts with template content as advertised by the provider through this interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1303DEC4-FA3B-4F1B-9224-B953D16BABB5")]
    [ComImport]
    public interface IDataModelScriptTemplate
    {
        /// <summary>
        /// The GetName method returns a name of the template. This may fail with E_NOTIMPL if the template does not have a name.<para/>
        /// The single default template (if such exists) is not required to have a name. All other templates are. These names may be presented in a user interface as part of a menu to select which template is to be created.
        /// </summary>
        /// <param name="templateName">The name of the template is returned here as a string allocated via the SysAllocString function. The caller is responsible for freeing this string with SysFreeString.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string templateName);

        /// <summary>
        /// The GetDescription method returns a description of the template. Such description would be presented to the user in more descriptive interfaces to help the user understand what the template is designed to do.<para/>
        /// The template may return E_NOTIMPL from this method if it does not have a description.
        /// </summary>
        /// <param name="templateDescription">The description of the template is returned here as a string allocated via the SysAllocString function. The caller is responsible for freeing this string with SysFreeString.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetDescription(
            [Out, MarshalAs(UnmanagedType.BStr)] out string templateDescription);

        /// <summary>
        /// The GetContent method returns the content (or code) of the template. This is what would be pre-filled into the edit window if a user elected to create a new script from this template.<para/>
        /// The template is responsible for creating (and returning) a standard stream over the content that the client can pull.
        /// </summary>
        /// <param name="contentStream">A newly created standard stream over the content (code) for the template. This stream may be backed by memory, a file, or whatever the implementation wishes.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetContent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IStream contentStream);
    }
}
