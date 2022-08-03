using System.Runtime.InteropServices;

namespace ClrDebug
{
    public static partial class Extensions
    {
        #region GetContext

        public static T GetContext<T>(this XCLRDataFrame dataFrame, ContextFlags contextFlags) where T : struct
        {
            T context;
            TryGetContext(dataFrame, contextFlags, out context).ThrowOnNotOK();
            return context;
        }

        public static HRESULT TryGetContext<T>(this XCLRDataFrame dataFrame, ContextFlags contextFlags, out T context) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                var hr = dataFrame.TryGetContext(contextFlags, size, out var actualSize, buffer);

                if (hr == HRESULT.S_OK)
                    context = Marshal.PtrToStructure<T>(buffer);
                else
                    context = default(T);

                return hr;
            }
            finally
            {
                Marshal.AllocHGlobal(buffer);
            }
        }

        #endregion
    }
}
