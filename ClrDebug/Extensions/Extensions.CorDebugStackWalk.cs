using System.Runtime.InteropServices;

namespace ClrDebug
{
    public static partial class Extensions
    {
        #region GetContext

        /// <summary>
        /// Returns the context for the current frame in the <see cref="CorDebugStackWalk"/> object.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="stackWalk">The <see cref="CorDebugStackWalk"/> whose current context should be retrieved.</param>
        /// <param name="contextFlags">A bitwise combination of platform-dependent flags that indicate which portions of the context should be read.</param>
        /// <returns>The thread context that was read.</returns>
        public static T GetContext<T>(this CorDebugStackWalk stackWalk, ContextFlags contextFlags) where T : struct
        {
            T context;
            TryGetContext(stackWalk, contextFlags, out context).ThrowOnNotOK();
            return context;
        }

        /// <summary>
        /// Tries to return the context for the current frame in the <see cref="CorDebugStackWalk"/> object.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="stackWalk">The <see cref="CorDebugStackWalk"/> whose current context should be retrieved.</param>
        /// <param name="contextFlags">A bitwise combination of platform-dependent flags that indicate which portions of the context should be read.</param>
        /// <param name="context">The thread context that was read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetContext<T>(this CorDebugStackWalk stackWalk, ContextFlags contextFlags, out T context) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                var hr = stackWalk.TryGetContext(contextFlags, size, out var actualSize, buffer);

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

        #endregion
        #region SetContext

        /// <summary>
        /// Sets the <see cref="CorDebugStackWalk"/> object’s current context to a valid context for the thread.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="stackWalk">The <see cref="CorDebugStackWalk"/> whose current context should be modified.</param>
        /// <param name="flag">A <see cref="CorDebugSetContextFlag"/> flag that indicates whether the context is from the active frame on the stack, or a context obtained by unwinding the stack.</param>
        /// <param name="context">The context to set. The data in the context buffer will be in the format of the Win32 CONTEXT structure.</param>
        public static void SetContext<T>(this CorDebugStackWalk stackWalk, CorDebugSetContextFlag flag, T context) where T : struct
        {
            TrySetContext(stackWalk, flag, context).ThrowOnNotOK();
        }

        /// <summary>
        /// Tries to set the <see cref="CorDebugStackWalk"/> object’s current context to a valid context for the thread.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="stackWalk">The <see cref="CorDebugStackWalk"/> whose current context should be modified.</param>
        /// <param name="flag">A <see cref="CorDebugSetContextFlag"/> flag that indicates whether the context is from the active frame on the stack, or a context obtained by unwinding the stack.</param>
        /// <param name="context">The context to set. The data in the context buffer will be in the format of the Win32 CONTEXT structure.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TrySetContext<T>(this CorDebugStackWalk stackWalk, CorDebugSetContextFlag flag, T context) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(context, buffer, false);

                return stackWalk.TrySetContext(flag, size, buffer);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
    }
}
