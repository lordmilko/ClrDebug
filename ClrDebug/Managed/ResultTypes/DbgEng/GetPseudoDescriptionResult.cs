using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugRegisters.GetPseudoDescription"/> method.
    /// </summary>
    [DebuggerDisplay("NameBuffer = {NameBuffer}, TypeModule = {TypeModule}, TypeId = {TypeId}")]
    public struct GetPseudoDescriptionResult
    {
        /// <summary>
        /// Receives the name of the pseudo-register. If NameBuffer is NULL, this information is not returned.
        /// </summary>
        public string NameBuffer { get; }

        /// <summary>
        /// Receives the base address of the module to which the register's type belongs. If the type of the register is not known, zero is returned.<para/>
        /// If TypeModule is NULL, no information is returned.
        /// </summary>
        public ulong TypeModule { get; }

        /// <summary>
        /// Receives the type ID of the type within the module returned in TypeModule. If the type ID is not known, zero is returned.<para/>
        /// If TypeId is NULL, no information is returned.
        /// </summary>
        public uint TypeId { get; }

        public GetPseudoDescriptionResult(string nameBuffer, ulong typeModule, uint typeId)
        {
            NameBuffer = nameBuffer;
            TypeModule = typeModule;
            TypeId = typeId;
        }
    }
}
