using System.Runtime.InteropServices;

namespace ClrDebug
{
    public static partial class Extensions
    {
        /// <summary>
        /// Gets the context of the current thread.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="registerSet">The <see cref="CorDebugRegisterSet"/> whose context should be retrieved.</param>
        /// <param name="contextFlags">A bitwise combination of platform-dependent flags that indicate which portions of the context should be read.</param>
        /// <returns>The thread context that was read.</returns>
        public static T GetThreadContext<T>(this CorDebugRegisterSet registerSet, ContextFlags contextFlags) where T : struct
        {
            T context;
            TryGetThreadContext(registerSet, contextFlags, out context).ThrowOnNotOK();
            return context;
        }

        /// <summary>
        /// Tries to get the context of the current thread.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="registerSet">The <see cref="CorDebugRegisterSet"/> whose context should be retrieved.</param>
        /// <param name="contextFlags">A bitwise combination of platform-dependent flags that indicate which portions of the context should be read.</param>
        /// <param name="context">The thread context that was read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetThreadContext<T>(this CorDebugRegisterSet registerSet, ContextFlags contextFlags, out T context) where T : struct
        {
            var size = Marshal.SizeOf<T>();

            var buffer = AllocAndInitContext<T>(size, contextFlags);

            try
            {
                var hr = registerSet.TryGetThreadContext(size, buffer);

                if (hr == HRESULT.S_OK)
                    context = Marshal.PtrToStructure<T>(buffer);
                else
                    context = default(T);

                return hr;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        //ICorDebugRegisterSet.SetThreadContext is not implemented in .NET 2.0+
    }
}
