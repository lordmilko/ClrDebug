using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    //For more information on why this exists, see PSTARTUP_CALLBACK
    internal class ManualInterfaceMarshaler : ICustomMarshaler
    {
        public static ICustomMarshaler GetInstance(string pstrCookie) => new ManualInterfaceMarshaler();

        public void CleanUpManagedData(object ManagedObj)
        {
#if NETSTANDARD
            Marshal.ReleaseComObject(ManagedObj);
#else
            throw new NotImplementedException("Custom Marshalling for non-Windows is not implemented.");
#endif
        }

        public void CleanUpNativeData(IntPtr pNativeData) => Marshal.Release(pNativeData);

        public int GetNativeDataSize() => IntPtr.Size;

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
#if NETSTANDARD
            return Marshal.GetIUnknownForObject(ManagedObj);
#else
            throw new NotImplementedException("Custom Marshalling for non-Windows is not implemented.");
#endif
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
#if NETSTANDARD
            return Marshal.GetObjectForIUnknown(pNativeData);
#else
            throw new NotImplementedException("Custom Marshalling for non-Windows is not implemented.");
#endif
        }
    }
}
