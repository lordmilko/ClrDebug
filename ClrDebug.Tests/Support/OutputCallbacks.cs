using System.Diagnostics;
using ClrDebug.DbgEng;

namespace ClrDebug.Tests.DbgEng
{
    internal class OutputCallbacks : IDebugOutputCallbacks
    {
        public HRESULT Output(DEBUG_OUTPUT mask, string text)
        {
            Debug.Write(text);
            return HRESULT.S_OK;
        }
    }
}
