using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ObjectWrapperConcept.GetWrappedObject"/> method.
    /// </summary>
    [DebuggerDisplay("wrappedObject = {wrappedObject?.ToString(),nq}, pUsagePreference = {pUsagePreference.ToString(),nq}")]
    public struct GetWrappedObjectResult
    {
        public ModelObject wrappedObject { get; }

        public WrappedObjectPreference pUsagePreference { get; }

        public GetWrappedObjectResult(ModelObject wrappedObject, WrappedObjectPreference pUsagePreference)
        {
            this.wrappedObject = wrappedObject;
            this.pUsagePreference = pUsagePreference;
        }
    }
}
