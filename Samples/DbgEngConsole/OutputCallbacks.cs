using System;
using ClrDebug;
using ClrDebug.DbgEng;

namespace DbgEngConsole
{
    internal class OutputCallbacks : IDebugOutputCallbacks
    {
        public HRESULT Output(DEBUG_OUTPUT mask, string text)
        {
            Console.Write(text);
            return HRESULT.S_OK;
        }
    }
}
