using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="RawEnumerator.Next"/> property.
    /// </summary>
    [DebuggerDisplay("name = {name}, kind = {kind.ToString(),nq}, value = {value?.ToString(),nq}")]
    public struct RawEnumerator_GetNextResult
    {
        /// <summary>
        /// The name of the raw element (e.g.: field) being enumerated is returned here. The caller is responsible for freeing this string with the SysFreeString method.
        /// </summary>
        public string name { get; }

        /// <summary>
        /// The kind of symbol being enumerated (e.g.: a type, field, base class, etc…) is returned here.
        /// </summary>
        public SymbolKind kind { get; }

        /// <summary>
        /// The value of the raw element (e.g.: field) being enumerated is optionally returned here. Depending on how the enumerator was acquired, this value may be the actual value of the raw element (EnumerateRawValues) or a reference to it (EnumerateRawReferences).
        /// </summary>
        public ModelObject value { get; }

        public RawEnumerator_GetNextResult(string name, SymbolKind kind, ModelObject value)
        {
            this.name = name;
            this.kind = kind;
            this.value = value;
        }
    }
}
