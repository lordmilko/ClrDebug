using System.Runtime.InteropServices;

namespace ClrDebug
{
    public static partial class Extensions
    {
        #region GetContext

        /// <summary>
        /// Gets the current context of this unwinder.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="virtualUnwinder">The <see cref="CorDebugStackWalk"/> whose current context should be retrieved.</param>
        /// <param name="contextFlags">Flags that specify which parts of the context to return (defined in WinNT.h).</param>
        /// <returns>The thread context that was read.</returns>
        public static unsafe T GetContext<T>(this CorDebugVirtualUnwinder virtualUnwinder, ContextFlags contextFlags) where T : unmanaged
        {
            T context;
            TryGetContext(virtualUnwinder, contextFlags, out context).ThrowOnNotOK();
            return context;
        }

        /// <summary>
        /// Tries to get the current context of this unwinder.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="virtualUnwinder">The <see cref="CorDebugStackWalk"/> whose current context should be retrieved.</param>
        /// <param name="contextFlags">Flags that specify which parts of the context to return (defined in WinNT.h).</param>
        /// <param name="context">The thread context that was read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static unsafe HRESULT TryGetContext<T>(this CorDebugVirtualUnwinder virtualUnwinder, ContextFlags contextFlags, out T context) where T : unmanaged
        {
            var size = sizeof(T);
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                var hr = virtualUnwinder.TryGetContext(contextFlags, size, out var actualSize, buffer);

                if (hr == HRESULT.S_OK)
                    context = *(T*) buffer;
                else
                    context = default(T);

                return hr;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
    }
}
