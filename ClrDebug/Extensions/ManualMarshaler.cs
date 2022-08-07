using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    //For more information on why this exists, see PSTARTUP_CALLBACK
    class ManualMarshaler : ICustomMarshaler
    {
        public static ICustomMarshaler GetInstance(string pstrCookie) => new ManualMarshaler();

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

        public object MarshalNativeToManaged(IntPtr pNativeData) => Marshal.GetObjectForIUnknown(pNativeData);
    }
}
