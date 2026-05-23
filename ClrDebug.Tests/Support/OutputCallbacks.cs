using System.Diagnostics;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif
using ClrDebug.DbgEng;

namespace ClrDebug.Tests.DbgEng
{
#if GENERATED_MARSHALLING
    [GeneratedComClass]
#endif
    internal partial class OutputCallbacks : IDebugOutputCallbacks
    {
        public HRESULT Output(DEBUG_OUTPUT mask, string text)
        {
            Debug.Write(text);
            return HRESULT.S_OK;
        }
    }
}
