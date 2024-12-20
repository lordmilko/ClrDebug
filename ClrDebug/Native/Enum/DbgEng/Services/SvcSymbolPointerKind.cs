namespace ClrDebug.DbgEng
{
    public enum SvcSymbolPointerKind : uint
    {
        /// <summary>
        /// *.
        /// </summary>
        SvcSymbolPointerStandard,

        /// <summary>
        /// &amp;.
        /// </summary>
        SvcSymbolPointerReference,

        /// <summary>
        /// &amp;&amp;.
        /// </summary>
        SvcSymbolPointerRValueReference,

        /// <summary>
        /// ^.
        /// </summary>
        SvcSymbolPointerCXHat,

        /// <summary>
        /// CLI reference (invisible to the user).
        /// </summary>
        SvcSymbolPointerManagedReference
    }
}
