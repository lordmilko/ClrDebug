namespace ClrDebug.DbgEng
{
    public class SvcSymbol : ComObject<ISvcSymbol>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbol"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbol(ISvcSymbol raw) : base(raw)
        {
        }

        #region ISvcSymbol
        #region SymbolKind

        /// <summary>
        /// Gets the kind of symbol that this is (e.g.: a field, a base class, a type, etc...).
        /// </summary>
        public SvcSymbolKind SymbolKind
        {
            get
            {
                SvcSymbolKind kind;
                TryGetSymbolKind(out kind).ThrowDbgEngNotOK();

                return kind;
            }
        }

        /// <summary>
        /// Gets the kind of symbol that this is (e.g.: a field, a base class, a type, etc...).
        /// </summary>
        public HRESULT TryGetSymbolKind(out SvcSymbolKind kind)
        {
            /*HRESULT GetSymbolKind(
            [Out] out SvcSymbolKind kind);*/
            return Raw.GetSymbolKind(out kind);
        }

        #endregion
        #region Name

        /// <summary>
        /// Gets the name of the symbol (e.g.: MyMethod).
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
        /// Gets the name of the symbol (e.g.: MyMethod).
        /// </summary>
        public HRESULT TryGetName(out string symbolName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string symbolName);*/
            return Raw.GetName(out symbolName);
        }

        #endregion
        #region QualifiedName

        /// <summary>
        /// Gets the qualified name of the symbol (e.g.: MyNamespace::MyClass::MyMethod).
        /// </summary>
        public string QualifiedName
        {
            get
            {
                string qualifiedName;
                TryGetQualifiedName(out qualifiedName).ThrowDbgEngNotOK();

                return qualifiedName;
            }
        }

        /// <summary>
        /// Gets the qualified name of the symbol (e.g.: MyNamespace::MyClass::MyMethod).
        /// </summary>
        public HRESULT TryGetQualifiedName(out string qualifiedName)
        {
            /*HRESULT GetQualifiedName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string qualifiedName);*/
            return Raw.GetQualifiedName(out qualifiedName);
        }

        #endregion
        #region Id

        /// <summary>
        /// Gets an identifier for the symbol which can be used to retrieve the same symbol again. The identifier is opaque and has semantics only to the underlying symbol set.
        /// </summary>
        public long Id
        {
            get
            {
                long value;
                TryGetId(out value).ThrowDbgEngNotOK();

                return value;
            }
        }

        /// <summary>
        /// Gets an identifier for the symbol which can be used to retrieve the same symbol again. The identifier is opaque and has semantics only to the underlying symbol set.
        /// </summary>
        public HRESULT TryGetId(out long value)
        {
            /*HRESULT GetId(
            [Out] out long value);*/
            return Raw.GetId(out value);
        }

        #endregion
        #region Offset

        /// <summary>
        /// Gets the offset of the symbol (if said symbol has such). Note that if the symbol has multiple disjoint address ranges associated with it, this method may return S_FALSE to indicate that the symbol does not necessarily have a simple "base address" for an offset.
        /// </summary>
        public long Offset
        {
            get
            {
                long symbolOffset;
                TryGetOffset(out symbolOffset).ThrowDbgEngNotOK();

                return symbolOffset;
            }
        }

        /// <summary>
        /// Gets the offset of the symbol (if said symbol has such). Note that if the symbol has multiple disjoint address ranges associated with it, this method may return S_FALSE to indicate that the symbol does not necessarily have a simple "base address" for an offset.
        /// </summary>
        public HRESULT TryGetOffset(out long symbolOffset)
        {
            /*HRESULT GetOffset(
            [Out] out long symbolOffset);*/
            return Raw.GetOffset(out symbolOffset);
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
