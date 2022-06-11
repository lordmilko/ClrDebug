using System.Runtime.InteropServices;

namespace ManagedCorDebug.CoClass
{
    [CoClass(typeof(CorSymBinder_SxSClass))]
    [Guid("AA544D42-28CB-11D3-BD22-0000F80849BD")]
    [ComImport]
    public interface CorSymBinder_SxS : ISymUnmanagedBinder
    {
    }
}