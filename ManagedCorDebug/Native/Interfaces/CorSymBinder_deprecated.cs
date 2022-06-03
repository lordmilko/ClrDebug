using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("AA544D42-28CB-11D3-BD22-0000F80849BD")]
    [CoClass(typeof(CorSymBinder_deprecatedClass))]
    [ComImport]
    public interface CorSymBinder_deprecated : ISymUnmanagedBinder
    {
    }
}