using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif
using ClrDebug.DIA;

namespace ClrDebug.CoClass
{
    [Guid("5485216B-A54C-469F-9670-52B24D5229BB")]
#if !GENERATED_MARSHALLING
    [CoClass(typeof(DiaStackWalkerClass))]
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface DiaStackWalker : IDiaStackWalker
    {
    }
}
