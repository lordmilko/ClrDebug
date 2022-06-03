using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("B4CE6286-2A6B-3712-A3B7-1EE1DAD467B5")]
    [CoClass(typeof(CorSymReader_deprecatedClass))]
    [ComImport]
    public interface CorSymReader_deprecated : ISymUnmanagedReader
    {
    }
}