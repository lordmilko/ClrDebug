using System.Runtime.InteropServices;
using ClrDebug.DIA;

namespace ClrDebug.CoClass
{
    [Guid("79F1BB5F-B66E-48E5-B6A9-1545C323CA3D")]
    [CoClass(typeof(DiaSourceClass))]
    [ComImport]
    public interface DiaSource : IDiaDataSource
    {
    }
}
