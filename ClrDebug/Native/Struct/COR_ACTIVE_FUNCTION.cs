﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Contains information about the functions that are currently active in a thread's frames. This structure is used by the <see cref="ICorDebugThread2.GetActiveFunctions"/> method.
    /// </summary>
    [DebuggerDisplay("AppDomain = {AppDomain?.ToString(),nq}, Module = {Module?.ToString(),nq}, Function = {Function?.ToString(),nq}, ilOffset = {ilOffset}, flags = {flags}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public partial struct COR_ACTIVE_FUNCTION
    {
        /// <summary>
        /// Pointer to the application domain owner of the ilOffset field.
        /// </summary>
        [MarshalAs(UnmanagedType.Interface)]
        public ICorDebugAppDomain pAppDomain;

        /// <summary>
        /// Pointer to the module owner of the ilOffset field.
        /// </summary>
        [MarshalAs(UnmanagedType.Interface)]
        public ICorDebugModule pModule;

        /// <summary>
        /// Pointer to the function owner of the ilOffset field.
        /// </summary>
        [MarshalAs(UnmanagedType.Interface)]
        public ICorDebugFunction2 pFunction;

        /// <summary>
        /// The Microsoft intermediate language (MSIL) offset of the frame.
        /// </summary>
        public int ilOffset;

        /// <summary>
        /// Reserved for future extensibility.
        /// </summary>
        public int flags;

        /// <summary>
        /// Pointer to the application domain owner of the <see cref="ilOffset"/> field.
        /// </summary>
        public CorDebugAppDomain AppDomain => pAppDomain == null ? null : new CorDebugAppDomain(pAppDomain);

        /// <summary>
        /// Pointer to the module owner of the <see cref="ilOffset"/> field.
        /// </summary>
        public CorDebugModule Module => pModule == null ? null : new CorDebugModule(pModule);

        /// <summary>
        /// Pointer to the function owner of the <see cref="ilOffset"/> field.
        /// </summary>
        public CorDebugFunction Function => pFunction == null ? null : new CorDebugFunction((ICorDebugFunction) pFunction);
    }
}
