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

        public SvcSymbolKind SymbolKind
        {
            get
            {
                SvcSymbolKind kind;
                TryGetSymbolKind(out kind).ThrowDbgEngNotOK();

                return kind;
            }
        }

        public HRESULT TryGetSymbolKind(out SvcSymbolKind kind)
        {
            /*HRESULT GetSymbolKind(
            [Out] out SvcSymbolKind kind);*/
            return Raw.GetSymbolKind(out kind);
        }

        #endregion
        #region Name

        public string Name
        {
            get
            {
                string symbolName;
                TryGetName(out symbolName).ThrowDbgEngNotOK();

                return symbolName;
            }
        }

        public HRESULT TryGetName(out string symbolName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string symbolName);*/
            return Raw.GetName(out symbolName);
        }

        #endregion
        #region QualifiedName

        public string QualifiedName
        {
            get
            {
                string qualifiedName;
                TryGetQualifiedName(out qualifiedName).ThrowDbgEngNotOK();

                return qualifiedName;
            }
        }

        public HRESULT TryGetQualifiedName(out string qualifiedName)
        {
            /*HRESULT GetQualifiedName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string qualifiedName);*/
            return Raw.GetQualifiedName(out qualifiedName);
        }

        #endregion
        #region Id

        public long Id
        {
            get
            {
                long value;
                TryGetId(out value).ThrowDbgEngNotOK();

                return value;
            }
        }

        public HRESULT TryGetId(out long value)
        {
            /*HRESULT GetId(
            [Out] out long value);*/
            return Raw.GetId(out value);
        }

        #endregion
        #region Offset

        public long Offset
        {
            get
            {
                long symbolOffset;
                TryGetOffset(out symbolOffset).ThrowDbgEngNotOK();

                return symbolOffset;
            }
        }

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
