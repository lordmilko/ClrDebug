﻿using System;

namespace ClrDebug.DbgEng
{
    // What windows should the GUI client refresh?
    // Applies when DEBUG_CDS.REFRESH is passed to ChangeDebuggeeState
    [Flags]
    public enum DEBUG_CDS_REFRESH : uint
    {
        EVALUATE                 =  1,
        EXECUTE                  =  2,
        EXECUTECOMMANDFILE       =  3,
        ADDBREAKPOINT            =  4,
        REMOVEBREAKPOINT         =  5,
        WRITEVIRTUAL             =  6,
        WRITEVIRTUALUNCACHED     =  7,
        WRITEPHYSICAL            =  8,
        WRITEPHYSICAL2           =  9,
        SETVALUE                 = 10,
        SETVALUE2                = 11,
        SETSCOPE                 = 12,
        SETSCOPEFRAMEBYINDEX     = 13,
        SETSCOPEFROMJITDEBUGINFO = 14,
        SETSCOPEFROMSTOREDEVENT  = 15,
        INLINESTEP               = 16,
        INLINESTEP_PSEUDO        = 17,
    }
}
