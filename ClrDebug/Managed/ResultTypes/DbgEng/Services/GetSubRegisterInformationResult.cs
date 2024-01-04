using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcRegisterInformation.SubRegisterInformation"/> property.
    /// </summary>
    [DebuggerDisplay("parentRegisterId = {parentRegisterId}, lsbOfMapping = {lsbOfMapping}, msbOfMapping = {msbOfMapping}")]
    public struct GetSubRegisterInformationResult
    {
        public int parentRegisterId { get; }

        public int lsbOfMapping { get; }

        public int msbOfMapping { get; }

        public GetSubRegisterInformationResult(int parentRegisterId, int lsbOfMapping, int msbOfMapping)
        {
            this.parentRegisterId = parentRegisterId;
            this.lsbOfMapping = lsbOfMapping;
            this.msbOfMapping = msbOfMapping;
        }
    }
}
