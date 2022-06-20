using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SOSDacInterface.GetComWrappersCCWData"/> method.
    /// </summary>
    [DebuggerDisplay("managedObject = {managedObject.ToString(),nq}, refCount = {refCount}")]
    public struct GetComWrappersCCWDataResult
    {
        public CLRDATA_ADDRESS managedObject { get; }

        public int refCount { get; }

        public GetComWrappersCCWDataResult(CLRDATA_ADDRESS managedObject, int refCount)
        {
            this.managedObject = managedObject;
            this.refCount = refCount;
        }
    }
}