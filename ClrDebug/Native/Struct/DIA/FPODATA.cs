using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    //This type is in dia.h but isn't explicitly referenced anywhere so I don't know
    //where it's meant to be used. It is basically identical to the FPO_DATA type
    [DebuggerDisplay("ulOffStart = {ulOffStart}, cbProcSize = {cbProcSize}, cdwLocals = {cdwLocals}, cdwParams = {cdwParams}, cdwFlags = {cdwFlags}")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct FPODATA //Internal so that users don't confuse it with FPO_DATA until we know what it's meant to be used for
    {
        public int ulOffStart;             // offset 1st byte of function code
        public int cbProcSize;             // # bytes in function
        public int cdwLocals;              // # bytes in locals/4
        public short cdwParams;            // # bytes in params/4
        public short cdwFlags;             // Following stuff ...

        /*
        These members of FPO_DATA were commented out in dia's IDL file, indicating that FPODATA is similar
        to FPO_DATA but perhaps does not include these members

        WORD        cbProlog : 8;           // # bytes in prolog
        WORD        cbRegs   : 3;           // # regs saved
        WORD        fHasSEH  : 1;           // TRUE if SEH in func
        WORD        fUseBP   : 1;           // TRUE if EBP has been allocated
        WORD        reserved : 1;           // reserved for future use
        WORD        cbFrame  : 2;           // frame type
        */
    }
}
