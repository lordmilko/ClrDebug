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
        private object current;

        public static ICustomMarshaler GetInstance(string pstrCookie) => new DiaStringMarshaller();

        public void CleanUpManagedData(object ManagedObj)
        {
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
            if (current == null)
                DiaFreeString(pNativeData);
            else
            {
                if (current is string[] a)
                {
                    for (var i = 0; i < a.Length; i++)
                    {
                        var ptr = Marshal.ReadIntPtr(pNativeData + (i * IntPtr.Size));

                        DiaFreeString(ptr);
                    }

                    current = null;
                    Marshal.FreeHGlobal(pNativeData);
                }
                else
                    throw new NotImplementedException($"Don't know how to cleanup a value of type {current.GetType().Name}");
            }
        }

        public int GetNativeDataSize() => throw new NotImplementedException();

        public unsafe IntPtr MarshalManagedToNative(object ManagedObj)
        {
            if (ManagedObj == null)
                return IntPtr.Zero;

            Debug.Assert(current == null);

            if (ManagedObj is string[] a)
            {
                current = a;
                return Marshal.AllocHGlobal(a.Length * IntPtr.Size);
            }

            if (ManagedObj is string s)
            {
                //We allocate the string, and then DbgHelp is responsible for freeing it, e.g. dbghelp!diaFillSymbolInfo calls dbghelp!DiaFreeString -> LocalFree

                if (DiaStringsUseComHeap)
                    return Marshal.StringToBSTR(s);

                //We can't just do Marshal.StringToHGlobalUni; we need to create a fake BSTR with a length in front of it and hand out a pointer to the area
                //after the length, so that when dbghelp!DiaFreeString rewinds the pointer, it gets the true allocation address

                var charBytes = s.Length * 2 + 2; //+2 for the null terminator
                var buffer = Marshal.AllocHGlobal(charBytes + 4); //Each character is 2 bytes + 4 bytes at the start for the length + 2 bytes for the null terminator

                IntPtr str = buffer + 4;

                char* dest = (char*) str;

                for (var i = 0; i < s.Length; i++)
                    dest[i] = s[i];

                dest[s.Length] = '\0';

                *((int*) buffer) = charBytes;

                return str;
            }

            throw new NotImplementedException($"Don't know how to marshal a value of type {ManagedObj.GetType().Name}");
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            if (current != null)
            {
                if (current is string[] a)
                {
                    for (var i = 0; i < a.Length; i++)
                        a[i] = DiaStringToManaged(Marshal.ReadIntPtr(pNativeData + (i * IntPtr.Size)));

                    return a;
                }
                else
                    throw new NotImplementedException($"Don't know how to marshal a value of type {current.GetType().Name}");
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
