using System.Runtime.InteropServices;

namespace ClrDebug
{
    public static partial class Extensions
    {
        #region GetContext

        public static unsafe T GetContext<T>(this XCLRDataStackWalk stackWalk, ContextFlags contextFlags) where T : unmanaged
        {
            T context;
            TryGetContext(stackWalk, contextFlags, out context).ThrowOnNotOK();
            return context;
        }

        public static unsafe HRESULT TryGetContext<T>(this XCLRDataStackWalk stackWalk, ContextFlags contextFlags, out T context) where T : unmanaged
        {
            var size = sizeof(T);
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                var hr = stackWalk.TryGetContext(contextFlags, size, out var actualSize, buffer);

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
        #region SetContext

        public static unsafe void SetContext<T>(this XCLRDataStackWalk stackWalk, T context) where T : unmanaged
        {
            TrySetContext(stackWalk, context).ThrowOnNotOK();
        }

        public static unsafe HRESULT TrySetContext<T>(this XCLRDataStackWalk stackWalk, T context) where T : unmanaged
        {
            var size = sizeof(T);
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(context, buffer, false);

                return stackWalk.TrySetContext(size, buffer);
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
    }
}
