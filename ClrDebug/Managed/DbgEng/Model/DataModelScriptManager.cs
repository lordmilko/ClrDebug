namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The core interface to the script management capabilities of the data model manager. Queried from the data model manager.
    /// </summary>
    public class DataModelScriptManager : ComObject<IDataModelScriptManager>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelScriptManager"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelScriptManager(IDataModelScriptManager raw) : base(raw)
        {
        }

        #region IDataModelScriptManager
        #region DefaultNameBinder

        /// <summary>
        /// The GetDefaultNameBinder method returns the data model's default script name binder. A name binder is a component which resolves a name within the context of an object.<para/>
        /// For instance, given the expression "foo.bar", a name binder is called upon to resolve the name bar in the context of object foo.<para/>
        /// The binder returned here follows a set of default rules for the data model. Script providers can use this binder to provide consistency in name resolution across providers.
        /// </summary>
        public DataModelNameBinder DefaultNameBinder
        {
            get
            {
                DataModelNameBinder ppNameBinderResult;
                TryGetDefaultNameBinder(out ppNameBinderResult).ThrowDbgEngNotOK();

                return ppNameBinderResult;
            }
        }

        /// <summary>
        /// The GetDefaultNameBinder method returns the data model's default script name binder. A name binder is a component which resolves a name within the context of an object.<para/>
        /// For instance, given the expression "foo.bar", a name binder is called upon to resolve the name bar in the context of object foo.<para/>
        /// The binder returned here follows a set of default rules for the data model. Script providers can use this binder to provide consistency in name resolution across providers.
        /// </summary>
        /// <param name="ppNameBinderResult">The default name binder will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        /// <remarks>
        /// The <see cref="IDataModelNameBinder"/> topic provides more information on how a name binder can associate names
        /// in a context with objects or symbols.
        /// </remarks>
        public HRESULT TryGetDefaultNameBinder(out DataModelNameBinder ppNameBinderResult)
        {
            /*HRESULT GetDefaultNameBinder(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelNameBinder ppNameBinder);*/
            IDataModelNameBinder ppNameBinder;
            HRESULT hr = Raw.GetDefaultNameBinder(out ppNameBinder);

            if (hr == HRESULT.S_OK)
                ppNameBinderResult = ppNameBinder == null ? null : new DataModelNameBinder(ppNameBinder);
            else
                ppNameBinderResult = default(DataModelNameBinder);

            return hr;
        }

        #endregion
        #region RegisterScriptProvider

        /// <summary>
        /// The RegisterScriptProvider method informs the data model that a new script provider exists which is capable of bridging a new language to the data model.<para/>
        /// When this method is called, the script manager will immediately call back the given script provider and inquire about the properties of the scripts it manages.<para/>
        /// If there is already a provider registered under the name or file extension which the given script provider indicates, this method will fail.<para/>
        /// Only a single script provider can be registered as the handler for a particular name or file extension.
        /// </summary>
        /// <param name="provider">The script provider being registered with the script manager. For more information about script providers, see <see cref="IDataModelScriptProvider"/>.</param>
        public void RegisterScriptProvider(IDataModelScriptProvider provider)
        {
            TryRegisterScriptProvider(provider).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The RegisterScriptProvider method informs the data model that a new script provider exists which is capable of bridging a new language to the data model.<para/>
        /// When this method is called, the script manager will immediately call back the given script provider and inquire about the properties of the scripts it manages.<para/>
        /// If there is already a provider registered under the name or file extension which the given script provider indicates, this method will fail.<para/>
        /// Only a single script provider can be registered as the handler for a particular name or file extension.
        /// </summary>
        /// <param name="provider">The script provider being registered with the script manager. For more information about script providers, see <see cref="IDataModelScriptProvider"/>.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryRegisterScriptProvider(IDataModelScriptProvider provider)
        {
            /*HRESULT RegisterScriptProvider(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptProvider provider);*/
            return Raw.RegisterScriptProvider(provider);
        }

        #endregion
        #region UnregisterScriptProvider

        /// <summary>
        /// The UnregisterScriptProvider method undoes a call to the RegisterScriptProvider method. The name and file extension given by the inpassed script provider will no longer be associated with it.<para/>
        /// It is important to note that there may be a significant number of outstanding COM references to the script provider even after unregistration.<para/>
        /// This method only prevents the loading/creation of scripts of the type that the given script provider manages. If a script loaded by that provider is still loaded or has manipulated the object model of the debugger (or data model), those manipulations may still have references back into the script.<para/>
        /// There may be data models, methods, or objects which directly reference constructs in the script. A script provider must be prepared to deal with that.
        /// </summary>
        /// <param name="provider">The script provider being unregistered from the script manager. Scripts of the given type and file extension will no longer be able to be loaded/created.</param>
        public void UnregisterScriptProvider(IDataModelScriptProvider provider)
        {
            TryUnregisterScriptProvider(provider).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The UnregisterScriptProvider method undoes a call to the RegisterScriptProvider method. The name and file extension given by the inpassed script provider will no longer be associated with it.<para/>
        /// It is important to note that there may be a significant number of outstanding COM references to the script provider even after unregistration.<para/>
        /// This method only prevents the loading/creation of scripts of the type that the given script provider manages. If a script loaded by that provider is still loaded or has manipulated the object model of the debugger (or data model), those manipulations may still have references back into the script.<para/>
        /// There may be data models, methods, or objects which directly reference constructs in the script. A script provider must be prepared to deal with that.
        /// </summary>
        /// <param name="provider">The script provider being unregistered from the script manager. Scripts of the given type and file extension will no longer be able to be loaded/created.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryUnregisterScriptProvider(IDataModelScriptProvider provider)
        {
            /*HRESULT UnregisterScriptProvider(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptProvider provider);*/
            return Raw.UnregisterScriptProvider(provider);
        }

        #endregion
        #region FindProviderForScriptType

        /// <summary>
        /// The FindProviderForScriptExtension method searches the script manager for a provider which has claims to support a given file extension as indicated by the scriptExtension argument.<para/>
        /// If one cannot be found, this method will fail; otherwise, such script provider will be returned to the caller.
        /// </summary>
        /// <param name="scriptType">A string which describes the type of script being searched for (e.g.: JavaScript)</param>
        /// <returns>If a provider can be found which supports the type of script given by the scriptType argument, it will be returned here.</returns>
        public DataModelScriptProvider FindProviderForScriptType(string scriptType)
        {
            DataModelScriptProvider providerResult;
            TryFindProviderForScriptType(scriptType, out providerResult).ThrowDbgEngNotOK();

            return providerResult;
        }

        /// <summary>
        /// The FindProviderForScriptExtension method searches the script manager for a provider which has claims to support a given file extension as indicated by the scriptExtension argument.<para/>
        /// If one cannot be found, this method will fail; otherwise, such script provider will be returned to the caller.
        /// </summary>
        /// <param name="scriptType">A string which describes the type of script being searched for (e.g.: JavaScript)</param>
        /// <param name="providerResult">If a provider can be found which supports the type of script given by the scriptType argument, it will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryFindProviderForScriptType(string scriptType, out DataModelScriptProvider providerResult)
        {
            /*HRESULT FindProviderForScriptType(
            [In, MarshalAs(UnmanagedType.LPWStr)] string scriptType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptProvider provider);*/
            IDataModelScriptProvider provider;
            HRESULT hr = Raw.FindProviderForScriptType(scriptType, out provider);

            if (hr == HRESULT.S_OK)
                providerResult = provider == null ? null : new DataModelScriptProvider(provider);
            else
                providerResult = default(DataModelScriptProvider);

            return hr;
        }

        #endregion
        #region FindProviderForScriptExtension

        /// <summary>
        /// The FindProviderForScriptExtension method searches the script manager for a provider which has claims to support a given file extension as indicated by the scriptExtension argument.<para/>
        /// If one cannot be found, this method will fail; otherwise, such script provider will be returned to the caller.
        /// </summary>
        /// <param name="scriptExtension">The file extension for which to find a scriptprovider (e.g.: js).</param>
        /// <returns>If a provider can be found which handles the file extension given by the scriptExtension argument, it will be returned here.</returns>
        public DataModelScriptProvider FindProviderForScriptExtension(string scriptExtension)
        {
            DataModelScriptProvider providerResult;
            TryFindProviderForScriptExtension(scriptExtension, out providerResult).ThrowDbgEngNotOK();

            return providerResult;
        }

        /// <summary>
        /// The FindProviderForScriptExtension method searches the script manager for a provider which has claims to support a given file extension as indicated by the scriptExtension argument.<para/>
        /// If one cannot be found, this method will fail; otherwise, such script provider will be returned to the caller.
        /// </summary>
        /// <param name="scriptExtension">The file extension for which to find a scriptprovider (e.g.: js).</param>
        /// <param name="providerResult">If a provider can be found which handles the file extension given by the scriptExtension argument, it will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryFindProviderForScriptExtension(string scriptExtension, out DataModelScriptProvider providerResult)
        {
            /*HRESULT FindProviderForScriptExtension(
            [In, MarshalAs(UnmanagedType.LPWStr)] string scriptExtension,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptProvider provider);*/
            IDataModelScriptProvider provider;
            HRESULT hr = Raw.FindProviderForScriptExtension(scriptExtension, out provider);

            if (hr == HRESULT.S_OK)
                providerResult = provider == null ? null : new DataModelScriptProvider(provider);
            else
                providerResult = default(DataModelScriptProvider);

            return hr;
        }

        #endregion
        #region EnumerateScriptProviders

        /// <summary>
        /// The EnumerateScriptProviders method will return an enumerator which will enumerate every script provider that has been registered with the script manager via a prior call to the RegisterScriptProvider method.
        /// </summary>
        /// <returns>An enumerator which will enumerate every script provider registered via a prior call to the RegisterScriptProvider method will be returned here.</returns>
        /// <remarks>
        /// The EnumerateScriptProviders method will return an enumerator of the following form:
        /// </remarks>
        public DataModelScriptProviderEnumerator EnumerateScriptProviders()
        {
            DataModelScriptProviderEnumerator enumeratorResult;
            TryEnumerateScriptProviders(out enumeratorResult).ThrowDbgEngNotOK();

            return enumeratorResult;
        }

        /// <summary>
        /// The EnumerateScriptProviders method will return an enumerator which will enumerate every script provider that has been registered with the script manager via a prior call to the RegisterScriptProvider method.
        /// </summary>
        /// <param name="enumeratorResult">An enumerator which will enumerate every script provider registered via a prior call to the RegisterScriptProvider method will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        /// <remarks>
        /// The EnumerateScriptProviders method will return an enumerator of the following form:
        /// </remarks>
        public HRESULT TryEnumerateScriptProviders(out DataModelScriptProviderEnumerator enumeratorResult)
        {
            /*HRESULT EnumerateScriptProviders(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptProviderEnumerator enumerator);*/
            IDataModelScriptProviderEnumerator enumerator;
            HRESULT hr = Raw.EnumerateScriptProviders(out enumerator);

            if (hr == HRESULT.S_OK)
                enumeratorResult = enumerator == null ? null : new DataModelScriptProviderEnumerator(enumerator);
            else
                enumeratorResult = default(DataModelScriptProviderEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
