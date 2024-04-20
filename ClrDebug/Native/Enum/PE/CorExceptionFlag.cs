using System;

namespace ClrDebug
{
    //While IMAGE_COR_ILMETHOD_FAT says its flags are 12 bits, currently I think only the first 8 are used, and the remaining 4 are padding, so byte is the appropriate underlying type to use here
    [Flags]
    public enum CorExceptionFlag : byte                       // definitions for the Flags field below (for both big and small)
    {
        COR_ILEXCEPTION_CLAUSE_NONE,                    // This is a typed handler
        //COR_ILEXCEPTION_CLAUSE_OFFSETLEN = 0x0000,      // Deprecated
        //COR_ILEXCEPTION_CLAUSE_DEPRECATED = 0x0000,     // Deprecated
        COR_ILEXCEPTION_CLAUSE_FILTER = 0x0001,        // If this bit is on, then this EH entry is for a filter
        COR_ILEXCEPTION_CLAUSE_FINALLY = 0x0002,        // This clause is a finally clause
        COR_ILEXCEPTION_CLAUSE_FAULT = 0x0004,          // Fault clause (finally that is called on exception only)
        COR_ILEXCEPTION_CLAUSE_DUPLICATED = 0x0008,     // duplicated clause. This clause was duplicated to a funclet which was pulled out of line
    }
}
