using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
#if !GENERATED_MARSHALLING
    class ManualAnsiStringMarshaler : ICustomMarshaler
    {
        public static ICustomMarshaler GetInstance(string pstrCookie) => new ManualAnsiStringMarshaler();

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
#endif
}
