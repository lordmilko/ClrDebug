using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif
using ClrDebug.DIA;

namespace ClrDebug.CoClass
{
    [Guid("79F1BB5F-B66E-48E5-B6A9-1545C323CA3D")]
#if !GENERATED_MARSHALLING
    [CoClass(typeof(DiaSourceClass))]
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface DiaSource : IDiaDataSource
    {
    }
}
