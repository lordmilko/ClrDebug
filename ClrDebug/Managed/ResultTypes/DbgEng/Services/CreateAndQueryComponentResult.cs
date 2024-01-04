using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugTargetComposition.CreateAndQueryComponent"/> method.
    /// </summary>
    [DebuggerDisplay("componentService = {componentService?.ToString(),nq}, interfaceUnknown = {interfaceUnknown}")]
    public struct CreateAndQueryComponentResult
    {
        public DebugServiceLayer componentService { get; }

        public object interfaceUnknown { get; }

        public CreateAndQueryComponentResult(DebugServiceLayer componentService, object interfaceUnknown)
        {
            this.componentService = componentService;
            this.interfaceUnknown = interfaceUnknown;
        }
    }
}
