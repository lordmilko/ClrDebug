﻿using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DEBUG_OUTCBF : uint
    {
        EXPLICIT_FLUSH = 1,
        DML_HAS_TAGS = 2,
        DML_HAS_SPECIAL_CHARACTERS = 4,
    }
}