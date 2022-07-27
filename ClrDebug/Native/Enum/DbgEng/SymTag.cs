namespace ClrDebug.DbgEng
{
    public enum SymTag : uint
    {
        Null,                //  0
        Exe,                 //  1
        Compiland,           //  2
        CompilandDetails,    //  3
        CompilandEnv,        //  4
        Function,            //  5
        Block,               //  6
        Data,                //  7
        Annotation,          //  8
        Label,               //  9
        PublicSymbol,        // 10
        UDT,                 // 11
        Enum,                // 12
        FunctionType,        // 13
        PointerType,         // 14
        ArrayType,           // 15
        BaseType,            // 16
        Typedef,             // 17
        BaseClass,           // 18
        Friend,              // 19
        FunctionArgType,     // 20
        FuncDebugStart,      // 21
        FuncDebugEnd,        // 22
        UsingNamespace,      // 23
        VTableShape,         // 24
        VTable,              // 25
        Custom,              // 26
        Thunk,               // 27
        CustomType,          // 28
        ManagedType,         // 29
        Dimension,           // 30
        CallSite,            // 31
        InlineSite,          // 32
        BaseInterface,       // 33
        VectorType,          // 34
        MatrixType,          // 35
        HLSLType,            // 36
        Caller,              // 37
        Callee,              // 38
        Export,              // 39
        HeapAllocationSite,  // 40
        CoffGroup,           // 41
        SymTagMax
    }
}
