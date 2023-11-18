using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// OutputSymbols flags.
    /// Default output contains &lt;Name&gt;**NAME**&lt;Offset&gt;**OFF**&lt;Value&gt;**VALUE**&lt;Type&gt;**TYPE**
    /// </summary>
    [Flags]
    public enum DEBUG_OUTPUT_SYMBOLS
    {
        DEFAULT = 0,
        NO_NAMES = 1,
        NO_OFFSETS = 2,
        NO_VALUES = 4,
        NO_TYPES = 0x10,
    }
}
