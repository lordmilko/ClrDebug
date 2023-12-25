using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif
using ClrDebug.DIA;

namespace ClrDebug.CoClass
{
    /// <summary>
    /// An <see cref="IDiaDataSource"/> that uses the system heap for allocating strings.<para/>
    ///
    /// A process may either make DiaSourceAlt objects or DiaSource objects, but not both.
    /// When using DiaSourceAlt all returned BSTR's are really LPCOLESTR and should not be
    /// used with other BSTR management routines, in particular they must be released using
    /// LocalFree( bstr )
    /// </summary>
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
