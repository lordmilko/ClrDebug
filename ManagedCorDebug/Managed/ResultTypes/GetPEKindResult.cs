using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.PEKind"/> property.
    /// </summary>
    [DebuggerDisplay("pdwPEKind = {pdwPEKind}, pdwMachine = {pdwMachine}")]
    public struct GetPEKindResult
    {
        /// <summary>
        /// A pointer to a value of the <see cref="CorPEKind"/> enumeration that describes the PE file.
        /// </summary>
        public CorPEKind pdwPEKind { get; }

        /// <summary>
        /// A pointer to a value that identifies the architecture of the machine. See the next section for possible values.
        /// </summary>
        public int pdwMachine { get; }

        public GetPEKindResult(CorPEKind pdwPEKind, int pdwMachine)
        {
            this.pdwPEKind = pdwPEKind;
            this.pdwMachine = pdwMachine;
        }
    }
}