using System;
using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    [DebuggerDisplay("guid = {guid.ToString(),nq}, varValue = {varValue}")]
    public struct CUSTDATAITEM
    {
        public Guid guid;
        public object varValue;
    }
}
