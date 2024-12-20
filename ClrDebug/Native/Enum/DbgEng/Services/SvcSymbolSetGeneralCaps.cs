namespace ClrDebug.DbgEng
{
    public enum SvcSymbolSetGeneralCaps : uint
    {
        /// <summary>
        /// SvcSymbolSetGeneralCapPassByValueStructLocations Describes how the symbol set deals with the reporting of "pass-by-value" structs (or other UDTs such as C++ classes).<para/>
        /// The calling convention on some platforms (e.g.: Windows AMD64) requires that any "pass-by-value" UDTs over an arbitrary size must be passed by reference.<para/>
        /// Some formats (e.g.: PDB) put the language semantics (pass-by-value) in the debug info stating things like (the parameter itself -- a size N UDT -- is passed in a register 'rcx') and rely on the debugger to implicitly understand the calling convention means that the debugger must *INTERPRET* the debug information not as it is written into the format but as a reference instead (e.g.: it's not the parameter itself passed in 'rcx'; rather the address of it).<para/>
        /// This, unfortunately, makes it impossible to express the notion of an *ACTUAL* passed-by-value large-struct (e.g.: on the stack or split into multiple registers) because one cannot differentiate between cases where the meaning is "really pass by value" and "should add an indirection to the debug info as written".<para/>
        /// The value of this capability is a boolean (expressed as a one-byte data value) which carries the following meaning true (non-zero): Trust the debug information.<para/>
        /// If a location implies pass-by-value, it is pass-by-value. For a pass-by-reference, the location must be *EXPLICIT* in carrying this meaning.<para/>
        /// false (zero) : Do not always trust the debug information. Alter the information to assume implicit references for large structs.<para/>
        /// The default value here is *true*. Callers must always assume the debug information is correct unless they are told otherwise explicitly by this capability.
        /// </summary>
        SvcSymbolSetGeneralCapPassByValueStructLocations
    }
}
