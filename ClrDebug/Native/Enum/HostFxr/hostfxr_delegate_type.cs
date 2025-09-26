namespace ClrDebug
{
    public enum hostfxr_delegate_type
    {
        /// <summary>
        /// COM activation entry-point<para/>
        /// System.Private.CoreLib -> Internal.Runtime.InteropServices.ComActivator -> GetClassFactoryForTypeInternal
        /// </summary>
        hdt_com_activation,

        /// <summary>
        /// IJW (C++/CLI) entry-point<para/>
        /// System.Private.CoreLib -> Internal.Runtime.InteropServices.InMemoryAssemblyLoader -> LoadInMemoryAssembly
        /// </summary>
        hdt_load_in_memory_assembly,

        /// <summary>
        /// WinRT activation entry-point. .NET Core 3 only. Not supported in .NET 5 and above.
        /// </summary>
        hdt_winrt_activation,

        /// <summary>
        /// COM activation entry-point<para/>
        /// System.Private.CoreLib -> Internal.Runtime.InteropServices.ComActivator -> RegisterClassForTypeInternal
        /// </summary>
        hdt_com_register,

        /// <summary>
        /// COM activation entry-point<para/>
        /// System.Private.CoreLib -> Internal.Runtime.InteropServices.ComActivator -> UnregisterClassForTypeInternal
        /// </summary>
        hdt_com_unregister,

        /// <summary>
        /// Entry point which loads an assembly (with dependencies) and returns function pointer for a specified static method.<para/>
        /// Signature: <see cref="load_assembly_and_get_function_pointer_fn"/><para/>
        /// Implementation: System.Private.CoreLib -> Internal.Runtime.InteropServices.ComponentActivator -> LoadAssemblyAndGetFunctionPointer
        /// </summary>
        hdt_load_assembly_and_get_function_pointer,

        /// <summary>
        /// Entry-point which finds a managed method and returns a function pointer to it. .NET 5 and above<para/>
        /// Signature: <see cref="get_function_pointer_fn"/><para/>
        /// Implementation: System.Private.CoreLib -> Internal.Runtime.InteropServices.ComponentActivator -> GetFunctionPointer
        /// </summary>
        hdt_get_function_pointer,

        /// <summary>
        /// Entry-point which loads an assembly by its path. .NET 8 and above<para/>
        /// Signature: load_assembly_fn<para/>
        /// Implementation: System.Private.CoreLib -> Internal.Runtime.InteropServices.ComponentActivator -> LoadAssembly
        /// </summary>
        hdt_load_assembly,

        /// <summary>
        /// Entry-point which loads an assembly from a byte array.<para/>
        /// Signature: load_assembly_bytes_fn<para/>
        /// Implementation: System.Private.CoreLib -> Internal.Runtime.InteropServices.ComponentActivator -> LoadAssemblyBytes
        /// </summary>
        hdt_load_assembly_bytes
    }
}
