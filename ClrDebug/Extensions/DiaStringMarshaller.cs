using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif
using static ClrDebug.Extensions;

namespace ClrDebug
{
#if !GENERATED_MARSHALLING
    class DiaStringMarshaller : ICustomMarshaler
    {
        [ThreadStatic]
        private string[] current;

        public static ICustomMarshaler GetInstance(string pstrCookie) => new DiaStringMarshaller();

        public void CleanUpManagedData(object ManagedObj) => throw new NotImplementedException();

        public void CleanUpNativeData(IntPtr pNativeData)
        {
            if (current == null)
                DiaFreeString(pNativeData);
            else
            {
                for (var i = 0; i < current.Length; i++)
                {
                    var ptr = Marshal.ReadIntPtr(pNativeData + (i * IntPtr.Size));

                    DiaFreeString(ptr);
                }

                current = null;
                Marshal.FreeHGlobal(pNativeData);
            }
        }

        public int GetNativeDataSize() => throw new NotImplementedException();

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            if (ManagedObj == null)
                return IntPtr.Zero;

            Debug.Assert(current == null);

            Debug.WriteLine(GetHashCode());

            if (ManagedObj is string[] s)
            {
                current = s;
                return Marshal.AllocHGlobal(s.Length * IntPtr.Size);
            }

            throw new NotImplementedException($"Don't know how to marshal a value of type {ManagedObj.GetType().Name}");
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            if (current != null)
            {
                for (var i = 0; i < current.Length; i++)
                    current[i] = DiaStringToManaged(Marshal.ReadIntPtr(pNativeData + (i * IntPtr.Size)));

                return current;
            }
            else
                return DiaStringToManaged(pNativeData);
        }
    }
#else
    [CustomMarshaller(typeof(string), MarshalMode.Default, typeof(DiaStringMarshaller))]
    public static unsafe class DiaStringMarshaller
    {
        public static void* ConvertToUnmanaged(string managed)
        {
            if (managed == null)
                return (void*) IntPtr.Zero;

            throw new NotImplementedException();
        }

        public static string ConvertToManaged(void* unmanaged) => DiaStringToManaged((IntPtr) unmanaged);

        public static void Free(void* unmanaged) => DiaFreeString((IntPtr) unmanaged);
    }
#endif
}
