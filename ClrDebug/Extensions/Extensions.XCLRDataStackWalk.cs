using System.Runtime.InteropServices;

namespace ClrDebug
{
    public static partial class Extensions
    {
        #region GetContext

        public static T GetContext<T>(this XCLRDataStackWalk stackWalk, ContextFlags contextFlags) where T : struct
        {
            T context;
            TryGetContext(stackWalk, contextFlags, out context).ThrowOnNotOK();
            return context;
        }

        public static HRESULT TryGetContext<T>(this XCLRDataStackWalk stackWalk, ContextFlags contextFlags, out T context) where T : struct
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

        public static void SetContext<T>(this XCLRDataStackWalk stackWalk, T context) where T : struct
        {
            TrySetContext(stackWalk, context).ThrowOnNotOK();
        }

        public static HRESULT TrySetContext<T>(this XCLRDataStackWalk stackWalk, T context) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(context, buffer, false);

                return stackWalk.TrySetContext(size, buffer);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
    }
}
