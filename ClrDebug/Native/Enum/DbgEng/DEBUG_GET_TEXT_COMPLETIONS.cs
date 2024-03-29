﻿using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DEBUG_GET_TEXT_COMPLETIONS : uint
    {
        NONE = 0,
        NO_DOT_COMMANDS = 1,
        NO_EXTENSION_COMMANDS = 2,
        NO_SYMBOLS = 4,
        IS_DOT_COMMAND = 1,
        IS_EXTENSION_COMMAND = 2,
        IS_SYMBOL = 4,
    }
}