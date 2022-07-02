using System.Runtime.InteropServices;

namespace ClrDebug.CoClass
{
    [CoClass(typeof(CorSymReader_SxSClass))]
    [Guid("B4CE6286-2A6B-3712-A3B7-1EE1DAD467B5")]
    [ComImport]
    public interface CorSymReader_SxS : ISymUnmanagedReader
    {
    }
}