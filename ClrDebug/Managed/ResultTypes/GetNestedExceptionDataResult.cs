using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SOSDacInterface.GetNestedExceptionData"/> method.
    /// </summary>
    [DebuggerDisplay("exceptionObject = {exceptionObject.ToString(),nq}, nextNestedException = {nextNestedException.ToString(),nq}")]
    public struct GetNestedExceptionDataResult
    {
        public CLRDATA_ADDRESS exceptionObject { get; }

        public CLRDATA_ADDRESS nextNestedException { get; }

        public GetNestedExceptionDataResult(CLRDATA_ADDRESS exceptionObject, CLRDATA_ADDRESS nextNestedException)
        {
            this.exceptionObject = exceptionObject;
            this.nextNestedException = nextNestedException;
        }
    }
}
