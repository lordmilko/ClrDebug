using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provides a do-nothing base implementation of <see cref="IDebugEventCallbacks"/>.<para/>
    /// A program can derive their own event callbacks from <see cref="DebugBaseEventCallbacks"/>
    /// and implement only the methods they are interested in.<para/>
    /// Programs must be careful to implement <see cref="GetInterestMask(out DEBUG_EVENT_TYPE)"/> appropriately.
    /// </summary>
    public abstract class DebugBaseEventCallbacks : IDebugEventCallbacks
    {
        public abstract HRESULT GetInterestMask(out DEBUG_EVENT_TYPE mask);

        public virtual DEBUG_STATUS Breakpoint(IntPtr bp) => DEBUG_STATUS.NO_CHANGE;

        public virtual DEBUG_STATUS Exception(ref EXCEPTION_RECORD64 exception, uint firstChance) => DEBUG_STATUS.NO_CHANGE;

        public virtual DEBUG_STATUS CreateThread(ulong handle, ulong dataOffset, ulong startOffset) => DEBUG_STATUS.NO_CHANGE;

        public virtual DEBUG_STATUS ExitThread(uint exitCode) => DEBUG_STATUS.NO_CHANGE;

        public virtual DEBUG_STATUS CreateProcess(ulong imageFileHandle, ulong handle, ulong baseOffset, uint moduleSize, string moduleName,
            string imageName, uint checkSum, uint timeDateStamp, ulong initialThreadHandle, ulong threadDataOffset,
            ulong startOffset) => DEBUG_STATUS.NO_CHANGE;

        public virtual DEBUG_STATUS ExitProcess(uint exitCode) => DEBUG_STATUS.NO_CHANGE;

        public virtual DEBUG_STATUS LoadModule(ulong imageFileHandle, ulong baseOffset, uint moduleSize, string moduleName, string imageName,
            uint checkSum, uint timeDateStamp) => DEBUG_STATUS.NO_CHANGE;

        public virtual DEBUG_STATUS UnloadModule(string imageBaseName, ulong baseOffset) => DEBUG_STATUS.NO_CHANGE;

        public virtual DEBUG_STATUS SystemError(uint error, uint level) => DEBUG_STATUS.NO_CHANGE;

        public virtual HRESULT SessionStatus(DEBUG_SESSION status) => HRESULT.S_OK;

        public virtual HRESULT ChangeDebuggeeState(DEBUG_CDS flags, ulong argument) => HRESULT.S_OK;

        public virtual HRESULT ChangeEngineState(DEBUG_CES flags, ulong argument) => HRESULT.S_OK;

        public virtual HRESULT ChangeSymbolState(DEBUG_CSS flags, ulong argument) => HRESULT.S_OK;
    }
}
