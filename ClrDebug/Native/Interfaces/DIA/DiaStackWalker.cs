using System.Runtime.InteropServices;
using ClrDebug.DIA;

namespace ClrDebug.CoClass
{
    [Guid("5485216B-A54C-469F-9670-52B24D5229BB")]
    [CoClass(typeof(DiaStackWalkerClass))]
    [ComImport]
    public interface DiaStackWalker : IDiaStackWalker
    {
    }
}
