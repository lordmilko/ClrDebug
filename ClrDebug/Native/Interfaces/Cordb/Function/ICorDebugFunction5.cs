using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("9D4DAB7B-3401-4F37-BD08-CA09F3FDF10F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugFunction5
    {
        /// <summary>
        /// Triggers a new JIT so the next time the function is called, it will be unoptimized. Will trigger a JIT even for R2R code.
        /// </summary>
        [PreserveSig]
        HRESULT DisableOptimizations();

        /// <summary>
        /// Indicates whether this method had optimizations disabled already.
        /// </summary>
        [PreserveSig]
        HRESULT AreOptimizationsDisabled(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pOptimizationsDisabled);
    }
}
