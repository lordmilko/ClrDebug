using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    //For more information on why this exists, see PSTARTUP_CALLBACK
    internal class ManualInterfaceMarshaler : ICustomMarshaler
    {
        public static ICustomMarshaler GetInstance(string pstrCookie) => new ManualInterfaceMarshaler();

        public void CleanUpManagedData(object ManagedObj) => Marshal.ReleaseComObject(ManagedObj);

        public void CleanUpNativeData(IntPtr pNativeData) => Marshal.Release(pNativeData);

        public int GetNativeDataSize() => IntPtr.Size;

        public IntPtr MarshalManagedToNative(object ManagedObj) => Marshal.GetIUnknownForObject(ManagedObj);

        public object MarshalNativeToManaged(IntPtr pNativeData) => Marshal.GetObjectForIUnknown(pNativeData);
    }
}
