using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    [DebuggerDisplay("Bytes = {Bytes}, varDefaultValue = {varDefaultValue}")]
    public struct PARAMDESCEX
    {
        public int Bytes;
        public object varDefaultValue;
    }
}
