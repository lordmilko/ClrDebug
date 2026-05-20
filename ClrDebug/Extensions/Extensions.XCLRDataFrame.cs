using System.Runtime.InteropServices;

namespace ClrDebug
{
    public static partial class Extensions
    {
        #region GetContext

        public static unsafe T GetContext<T>(this XCLRDataFrame dataFrame, ContextFlags contextFlags) where T : unmanaged
        {
            T context;
            TryGetContext(dataFrame, contextFlags, out context).ThrowOnNotOK();
            return context;
        }

        public static unsafe HRESULT TryGetContext<T>(this XCLRDataFrame dataFrame, ContextFlags contextFlags, out T context) where T : unmanaged
        {
            var size = sizeof(T);
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                var hr = dataFrame.TryGetContext(contextFlags, size, out var actualSize, buffer);

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
