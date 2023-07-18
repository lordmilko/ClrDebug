using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.CoClass
{
    [Guid("AA544D42-28CB-11D3-BD22-0000F80849BD")]
#if !GENERATED_MARSHALLING
    [CoClass(typeof(CorSymBinder_deprecatedClass))]
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface CorSymBinder_deprecated : ISymUnmanagedBinder
    {
    }
}
