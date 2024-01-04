using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DEBUG_HOOK_INDEX
    {
        //Sets g_bAllowQiIUnknown, which allows querying for IUnknown on proxy objects, which due to a bug
        //have historically disallowed querying for IUnknown
        ALLOW_QI_IUNKNOWN = 0,
    }
}
