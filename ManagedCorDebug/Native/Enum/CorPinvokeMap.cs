using System;

namespace ManagedCorDebug
{
    [Flags]
    public enum  CorPinvokeMap
    {
        pmNoMangle          = 0x0001,   // Pinvoke is to use the member name as specified.

        // Use this mask to retrieve the CharSet information.
        pmCharSetMask       = 0x0006,
        pmCharSetNotSpec    = 0x0000,
        pmCharSetAnsi       = 0x0002,
        pmCharSetUnicode    = 0x0004,
        pmCharSetAuto       = 0x0006,


        pmBestFitUseAssem   = 0x0000,
        pmBestFitEnabled    = 0x0010,
        pmBestFitDisabled   = 0x0020,
        pmBestFitMask       = 0x0030,

        pmThrowOnUnmappableCharUseAssem   = 0x0000,
        pmThrowOnUnmappableCharEnabled    = 0x1000,
        pmThrowOnUnmappableCharDisabled   = 0x2000,
        pmThrowOnUnmappableCharMask       = 0x3000,

        pmSupportsLastError = 0x0040,   // Information about target function. Not relevant for fields.

        // None of the calling convention flags is relevant for fields.
        pmCallConvMask      = 0x0700,
        pmCallConvWinapi    = 0x0100,   // Pinvoke will use native callconv appropriate to target windows platform.
        pmCallConvCdecl     = 0x0200,
        pmCallConvStdcall   = 0x0300,
        pmCallConvThiscall  = 0x0400,   // In M9, pinvoke will raise exception.
        pmCallConvFastcall  = 0x0500,

        pmMaxValue          = 0xFFFF,
    }
}