using System.Runtime.InteropServices;

namespace ClrDebug.CoClass
{
    [CoClass(typeof(EmbeddedCLRCorDebugClass))]
    [Guid("3D6F5F61-7538-11D3-8D5B-00104B35E7EF")]
    [ComImport]
    public interface EmbeddedCLRCorDebug : ICorDebug
    {
    }
}