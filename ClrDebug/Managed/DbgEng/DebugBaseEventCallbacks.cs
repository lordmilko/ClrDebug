﻿using System;

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

        public virtual DEBUG_STATUS Exception(ref EXCEPTION_RECORD64 exception, int firstChance) => DEBUG_STATUS.NO_CHANGE;

        public virtual DEBUG_STATUS CreateThread(long handle, long dataOffset, long startOffset) => DEBUG_STATUS.NO_CHANGE;

        public virtual DEBUG_STATUS ExitThread(int exitCode) => DEBUG_STATUS.NO_CHANGE;

        public virtual DEBUG_STATUS CreateProcess(long imageFileHandle, long handle, long baseOffset, int moduleSize, string moduleName,
            string imageName, int checkSum, int timeDateStamp, long initialThreadHandle, long threadDataOffset,
            long startOffset) => DEBUG_STATUS.NO_CHANGE;

        public virtual DEBUG_STATUS ExitProcess(int exitCode) => DEBUG_STATUS.NO_CHANGE;

        public virtual DEBUG_STATUS LoadModule(long imageFileHandle, long baseOffset, int moduleSize, string moduleName, string imageName,
            int checkSum, int timeDateStamp) => DEBUG_STATUS.NO_CHANGE;

        public virtual DEBUG_STATUS UnloadModule(string imageBaseName, long baseOffset) => DEBUG_STATUS.NO_CHANGE;

        public virtual DEBUG_STATUS SystemError(int error, int level) => DEBUG_STATUS.NO_CHANGE;

        public virtual HRESULT SessionStatus(DEBUG_SESSION status) => HRESULT.S_OK;

        public virtual HRESULT ChangeDebuggeeState(DEBUG_CDS flags, long argument) => HRESULT.S_OK;

        public virtual HRESULT ChangeEngineState(DEBUG_CES flags, long argument) => HRESULT.S_OK;

        public virtual HRESULT ChangeSymbolState(DEBUG_CSS flags, long argument) => HRESULT.S_OK;
    }
}
