using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The extensibility interface to the underlying debugger.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3C2B24E1-11D0-4F86-8AE5-4DF166F73253")]
    [ComImport]
    public interface IDebugHostExtensibility
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
        HRESULT CreateFunctionAlias(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject functionObject);

        /// <summary>
        /// The DestroyFunctionAlias method undoes a prior call to the CreateFunctionAlias method. The function will no longer be available under the quick alias name.
        /// </summary>
        /// <param name="aliasName">The (quick) name of the alias being destroyed.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT DestroyFunctionAlias(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName);
    }
}
