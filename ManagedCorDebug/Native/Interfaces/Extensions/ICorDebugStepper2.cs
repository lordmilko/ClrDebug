using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides support for just my code (JMC) debugging.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C5B6E9C3-E7D1-4A8E-873B-7F047F0706F7")]
    [ComImport]
    public interface ICorDebugStepper2
    {
        /// <summary>
        /// Sets a value that specifies whether this ICorDebugStepper steps only through code that is authored by an application's developer. This process is also known as just my code (JMC) debugging.
        /// </summary>
        /// <param name="fIsJMCStepper">[in] Set to true to step only through code that is authored by an application's developer; otherwise, set to false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetJMC([In] int fIsJMCStepper);
    }
}