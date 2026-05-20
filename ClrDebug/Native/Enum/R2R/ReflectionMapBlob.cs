namespace ClrDebug
{
    //Used in NativeAOT
    public enum ReflectionMapBlob
    {
        TypeMap = 1,
        ArrayMap = 2,
        PointerTypeMap = 3,
        GenericInstanceMap = 3, //Now Unused
        FunctionPointerTypeMap = 4,
        GenericParameterMap = 4, //Now Unused
        BlockReflectionTypeMap = 5,
        InvokeMap = 6,
        VirtualInvokeMap = 7,
        CommonFixupsTable = 8,
        FieldAccessMap = 9,
        CCtorContextMap = 10,
        ByRefTypeMap = 11, //Previously DiagGenericInstanceMap
        DiagGenericInstanceMap = 11, //Now Unused
        DiagGenericParameterMap = 12,
        EmbeddedMetadata = 13,
        DefaultConstructorMap = 14,
        UnboxingAndInstantiatingStubMap = 15,
        StructMarshallingStubMap = 16,
        DelegateMarshallingStubMap = 17,
        GenericVirtualMethodTable = 18,
        InterfaceGenericVirtualMethodTable = 19,

        // Reflection template types/methods blobs:
        TypeTemplateMap = 21,
        GenericMethodsTemplateMap = 22,
        DynamicInvokeTemplateData = 23,
        BlobIdResourceIndex = 24,
        BlobIdResourceData = 25,
        BlobIdStackTraceEmbeddedMetadata = 26,
        BlobIdStackTraceMethodRvaToTokenMapping = 27,
        BlobIdStackTraceLineNumbers = 28,
        BlobIdStackTraceDocuments = 29,

        //Native layout blobs:
        NativeLayoutInfo = 30,
        NativeReferences = 31,
        GenericsHashtable = 32,
        NativeStatics = 33,
        StaticsInfoHashtable = 34,
        GenericMethodsHashtable = 35,
        ExactMethodInstantiationsHashtable = 36,
    }
}
