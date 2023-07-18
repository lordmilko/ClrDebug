using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.CoClass
{
    [Guid("3D6F5F61-7538-11D3-8D5B-00104B35E7EF")]
#if !GENERATED_MARSHALLING
    [CoClass(typeof(CorDebugClass))]
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface CorDebug : ICorDebug
    {
    }
}
