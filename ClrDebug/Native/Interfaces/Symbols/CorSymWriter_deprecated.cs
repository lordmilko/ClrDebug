using System.Runtime.InteropServices;

namespace ClrDebug.CoClass
{
    [Guid("ED14AA72-78E2-4884-84E2-334293AE5214")]
    [CoClass(typeof(CorSymWriter_deprecatedClass))]
    [ComImport]
    public interface CorSymWriter_deprecated : ISymUnmanagedWriter
    {
    }
}