namespace ClrDebug.DIA
{
    /// <summary>
    /// Specifies the type of a symbol.
    /// </summary>
    /// <remarks>
    /// All symbols within a debug file have an identifying tag that specifies the symbol's type. The values in this enumeration
    /// are returned by a call to the <see cref="IDiaSymbol.get_symTag"/> method. The values in this enumeration are passed
    /// to the following methods to limit the scope of the search to a specific symbol type:
    /// </remarks>
    public enum SymTagEnum : uint
    {
        /// <summary>
        /// Indicates that the symbol has no type.
        /// </summary>
        Null,

        /// <summary>
        /// Indicates that the symbol is an .exe file. There is only one SymTagExe symbol per symbol store.
        /// It serves as the global scope and does not have a lexical parent.
        /// </summary>
        Exe,

        /// <summary>
        /// Indicates the compiland symbol for each compiland component of the symbol store.
        /// For native applications, SymTagCompiland symbols correspond to the object files linked into the image.
        /// For some kinds of Microsoft Intermediate Language (MSIL) images, there is one compiland per class.
        /// </summary>
        Compiland,

        /// <summary>
        /// Indicates that the symbol contains extended attributes of the compiland.
        /// Retrieving these properties may require loading compiland symbols.
        /// </summary>
        CompilandDetails,

        /// <summary>
        /// Indicates that the symbol is an environment string defined for the compiland.
        /// </summary>
        CompilandEnv,

        /// <summary>
        /// Indicates that the symbol is a function.
        /// </summary>
        Function,

        /// <summary>
        /// Indicates that the symbol is a nested block.
        /// </summary>
        Block,

        /// <summary>
        /// Indicates that the symbol is data.
        /// </summary>
        Data,

        /// <summary>
        /// Indicates that the symbol is for a code annotation. Children of this symbol are constant data strings
        /// (SymTagData, LocIsConstant, DataIsConstant). Most clients ignore this symbol.
        /// </summary>
        Annotation,

        /// <summary>
        /// Indicates that the symbol is a label.
        /// </summary>
        Label,

        /// <summary>
        /// Indicates that the symbol is a public symbol. For native applications, this symbol is the COFF
        /// external symbol encountered while linking the image.
        /// </summary>
        PublicSymbol,

        /// <summary>
        /// Indicates that the symbol is a user-defined type (structure, class, or union).
        /// </summary>
        UDT,

        /// <summary>
        /// Indicates that the symbol is an enumeration.
        /// </summary>
        Enum,

        /// <summary>
        /// Indicates that the symbol is a function signature type.
        /// </summary>
        FunctionType,

        /// <summary>
        /// Indicates that the symbol is a pointer type.
        /// </summary>
        PointerType,

        /// <summary>
        /// Indicates that the symbol is an array type.
        /// </summary>
        ArrayType,

        /// <summary>
        /// Indicates that the symbol is a base type.
        /// </summary>
        BaseType,

        /// <summary>
        /// Indicates that the symbol is a typedef, that is, an alias for another type.
        /// </summary>
        Typedef,

        /// <summary>
        /// Indicates that the symbol is a base class of a user-defined type.
        /// </summary>
        BaseClass,

        /// <summary>
        /// Indicates that the symbol is a friend of a user-defined type.
        /// </summary>
        Friend,

        /// <summary>
        /// Indicates that the symbol is a function argument.
        /// </summary>
        FunctionArgType,

        /// <summary>
        /// Indicates that the symbol is the end location of the function's prologue code.
        /// </summary>
        FuncDebugStart,

        /// <summary>
        /// Indicates that the symbol is the beginning location of the function's epilogue code.
        /// </summary>
        FuncDebugEnd,

        /// <summary>
        /// Indicates that the symbol is a namespace name, active in the current scope.
        /// </summary>
        UsingNamespace,

        /// <summary>
        /// Indicates that the symbol is a virtual table description.
        /// </summary>
        VTableShape,

        /// <summary>
        /// Indicates that the symbol is a virtual table pointer.
        /// </summary>
        VTable,

        /// <summary>
        /// Indicates that the symbol is a custom symbol and is not interpreted by DIA.
        /// </summary>
        Custom,

        /// <summary>
        /// Indicates that the symbol is a thunk used for sharing data between 16 and 32 bit code.
        /// </summary>
        Thunk,

        /// <summary>
        /// Indicates that the symbol is a custom compiler symbol.
        /// </summary>
        CustomType,

        /// <summary>
        /// Indicates that the symbol is in metadata.
        /// </summary>
        ManagedType,

        /// <summary>
        /// Indicates that the symbol is a FORTRAN multi-dimensional array.
        /// </summary>
        Dimension,

        /// <summary>
        /// Indicates that the symbol represents the call site.
        /// </summary>
        CallSite,

        /// <summary>
        /// Indicates that the symbol represents the inline site.
        /// </summary>
        InlineSite,

        /// <summary>
        /// Indicates that the symbol is a base interface.
        /// </summary>
        BaseInterface,

        /// <summary>
        /// Indicates that the symbol is a vector type.
        /// </summary>
        VectorType,

        /// <summary>
        /// Indicates that the symbol is a matrix type.
        /// </summary>
        MatrixType,

        /// <summary>
        /// Indicates that the symbol is a High Level Shader Language type.
        /// </summary>
        HLSLType,

        Caller,              // 37
        Callee,              // 38
        Export,              // 39
        HeapAllocationSite,  // 40
        CoffGroup,           // 41

        Inlinee,             // 42
        TaggedUnionCase,     // 43

        SymTagMax,
    }
}
