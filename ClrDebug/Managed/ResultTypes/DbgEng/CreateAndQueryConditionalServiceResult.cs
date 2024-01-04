using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugTargetComposition.CreateAndQueryConditionalService"/> method.
    /// </summary>
    [DebuggerDisplay("componentService = {componentService?.ToString(),nq}, interfaceUnknown = {interfaceUnknown}")]
    public struct CreateAndQueryConditionalServiceResult
    {
        public DebugServiceLayer componentService { get; }

        public object interfaceUnknown { get; }

        public CreateAndQueryConditionalServiceResult(DebugServiceLayer componentService, object interfaceUnknown)
        {
            this.componentService = componentService;
            this.interfaceUnknown = interfaceUnknown;
        }
    }
}
