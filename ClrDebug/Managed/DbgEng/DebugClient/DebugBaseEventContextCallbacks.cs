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

        public DEBUG_STATUS Breakpoint(IntPtr bp, ref DEBUG_EVENT_CONTEXT context, int contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS Exception(ref EXCEPTION_RECORD64 exception, int firstChance, ref DEBUG_EVENT_CONTEXT context, int contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS CreateThread(long handle, long dataOffset, long startOffset, ref DEBUG_EVENT_CONTEXT context,
            int contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS ExitThread(int exitCode, ref DEBUG_EVENT_CONTEXT context, int contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS CreateProcess(long imageFileHandle, long handle, long baseOffset, int moduleSize, string moduleName,
            string imageName, int checkSum, int timeDateStamp, long initialThreadHandle, long threadDataOffset,
            long startOffset, ref DEBUG_EVENT_CONTEXT context, int contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS ExitProcess(int exitCode, ref DEBUG_EVENT_CONTEXT context, int contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS LoadModule(long imageFileHandle, long baseOffset, int moduleSize, string moduleName, string imageName,
            int checkSum, int timeDateStamp, ref DEBUG_EVENT_CONTEXT context, int contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS UnloadModule(string imageBaseName, long baseOffset, ref DEBUG_EVENT_CONTEXT context, int contextSize) => DEBUG_STATUS.NO_CHANGE;

        public DEBUG_STATUS SystemError(int error, int level, ref DEBUG_EVENT_CONTEXT context, int contextSize) => DEBUG_STATUS.NO_CHANGE;

        public HRESULT SessionStatus(DEBUG_SESSION status) => HRESULT.S_OK;

        public HRESULT ChangeDebuggeeState(DEBUG_CDS flags, long argument, ref DEBUG_EVENT_CONTEXT context, int contextSize) => HRESULT.S_OK;

        public HRESULT ChangeEngineState(DEBUG_CES flags, long argument, ref DEBUG_EVENT_CONTEXT context, int contextSize) => HRESULT.S_OK;

        public HRESULT ChangeSymbolState(DEBUG_CSS flags, long argument) => HRESULT.S_OK;
    }
}
