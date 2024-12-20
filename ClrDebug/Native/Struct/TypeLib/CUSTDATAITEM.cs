using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.TypeLib
{
    [DebuggerDisplay("guid = {guid.ToString(),nq}, varValue = {varValue}")]
    public struct CUSTDATAITEM
    {
        public Guid guid;

        [MarshalAs(UnmanagedType.Struct)]
        public object varValue;
    }
}
