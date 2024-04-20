using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
#if !GENERATED_MARSHALLING
    class NoFreeAnsiStringMarshaler : ICustomMarshaler
    {
        public static ICustomMarshaler GetInstance(string pstrCookie) => new NoFreeAnsiStringMarshaler();

        public void CleanUpManagedData(object ManagedObj)
        {
            throw new NotImplementedException();
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
            throw new NotImplementedException();
        }

        public int GetNativeDataSize()
        {
            throw new NotImplementedException();
        }

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            throw new NotImplementedException();
        }

        //The default marshaler will attempt to free the native string. We don't want that
        public object MarshalNativeToManaged(IntPtr pNativeData) => Marshal.PtrToStringAnsi(pNativeData);
    }
#else
    [CustomMarshaller(typeof(string), MarshalMode.Default, typeof(AnsiStringMarshaller))]
    internal static unsafe class NoFreeAnsiStringMarshaller
    {
        public static string? ConvertToManaged(byte* unmanaged) =>
            AnsiStringMarshaller.ConvertToManaged(unmanaged);
    }
#endif
}
