using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An interface to a particular symbol.
    /// </summary>
    public abstract class DebugHostSymbol : ComObject<IDebugHostSymbol>
    {
        public static DebugHostSymbol New(IDebugHostSymbol value)
        {
            if (value == null)
                return null;

            if (value is IDebugHostBaseClass)
                return new DebugHostBaseClass((IDebugHostBaseClass) value);

            if (value is IDebugHostConstant)
                return new DebugHostConstant((IDebugHostConstant) value);

            if (value is IDebugHostData)
                return new DebugHostData((IDebugHostData) value);

            if (value is IDebugHostField)
                return new DebugHostField((IDebugHostField) value);

            if (value is IDebugHostModule)
                return new DebugHostModule((IDebugHostModule) value);

            if (value is IDebugHostPublic)
                return new DebugHostPublic((IDebugHostPublic) value);

            if (value is IDebugHostType)
                return new DebugHostType((IDebugHostType) value);

            throw new NotImplementedException("Encountered an 'IDebugHostSymbol' interface of an unknown type. Cannot create wrapper type.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostSymbol"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        protected DebugHostSymbol(IDebugHostSymbol raw) : base(raw)
        {
        }

        #region IDebugHostSymbol
        #region Context

        /// <summary>
        /// The GetContext method returns the context where the symbol is valid. While this will represent things such as the debug target and process/address space in which the symbol exists, it may not be as specific as a context retrieved from other means (e.g.: from an <see cref="IModelObject"/>).
        /// </summary>
        public DebugHostContext Context
        {
            get
            {
                DebugHostContext contextResult;
                TryGetContext(out contextResult).ThrowDbgEngNotOK();

                return contextResult;
            }
        }

        /// <summary>
        /// The GetContext method returns the context where the symbol is valid. While this will represent things such as the debug target and process/address space in which the symbol exists, it may not be as specific as a context retrieved from other means (e.g.: from an <see cref="IModelObject"/>).
        /// </summary>
        /// <param name="contextResult">The host context in which the symbol is located will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetContext(out DebugHostContext contextResult)
        {
            /*HRESULT GetContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContext context);*/
            IDebugHostContext context;
            HRESULT hr = Raw.GetContext(out context);

            if (hr == HRESULT.S_OK)
                contextResult = context == null ? null : new DebugHostContext(context);
            else
                contextResult = default(DebugHostContext);

            return hr;
        }

        #endregion
        #region SymbolKind

        /// <summary>
        /// Gets the kind of symbol that this is (e.g.: a field, a base class, a type, etc...).
        /// </summary>
        public SymbolKind SymbolKind
        {
            get
            {
                SymbolKind kind;
                TryGetSymbolKind(out kind).ThrowDbgEngNotOK();

                return kind;
            }
        }

        /// <summary>
        /// Gets the kind of symbol that this is (e.g.: a field, a base class, a type, etc...).
        /// </summary>
        /// <param name="kind">The kind of symbol (e.g.: a type, field, base class, etc…) will be returned here. For more information, see <see cref="SymbolKind"/>.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetSymbolKind(out SymbolKind kind)
        {
            /*HRESULT GetSymbolKind(
            [Out] out SymbolKind kind);*/
            return Raw.GetSymbolKind(out kind);
        }

        #endregion
        #region Name

        /// <summary>
        /// Returns the name of the symbol if the symbol has a name. If the symbol does not have a name, an error is returned.
        /// </summary>
        public string Name
        {
            get
            {
                string symbolName;
                TryGetName(out symbolName).ThrowDbgEngNotOK();

                return symbolName;
            }
        }

        /// <summary>
        /// Returns the name of the symbol if the symbol has a name. If the symbol does not have a name, an error is returned.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetName(out string symbolName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string symbolName);*/
            return Raw.GetName(out symbolName);
        }

        #endregion
        #region Type

        /// <summary>
        /// Returns the type (e.g.: "int *") of the symbol if the symbol has a type. If the symbol does not have a type, an error is returned.
        /// </summary>
        public DebugHostType Type
        {
            get
            {
                DebugHostType typeResult;
                TryGetType(out typeResult).ThrowDbgEngNotOK();

                return typeResult;
            }
        }

        /// <summary>
        /// Returns the type (e.g.: "int *") of the symbol if the symbol has a type. If the symbol does not have a type, an error is returned.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetType(out DebugHostType typeResult)
        {
            /*HRESULT GetType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);*/
            IDebugHostType type;
            HRESULT hr = Raw.GetType(out type);

            if (hr == HRESULT.S_OK)
                typeResult = type == null ? null : new DebugHostType(type);
            else
                typeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #region ContainingModule

        /// <summary>
        /// Returns the module which contains this symbol if the symbol has a containing module. If the symbol does not have a containing module, an error is returned.
        /// </summary>
        public DebugHostModule ContainingModule
        {
            get
            {
                DebugHostModule containingModuleResult;
                TryGetContainingModule(out containingModuleResult).ThrowDbgEngNotOK();

                return containingModuleResult;
            }
        }

        /// <summary>
        /// Returns the module which contains this symbol if the symbol has a containing module. If the symbol does not have a containing module, an error is returned.
        /// </summary>
        /// <param name="containingModuleResult">The module which contains the symbol will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetContainingModule(out DebugHostModule containingModuleResult)
        {
            /*HRESULT GetContainingModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModule containingModule);*/
            IDebugHostModule containingModule;
            HRESULT hr = Raw.GetContainingModule(out containingModule);

            if (hr == HRESULT.S_OK)
                containingModuleResult = containingModule == null ? null : new DebugHostModule(containingModule);
            else
                containingModuleResult = default(DebugHostModule);

            return hr;
        }

        #endregion
        #region EnumerateChildren

        /// <summary>
        /// The EnumerateChildren method returns an enumerator which will enumerate all children of a given symbol. For a C++ type, for example, the base classes, fields, member functions, and the like are all considered children of the type symbol.
        /// </summary>
        /// <param name="kind">Indicates what kinds of child symbols the caller wishes to enumerate. If the flat value Symbol is passed, all kinds of child symbols will be enumerated.</param>
        /// <param name="name">If specified, only child symbols with a name as given in this argument will be enumerated.</param>
        /// <returns>An enumerator which enumerates child symbols of the specified kind and name will be returned here.</returns>
        public DebugHostSymbolEnumerator EnumerateChildren(SymbolKind kind, string name)
        {
            DebugHostSymbolEnumerator ppEnumResult;
            TryEnumerateChildren(kind, name, out ppEnumResult).ThrowDbgEngNotOK();

            return ppEnumResult;
        }

        /// <summary>
        /// The EnumerateChildren method returns an enumerator which will enumerate all children of a given symbol. For a C++ type, for example, the base classes, fields, member functions, and the like are all considered children of the type symbol.
        /// </summary>
        /// <param name="kind">Indicates what kinds of child symbols the caller wishes to enumerate. If the flat value Symbol is passed, all kinds of child symbols will be enumerated.</param>
        /// <param name="name">If specified, only child symbols with a name as given in this argument will be enumerated.</param>
        /// <param name="ppEnumResult">An enumerator which enumerates child symbols of the specified kind and name will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryEnumerateChildren(SymbolKind kind, string name, out DebugHostSymbolEnumerator ppEnumResult)
        {
            /*HRESULT EnumerateChildren(
            [In] SymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator ppEnum);*/
            IDebugHostSymbolEnumerator ppEnum;
            HRESULT hr = Raw.EnumerateChildren(kind, name, out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = DebugHostSymbolEnumerator.New(ppEnum);
            else
                ppEnumResult = default(DebugHostSymbolEnumerator);

            return hr;
        }

        #endregion
        #region CompareAgainst

        /// <summary>
        /// Compares two symbols for equality. A host is under no obligation to ensure that there is interface pointer equality for two identical symbols.<para/>
        /// This can be used to check for equality. Note that presently, "comparisonFlags" is reserved.
        /// </summary>
        /// <param name="pComparisonSymbol">The symbol to compare against.</param>
        /// <param name="comparisonFlags">Reserved. Must be set to 0.</param>
        /// <returns>An indication of whether the symbols are equal will be returned here.</returns>
        public bool CompareAgainst(IDebugHostSymbol pComparisonSymbol, int comparisonFlags)
        {
            bool pMatches;
            TryCompareAgainst(pComparisonSymbol, comparisonFlags, out pMatches).ThrowDbgEngNotOK();

            return pMatches;
        }

        /// <summary>
        /// Compares two symbols for equality. A host is under no obligation to ensure that there is interface pointer equality for two identical symbols.<para/>
        /// This can be used to check for equality. Note that presently, "comparisonFlags" is reserved.
        /// </summary>
        /// <param name="pComparisonSymbol">The symbol to compare against.</param>
        /// <param name="comparisonFlags">Reserved. Must be set to 0.</param>
        /// <param name="pMatches">An indication of whether the symbols are equal will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryCompareAgainst(IDebugHostSymbol pComparisonSymbol, int comparisonFlags, out bool pMatches)
        {
            /*HRESULT CompareAgainst(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostSymbol pComparisonSymbol,
            [In] int comparisonFlags,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pMatches);*/
            return Raw.CompareAgainst(pComparisonSymbol, comparisonFlags, out pMatches);
        }

        #endregion
        #endregion
        #region IDebugHostSymbol2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostSymbol2 Raw2 => (IDebugHostSymbol2) Raw;

        #region Language

        /// <summary>
        /// If the symbol can identify the language for which it applies, this returns an identifier for such. Many symbols will NOT be able to make this determination.<para/>
        /// In such cases, this method will fail. It is also possible that the host does not understand the language or there is no defined LanguageKind.<para/>
        /// In such cases, LanguageUnknown will be returned and the method will succeed.
        /// </summary>
        public LanguageKind Language
        {
            get
            {
                LanguageKind pKind;
                TryGetLanguage(out pKind).ThrowDbgEngNotOK();

                return pKind;
            }
        }

        /// <summary>
        /// If the symbol can identify the language for which it applies, this returns an identifier for such. Many symbols will NOT be able to make this determination.<para/>
        /// In such cases, this method will fail. It is also possible that the host does not understand the language or there is no defined LanguageKind.<para/>
        /// In such cases, LanguageUnknown will be returned and the method will succeed.
        /// </summary>
        /// <param name="pKind">If it is possible to determine from the symbolic information, the language in which the given symbol was defined is returned here.<para/>
        /// This may be indeterminate for many symbols.</param>
        /// <returns>This method returns HRESULT which indicate success or failure.</returns>
        public HRESULT TryGetLanguage(out LanguageKind pKind)
        {
            /*HRESULT GetLanguage(
            [Out] out LanguageKind pKind);*/
            return Raw2.GetLanguage(out pKind);
        }

        #endregion
        #region EnumerateChildrenEx

        /// <summary>
        /// Enumerates all child symbols of the given type, name, and extended information which is present. This behaves identically to EnumerateChildren when searchInfo is nullptr.<para/>
        /// SymbolType::Symbolcan be used to search to search for any kind of child. Note that if name is nullptr, children of any name will be produced by the resulting enumerator.
        /// </summary>
        /// <param name="kind">Indicates what kinds of child symbols the caller wishes to enumerate. If the flat value Symbol is passed, all kinds of child symbols will be enumerated.</param>
        /// <param name="name">If specified, only child symbols with a name as given in this argument will be enumerated.</param>
        /// <param name="searchInfo">A pointer to a <see cref="SymbolSearchInfo"/> which describes attributes of how the symbol search should proceed.<para/>
        /// The caller should ensure that the HeaderSize and InfoSize fields of the SymbolSearchInfo are filled out appropriately prior to passing the structure to this method.<para/>
        /// For searches involving types, a TypeSearchInfo structure follows.</param>
        /// <returns>An enumerator which enumerates child symbols of the specified kind and name will be returned here.</returns>
        public DebugHostSymbolEnumerator EnumerateChildrenEx(SymbolKind kind, string name, IntPtr searchInfo)
        {
            DebugHostSymbolEnumerator ppEnumResult;
            TryEnumerateChildrenEx(kind, name, searchInfo, out ppEnumResult).ThrowDbgEngNotOK();

            return ppEnumResult;
        }

        /// <summary>
        /// Enumerates all child symbols of the given type, name, and extended information which is present. This behaves identically to EnumerateChildren when searchInfo is nullptr.<para/>
        /// SymbolType::Symbolcan be used to search to search for any kind of child. Note that if name is nullptr, children of any name will be produced by the resulting enumerator.
        /// </summary>
        /// <param name="kind">Indicates what kinds of child symbols the caller wishes to enumerate. If the flat value Symbol is passed, all kinds of child symbols will be enumerated.</param>
        /// <param name="name">If specified, only child symbols with a name as given in this argument will be enumerated.</param>
        /// <param name="searchInfo">A pointer to a <see cref="SymbolSearchInfo"/> which describes attributes of how the symbol search should proceed.<para/>
        /// The caller should ensure that the HeaderSize and InfoSize fields of the SymbolSearchInfo are filled out appropriately prior to passing the structure to this method.<para/>
        /// For searches involving types, a TypeSearchInfo structure follows.</param>
        /// <param name="ppEnumResult">An enumerator which enumerates child symbols of the specified kind and name will be returned here.</param>
        /// <returns>This method returns HRESULT which indicate success or failure.</returns>
        public HRESULT TryEnumerateChildrenEx(SymbolKind kind, string name, IntPtr searchInfo, out DebugHostSymbolEnumerator ppEnumResult)
        {
            /*HRESULT EnumerateChildrenEx(
            [In] SymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] IntPtr searchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator ppEnum);*/
            IDebugHostSymbolEnumerator ppEnum;
            HRESULT hr = Raw2.EnumerateChildrenEx(kind, name, searchInfo, out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = DebugHostSymbolEnumerator.New(ppEnum);
            else
                ppEnumResult = default(DebugHostSymbolEnumerator);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugHostSymbol3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostSymbol3 Raw3 => (IDebugHostSymbol3) Raw;

        #region CompilerInformation

        public GetCompilerInformationResult CompilerInformation
        {
            get
            {
                GetCompilerInformationResult result;
                TryGetCompilerInformation(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetCompilerInformation(out GetCompilerInformationResult result)
        {
            /*HRESULT GetCompilerInformation(
            [Out] out KnownCompiler pCompilerId,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pCompilerString);*/
            KnownCompiler pCompilerId;
            string pCompilerString;
            HRESULT hr = Raw3.GetCompilerInformation(out pCompilerId, out pCompilerString);

            if (hr == HRESULT.S_OK)
                result = new GetCompilerInformationResult(pCompilerId, pCompilerString);
            else
                result = default(GetCompilerInformationResult);

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
