#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif
using ClrDebug.DbgEng;

namespace ClrDebug.Tests.DbgEng
{
#if GENERATED_MARSHALLING
    [GeneratedComClass]
#endif
    internal partial class EventCallbacks : DebugBaseEventCallbacks
    {
        private Debugger debugger;

        public EventCallbacks(Debugger debugger)
        {
            this.debugger = debugger;
        }

        public override HRESULT GetInterestMask(out DEBUG_EVENT_TYPE mask)
        {
            mask = DEBUG_EVENT_TYPE.CHANGE_ENGINE_STATE;
            return HRESULT.S_OK;
        }

        public override HRESULT ChangeEngineState(DEBUG_CES flags, long argument)
        {
            if ((flags & DEBUG_CES.EXECUTION_STATUS) != 0)
                debugger.ExecutionStatus = (DEBUG_STATUS)argument;

            return HRESULT.S_OK;
        }
    }
}
