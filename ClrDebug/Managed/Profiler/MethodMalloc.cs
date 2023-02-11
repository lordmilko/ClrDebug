using System;

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
    public class MethodMalloc : ComObject<IMethodMalloc>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodMalloc"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public MethodMalloc(IMethodMalloc raw) : base(raw)
        {
        }

        #region IMethodMalloc
        #region Alloc

        /// <summary>
        /// Attempts to allocate a specified amount of memory for a new Microsoft intermediate language (MSIL) function body.
        /// </summary>
        /// <param name="cb">[in] The number of bytes to allocate for the method body.</param>
        /// <remarks>
        /// The allocated memory will begin at an address greater than the base address of the module that is associated with
        /// this allocator. In other words, each allocator is created for a particular module, and will attempt to allocate
        /// memory at a positive offset from its base address. If Alloc fails to allocate the requested number of bytes at
        /// an address greater than the base address of the module, it returns NULL. The Alloc method should be used in conjunction
        /// with the <see cref="CorProfilerInfo.SetILFunctionBody"/> method.
        /// </remarks>
        public IntPtr Alloc(int cb)
        {
            /*IntPtr Alloc(
            [In] int cb);*/
            return Raw.Alloc(cb);
        }

        #endregion
        #endregion
    }
}
