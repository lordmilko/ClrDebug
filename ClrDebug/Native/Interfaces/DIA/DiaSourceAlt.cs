using System.Runtime.InteropServices;
using ClrDebug.DIA;

namespace ClrDebug.CoClass
{
    [CoClass(typeof(DiaSourceAltClass))]
    [Guid("79F1BB5F-B66E-48E5-B6A9-1545C323CA3D")]
    [ComImport]
    public interface DiaSourceAlt : IDiaDataSource
    {
    }
}
