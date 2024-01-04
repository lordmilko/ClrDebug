using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any script provider implementing a bridge between a dynamic language and the data model must implement this interface to represent the provider.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("513461E0-4FCA-48CE-8658-32F3E2056F3B")]
    [ComImport]
    public interface IDataModelScriptProvider
    {
        /// <summary>
        /// The GetName method returns the name of the type of (or language of) scripts which the provider manages as a string allocated via the SysAllocString method.<para/>
        /// The caller is responsible for freeing the returned string via SysFreeString. Examples of strings which might be returned from this method are "JavaScript" or "NatVis".<para/>
        /// The returned string is likely to appear in the user interface of the debugger application which is hosting the data model.<para/>
        /// No two script providers may return the same name (case insensitive).
        /// </summary>
        /// <param name="name">The name of the type of (or language of) scripts managed via the provider. The string is allocated via SysAllocString and the caller is responsible for freeing it via SysFreeString.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string name);

        /// <summary>
        /// The GetExtension method returns the file extension for scripts managed by this provider (without the dot) as a string allocated via the SysAllocString method.<para/>
        /// The debugger application hosting the data model (with scripting support) will delegate opening of script files with this extension to the script provider.<para/>
        /// The caller is responsible for freeing the returned string via SysFreeString. Examples of strings which might be returned from this method are "js" or "NatVis".<para/>
        /// No two script providers may return the same file extension (case insensitive). A provider which wishes to handle multiple file extensions must implement multiple <see cref="IDataModelScriptProvider"/> interfaces and provide unique names and file extensions to the script manager via the implementation of these methods.
        /// </summary>
        /// <param name="extension">The file extension of script files which managed by this provider is returned here. The string is allocated via SysAllocString and the caller is responsible for freeing it via SysFreeString.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetExtension(
            [Out, MarshalAs(UnmanagedType.BStr)] out string extension);

        /// <summary>
        /// The CreateScript method is called to create a new script. The script provider must return a new and empty script represented by the returned <see cref="IDataModelScript"/> interface whenever this method is called.<para/>
        /// Note that this method is called regardless of whether a user interface is creating a new blank script for editing by the user or whether the debugger application is loading a script from disk.<para/>
        /// The provider does not get involved in file I/O. It merely handles the requests from the hosting application via streams passed to methods on <see cref="IDataModelScript"/>.
        /// </summary>
        /// <param name="script">A new and empty script will be returned here as a component implementing the <see cref="IDataModelScript"/> interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT CreateScript(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScript script);

        /// <summary>
        /// The GetDefaultTemplateContent method returns an interface for the default template content of the provider. This is content that the script provider would like pre-populated in an edit window for a newly created script.<para/>
        /// If the script provider has no templates (or has no template content which is designated as the default content), the script provider may return E_NOTIMPL from this method.
        /// </summary>
        /// <param name="templateContent">The default template content for the script provider is returned here as a component implementing the <see cref="IDataModelScriptTemplate"/> interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetDefaultTemplateContent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptTemplate templateContent);

        /// <summary>
        /// The EnumerateTemplates method returns an enumerator which is capable of enumerating the variety of templates that are provided by the script provider.<para/>
        /// Template content is what the script provider wants to be "prefilled" into an edit window when creating a new script.<para/>
        /// If there are multiple different templates supported, those templates can be named (e.g.: "Imperative Script", "Extension Script") and the debugger application hosting the data model can choose how to present the "templates" to the user.<para/>
        /// A script provider which has no template content may return E_NOTIMPL here.
        /// </summary>
        /// <param name="enumerator">An enumerator which enumerates all template content of the script provider must be returned here as a component implementing the <see cref="IDataModelScriptTemplateEnumerator"/> interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT EnumerateTemplates(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptTemplateEnumerator enumerator);
    }
}
