using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("ECCCCF2E-B286-4B3E-A983-860A8793D105")]
    [ComImport]
    public interface ICorDebug2
    {
    }
}