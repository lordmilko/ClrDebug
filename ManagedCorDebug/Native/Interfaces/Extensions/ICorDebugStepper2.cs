using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C5B6E9C3-E7D1-4A8E-873B-7F047F0706F7")]
    [ComImport]
    public interface ICorDebugStepper2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetJMC([In] int fIsJMCStepper);
    }
}