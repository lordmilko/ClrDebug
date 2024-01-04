using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The extensibility interface to the underlying debugger.
    /// </summary>
    public class DebugHostExtensibility : ComObject<IDebugHostExtensibility>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostExtensibility"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostExtensibility(IDebugHostExtensibility raw) : base(raw)
        {
        }

        #region IDebugHostExtensibility
        #region CreateFunctionAlias

        /// <summary>
        /// The CreateFunctionAlias method creates a "function alias", a "quick alias" for a method implemented in some extension.<para/>
        /// The meaning of this alias is host specific. It may extend the host's expression evaluator with the function or it may do something entirely different.<para/>
        /// For Debugging Tools for Windows, a function alias:
        /// </summary>
        /// <param name="aliasName">The (quick) name of the alias being created/registered.</param>
        /// <param name="functionObject">A data model method (an <see cref="IModelMethod"/> boxed into an <see cref="IModelObject"/>) which implements the functionality of the function alias.</param>
        public void CreateFunctionAlias(string aliasName, IModelObject functionObject)
        {
            TryCreateFunctionAlias(aliasName, functionObject).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The CreateFunctionAlias method creates a "function alias", a "quick alias" for a method implemented in some extension.<para/>
        /// The meaning of this alias is host specific. It may extend the host's expression evaluator with the function or it may do something entirely different.<para/>
        /// For Debugging Tools for Windows, a function alias:
        /// </summary>
        /// <param name="aliasName">The (quick) name of the alias being created/registered.</param>
        /// <param name="functionObject">A data model method (an <see cref="IModelMethod"/> boxed into an <see cref="IModelObject"/>) which implements the functionality of the function alias.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryCreateFunctionAlias(string aliasName, IModelObject functionObject)
        {
            /*HRESULT CreateFunctionAlias(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject functionObject);*/
            return Raw.CreateFunctionAlias(aliasName, functionObject);
        }

        #endregion
        #region DestroyFunctionAlias

        /// <summary>
        /// The DestroyFunctionAlias method undoes a prior call to the CreateFunctionAlias method. The function will no longer be available under the quick alias name.
        /// </summary>
        /// <param name="aliasName">The (quick) name of the alias being destroyed.</param>
        public void DestroyFunctionAlias(string aliasName)
        {
            TryDestroyFunctionAlias(aliasName).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The DestroyFunctionAlias method undoes a prior call to the CreateFunctionAlias method. The function will no longer be available under the quick alias name.
        /// </summary>
        /// <param name="aliasName">The (quick) name of the alias being destroyed.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryDestroyFunctionAlias(string aliasName)
        {
            /*HRESULT DestroyFunctionAlias(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName);*/
            return Raw.DestroyFunctionAlias(aliasName);
        }

        #endregion
        #endregion
        #region IDebugHostExtensibility2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostExtensibility2 Raw2 => (IDebugHostExtensibility2) Raw;

        #region CreateFunctionAliasWithMetadata

        public void CreateFunctionAliasWithMetadata(string aliasName, IModelObject functionObject, IKeyStore metadata)
        {
            TryCreateFunctionAliasWithMetadata(aliasName, functionObject, metadata).ThrowDbgEngNotOK();
        }

        public HRESULT TryCreateFunctionAliasWithMetadata(string aliasName, IModelObject functionObject, IKeyStore metadata)
        {
            /*HRESULT CreateFunctionAliasWithMetadata(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject functionObject,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);*/
            return Raw2.CreateFunctionAliasWithMetadata(aliasName, functionObject, metadata);
        }

        #endregion
        #endregion
        #region IDebugHostExtensibility3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostExtensibility3 Raw3 => (IDebugHostExtensibility3) Raw;

        #region ExtendHostContext

        public int ExtendHostContext(int blobSize, Guid identifier)
        {
            int blobId;
            TryExtendHostContext(blobSize, identifier, out blobId).ThrowDbgEngNotOK();

            return blobId;
        }

        public HRESULT TryExtendHostContext(int blobSize, Guid identifier, out int blobId)
        {
            /*HRESULT ExtendHostContext(
            [In] int blobSize,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid identifier,
            [Out] out int blobId);*/
            return Raw3.ExtendHostContext(blobSize, identifier, out blobId);
        }

        #endregion
        #region QueryHostContextExtension

        public QueryHostContextExtensionResult QueryHostContextExtension(Guid identifier)
        {
            QueryHostContextExtensionResult result;
            TryQueryHostContextExtension(identifier, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryQueryHostContextExtension(Guid identifier, out QueryHostContextExtensionResult result)
        {
            /*HRESULT QueryHostContextExtension(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid identifier,
            [Out] out int blobId,
            [Out] out int blobSize);*/
            int blobId;
            int blobSize;
            HRESULT hr = Raw3.QueryHostContextExtension(identifier, out blobId, out blobSize);

            if (hr == HRESULT.S_OK)
                result = new QueryHostContextExtensionResult(blobId, blobSize);
            else
                result = default(QueryHostContextExtensionResult);

            return hr;
        }

        #endregion
        #region ReleaseHostContextExtension

        public void ReleaseHostContextExtension(int blobId)
        {
            TryReleaseHostContextExtension(blobId).ThrowDbgEngNotOK();
        }

        public HRESULT TryReleaseHostContextExtension(int blobId)
        {
            /*HRESULT ReleaseHostContextExtension(
            [In] int blobId);*/
            return Raw3.ReleaseHostContextExtension(blobId);
        }

        #endregion
        #endregion
    }
}
