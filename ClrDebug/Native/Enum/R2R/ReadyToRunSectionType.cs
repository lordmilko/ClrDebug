namespace ClrDebug
{
    public enum ReadyToRunSectionType
    {
        CompilerIdentifier          = 100,
        ImportSections              = 101,
        RuntimeFunctions            = 102,
        MethodDefEntryPoints        = 103,
        ExceptionInfo               = 104,
        DebugInfo                   = 105,
        DelayLoadMethodCallThunks   = 106,
        // 107 used by an older format of AvailableTypes
        AvailableTypes              = 108,
        InstanceMethodEntryPoints   = 109,
        InliningInfo                = 110, // Added in V2.1, deprecated in 4.1
        ProfileDataInfo             = 111, // Added in V2.2
        ManifestMetadata            = 112, // Added in V2.3
        AttributePresence           = 113, // Added in V3.1
        InliningInfo2               = 114, // Added in V4.1
        ComponentAssemblies         = 115, // Added in V4.1
        OwnerCompositeExecutable    = 116, // Added in V4.1
        PgoInstrumentationData      = 117, // Added in V5.2
        ManifestAssemblyMvids       = 118, // Added in V5.3
        CrossModuleInlineInfo       = 119, // Added in V6.2
        HotColdMap                  = 120, // Added in V8.0
        MethodIsGenericMap          = 121, // Added in V9.0
        EnclosingTypeMap            = 122, // Added in V9.0
        TypeGenericInfoMap          = 123, // Added in V9.0

        //While these are defined in a separate "ReadyToRunSectionType" enum in ModuleHeaders.h,
        //ModuleHeaders.cs unifies the R2R and NativeAOT enum members
        //into a single type, so we'll do the same thing here

        // Shared ReadyToRun sections
        ExternalTypeMaps = 124, // Added to CoreCLR in V18.3
        ProxyTypeMaps = 125, // Added to CoreCLR in V18.3
        TypeMapAssemblyTargets = 126, // Added in V18.3

        //
        // NativeAOT ReadyToRun sections
        //
        StringTable = 200, // Unused
        GCStaticRegion = 201,
        ThreadStaticRegion = 202,
        // Unused = 203,
        TypeManagerIndirection = 204,
        EagerCctor = 205,
        FrozenObjectRegion = 206,
        DehydratedData = 207,
        ThreadStaticOffsetRegion = 208,
        // 209 is unused - it was used by ThreadStaticGCDescRegion
        // 210 is unused - it was used by ThreadStaticIndex
        // 211 is unused - it was used by LoopHijackFlag
        ImportAddressTables = 212,
        ModuleInitializerList = 213,

        // Sections 300 - 399 are reserved for RhFindBlob backwards compatibility
        ReadonlyBlobRegionStart = 300,

        #region ReflectionMapBlob

        //MetadataManager.BlobIdToReadyToRunSection converts a ReflectionMapBlob
        //to a ReadyToRunSectionType by adding ReadonlyBlobRegionStart
        //to the blob type. We include these values here

        TypeMap                                 = ReadonlyBlobRegionStart + ReflectionMapBlob.TypeMap,
        ArrayMap                                = ReadonlyBlobRegionStart + ReflectionMapBlob.ArrayMap,
        PointerTypeMap                          = ReadonlyBlobRegionStart + ReflectionMapBlob.PointerTypeMap,
        GenericInstanceMap                      = ReadonlyBlobRegionStart + ReflectionMapBlob.GenericInstanceMap, //Now Unused
        FunctionPointerTypeMap                  = ReadonlyBlobRegionStart + ReflectionMapBlob.FunctionPointerTypeMap,
        GenericParameterMap                     = ReadonlyBlobRegionStart + ReflectionMapBlob.GenericParameterMap, //Now Unused
        BlockReflectionTypeMap                  = ReadonlyBlobRegionStart + ReflectionMapBlob.BlockReflectionTypeMap,
        InvokeMap                               = ReadonlyBlobRegionStart + ReflectionMapBlob.InvokeMap,
        VirtualInvokeMap                        = ReadonlyBlobRegionStart + ReflectionMapBlob.VirtualInvokeMap,
        CommonFixupsTable                       = ReadonlyBlobRegionStart + ReflectionMapBlob.CommonFixupsTable,
        FieldAccessMap                          = ReadonlyBlobRegionStart + ReflectionMapBlob.FieldAccessMap,
        CCtorContextMap                         = ReadonlyBlobRegionStart + ReflectionMapBlob.CCtorContextMap,
        ByRefTypeMap                            = ReadonlyBlobRegionStart + ReflectionMapBlob.ByRefTypeMap,
        DiagGenericInstanceMap                  = ReadonlyBlobRegionStart + ReflectionMapBlob.DiagGenericInstanceMap, //Now Unused
        DiagGenericParameterMap                 = ReadonlyBlobRegionStart + ReflectionMapBlob.DiagGenericParameterMap,
        EmbeddedMetadata                        = ReadonlyBlobRegionStart + ReflectionMapBlob.EmbeddedMetadata,
        DefaultConstructorMap                   = ReadonlyBlobRegionStart + ReflectionMapBlob.DefaultConstructorMap,
        UnboxingAndInstantiatingStubMap         = ReadonlyBlobRegionStart + ReflectionMapBlob.UnboxingAndInstantiatingStubMap,
        StructMarshallingStubMap                = ReadonlyBlobRegionStart + ReflectionMapBlob.StructMarshallingStubMap,
        DelegateMarshallingStubMap              = ReadonlyBlobRegionStart + ReflectionMapBlob.DelegateMarshallingStubMap,
        GenericVirtualMethodTable               = ReadonlyBlobRegionStart + ReflectionMapBlob.GenericVirtualMethodTable,
        InterfaceGenericVirtualMethodTable      = ReadonlyBlobRegionStart + ReflectionMapBlob.InterfaceGenericVirtualMethodTable,

        // Reflection template types/methods blobs:
        TypeTemplateMap                         = ReadonlyBlobRegionStart + ReflectionMapBlob.TypeTemplateMap,
        GenericMethodsTemplateMap               = ReadonlyBlobRegionStart + ReflectionMapBlob.GenericMethodsTemplateMap,
        DynamicInvokeTemplateData               = ReadonlyBlobRegionStart + ReflectionMapBlob.DynamicInvokeTemplateData,
        BlobIdResourceIndex                     = ReadonlyBlobRegionStart + ReflectionMapBlob.BlobIdResourceIndex,
        BlobIdResourceData                      = ReadonlyBlobRegionStart + ReflectionMapBlob.BlobIdResourceData,
        BlobIdStackTraceEmbeddedMetadata        = ReadonlyBlobRegionStart + ReflectionMapBlob.BlobIdStackTraceEmbeddedMetadata,
        BlobIdStackTraceMethodRvaToTokenMapping = ReadonlyBlobRegionStart + ReflectionMapBlob.BlobIdStackTraceMethodRvaToTokenMapping,
        BlobIdStackTraceLineNumbers             = ReadonlyBlobRegionStart + ReflectionMapBlob.BlobIdStackTraceLineNumbers,
        BlobIdStackTraceDocuments               = ReadonlyBlobRegionStart + ReflectionMapBlob.BlobIdStackTraceDocuments,

        //Native layout blobs:
        NativeLayoutInfo                        = ReadonlyBlobRegionStart + ReflectionMapBlob.NativeLayoutInfo,
        NativeReferences                        = ReadonlyBlobRegionStart + ReflectionMapBlob.NativeReferences,
        GenericsHashtable                       = ReadonlyBlobRegionStart + ReflectionMapBlob.GenericsHashtable,
        NativeStatics                           = ReadonlyBlobRegionStart + ReflectionMapBlob.NativeStatics,
        StaticsInfoHashtable                    = ReadonlyBlobRegionStart + ReflectionMapBlob.StaticsInfoHashtable,
        GenericMethodsHashtable                 = ReadonlyBlobRegionStart + ReflectionMapBlob.GenericMethodsHashtable,
        ExactMethodInstantiationsHashtable      = ReadonlyBlobRegionStart + ReflectionMapBlob.ExactMethodInstantiationsHashtable,

        #endregion

        ReadonlyBlobRegionEnd = 399,
    }
}
