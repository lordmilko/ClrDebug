using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("91CC55E7-2A22-4494-9710-B729DAB48F71")]
    [ComImport]
    public interface IDebugHostExtensibility2 : IDebugHostExtensibility
    {
        /// <summary>
        /// The CreateFunctionAlias method creates a "function alias", a "quick alias" for a method implemented in some extension.<para/>
        /// The meaning of this alias is host specific. It may extend the host's expression evaluator with the function or it may do something entirely different.<para/>
        /// For Debugging Tools for Windows, a function alias:
        /// </summary>
        /// <param name="aliasName">The (quick) name of the alias being created/registered.</param>
        /// <param name="functionObject">A data model method (an <see cref="IModelMethod"/> boxed into an <see cref="IModelObject"/>) which implements the functionality of the function alias.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT CreateFunctionAlias(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject functionObject);

        /// <summary>
        /// The DestroyFunctionAlias method undoes a prior call to the CreateFunctionAlias method. The function will no longer be available under the quick alias name.
        /// </summary>
        /// <param name="aliasName">The (quick) name of the alias being destroyed.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT DestroyFunctionAlias(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName);
        
        [PreserveSig]
        HRESULT CreateFunctionAliasWithMetadata(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject functionObject,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);
    }
}
