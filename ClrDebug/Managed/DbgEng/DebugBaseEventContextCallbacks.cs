using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provides a do-nothing base implementation of <see cref="IDebugEventContextCallbacks"/>.<para/>
    /// A program can derive their own event callbacks from <see cref="DebugBaseEventCallbacksWide"/>
    /// and implement only the methods they are interested in.<para/>
    /// Programs must be careful to implement <see cref="GetInterestMask(out DEBUG_EVENT_TYPE)"/> appropriately.
    /// </summary>
    public abstract class DebugBaseEventContextCallbacks : IDebugEventContextCallbacks
    {
        public abstract HRESULT GetInterestMask(out DEBUG_EVENT_TYPE mask);

        public DEBUG_STATUS Breakpoint(IntPtr bp, ref DEBUG_EVENT_CONTEXT context, uint contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS Exception(ref EXCEPTION_RECORD64 exception, uint firstChance, ref DEBUG_EVENT_CONTEXT context, uint contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS CreateThread(ulong handle, ulong dataOffset, ulong startOffset, ref DEBUG_EVENT_CONTEXT context,
            uint contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS ExitThread(uint exitCode, ref DEBUG_EVENT_CONTEXT context, uint contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS CreateProcess(ulong imageFileHandle, ulong handle, ulong baseOffset, uint moduleSize, string moduleName,
            string imageName, uint checkSum, uint timeDateStamp, ulong initialThreadHandle, ulong threadDataOffset,
            ulong startOffset, ref DEBUG_EVENT_CONTEXT context, uint contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS ExitProcess(uint exitCode, ref DEBUG_EVENT_CONTEXT context, uint contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS LoadModule(ulong imageFileHandle, ulong baseOffset, uint moduleSize, string moduleName, string imageName,
            uint checkSum, uint timeDateStamp, ref DEBUG_EVENT_CONTEXT context, uint contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS UnloadModule(string imageBaseName, ulong baseOffset, ref DEBUG_EVENT_CONTEXT context, uint contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS SystemError(uint error, uint level, ref DEBUG_EVENT_CONTEXT context, uint contextSize) => DEBUG_STATUS.NO_CHANGE;

        public HRESULT SessionStatus(DEBUG_SESSION status) => HRESULT.S_OK;

        public HRESULT ChangeDebuggeeState(DEBUG_CDS flags, ulong argument, ref DEBUG_EVENT_CONTEXT context, uint contextSize) => HRESULT.S_OK;

        public HRESULT ChangeEngineState(DEBUG_CES flags, ulong argument, ref DEBUG_EVENT_CONTEXT context, uint contextSize) => HRESULT.S_OK;

        public HRESULT ChangeSymbolState(DEBUG_CSS flags, ulong argument) => HRESULT.S_OK;
    }
}
