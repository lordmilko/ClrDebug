namespace ClrDebug
{
    public enum APPDOMAIN_SECURITY_FLAGS
    {
        APPDOMAIN_SECURITY_DEFAULT = 0x0,
        APPDOMAIN_SECURITY_SANDBOXED = 0x1,       // appdomain is sandboxed
        APPDOMAIN_SECURITY_FORBID_CROSSAD_REVERSE_PINVOKE = 0x2,         // no cross ad reverse pinvokes
        APPDOMAIN_IGNORE_UNHANDLED_EXCEPTIONS = 0x4, //
        APPDOMAIN_FORCE_TRIVIAL_WAIT_OPERATIONS = 0x08, // do not pump messages during wait operations, do not call sync context
                                                        // When passed by the host, this flag will allow any assembly to perform PInvoke or COMInterop operations.
                                                        // Otherwise, by default, only platform assemblies can perform those operations.
        APPDOMAIN_ENABLE_PINVOKE_AND_CLASSIC_COMINTEROP = 0x10,

        APPDOMAIN_ENABLE_PLATFORM_SPECIFIC_APPS = 0x40,
        APPDOMAIN_ENABLE_ASSEMBLY_LOADFILE = 0x80,

        APPDOMAIN_DISABLE_TRANSPARENCY_ENFORCEMENT = 0x100,
    }
}
