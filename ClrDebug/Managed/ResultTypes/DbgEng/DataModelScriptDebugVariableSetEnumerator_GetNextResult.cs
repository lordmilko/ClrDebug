using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DataModelScriptDebugVariableSetEnumerator.Next"/> property.
    /// </summary>
    [DebuggerDisplay("variableName = {variableName}, variableValue = {variableValue?.ToString(),nq}, variableMetadata = {variableMetadata?.ToString(),nq}")]
    public struct DataModelScriptDebugVariableSetEnumerator_GetNextResult
    {
        /// <summary>
        /// The name of the variable in the set is returned here as a string allocated by the SysAllocString function. The caller is responsible for freeing the returned string via SysFreeString.
        /// </summary>
        public string variableName { get; }

        /// <summary>
        /// The current value of the variable is returned here. The value must be marshaled out to an <see cref="IModelObject"/> representation.<para/>
        /// Every property or other construct on the <see cref="IModelObject"/> must be able to be acquired while the debugger is in a break state.
        /// </summary>
        public ModelObject variableValue { get; }

        /// <summary>
        /// Optional metadata about the variable and its presentation may be returned here.
        /// </summary>
        public KeyStore variableMetadata { get; }

        public DataModelScriptDebugVariableSetEnumerator_GetNextResult(string variableName, ModelObject variableValue, KeyStore variableMetadata)
        {
            this.variableName = variableName;
            this.variableValue = variableValue;
            this.variableMetadata = variableMetadata;
        }
    }
}
