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
    }
}
