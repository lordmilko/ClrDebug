﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides support for just my code (JMC) debugging.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C5B6E9C3-E7D1-4A8E-873B-7F047F0706F7")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugStepper2
    {
        /// <summary>
        /// Sets a value that specifies whether this <see cref="ICorDebugStepper"/> steps only through code that is authored by an application's developer.<para/>
        /// This process is also known as just my code (JMC) debugging.
        /// </summary>
        /// <param name="fIsJMCStepper">[in] Set to true to step only through code that is authored by an application's developer; otherwise, set to false.</param>
        [PreserveSig]
        HRESULT SetJMC(
            [In, MarshalAs(UnmanagedType.Bool)] bool fIsJMCStepper);
    }
}
