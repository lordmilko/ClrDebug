using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides a method to allocate memory for a new Microsoft intermediate language (MSIL) function body.
    /// </summary>
    /// <remarks>
    /// Each allocator is module-specific and ensures that the function body will be at a positive offset from the base
    /// of the module. Memory above the base of a module can be precious, so the allocator should be used to allocate memory
    /// only for a function body.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A0EFB28B-6EE2-4D7B-B983-A75EF7BEEDB8")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IMethodMalloc
    {
        /// <summary>
        /// Attempts to allocate a specified amount of memory for a new Microsoft intermediate language (MSIL) function body.
        /// </summary>
        /// <param name="cb">[in] The number of bytes to allocate for the method body.</param>
        /// <remarks>
        /// The allocated memory will begin at an address greater than the base address of the module that is associated with
        /// this allocator. In other words, each allocator is created for a particular module, and will attempt to allocate
        /// memory at a positive offset from its base address. If Alloc fails to allocate the requested number of bytes at
        /// an address greater than the base address of the module, it returns NULL. The Alloc method should be used in conjunction
        /// with the <see cref="ICorProfilerInfo.SetILFunctionBody"/> method.
        /// </remarks>
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr Alloc(
            [In] int cb);
    }
}
