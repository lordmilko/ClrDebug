using System;
using System.Diagnostics;
using ClrDebug.TypeLib;

namespace ClrDebug.DIA
{
    //This struct is specific to DIA and its unique string marshalling rules

    [DebuggerDisplay("lpwstrName = {lpwstrName}, propid = {propid}, vt = {vt.ToString(),nq}")]
    public class STATPROPSTG //This is a class so you can't use it directly on a COM method
    {
        //This members is listed as being an LPOLESTR (wchat_t*), however it is always supposed to be freed via CoTaskMemFree.
        //The reality is even more complicated however, because DbgHelp's statically linked DIA allocates this value via DiaAllocateString(),
        //which means this field is subject to the normal DIA string marshalling rules. Unfortunately, I couldn't find any way of forcing
        //an ICustomMarshaler to work. You can't use ICustomMarshaler with struct values, and when I made it an out class, MarshalNativeToManaged
        //was passed the lpwstrName, not the STATPROPSTG*. Thus, we're forced to manually take control of the marshalling process
        public string lpwstrName;
        public int propid;
        public VARENUM vt;
        [DebuggerDisplay("lpwstrName = {lpwstrName.ToString(),nq}, propid = {propid}, vt = {vt.ToString(),nq}")]
        public struct Native
        {
            public IntPtr lpwstrName;
            public int propid;
            public VARENUM vt;

            /// <summary>
            /// Marshals this value to a <see cref="STATPROPSTG"/> and frees the string pointed to by <see cref="lpwstrName"/>.<para/>
            /// You must call this method any time a <see cref="Native"/> is retrieved from a COM method.
            /// </summary>
            /// <returns></returns>
            public STATPROPSTG Marshal()
            {
                var str = Extensions.DiaStringToManaged(lpwstrName);
                Extensions.DiaFreeString(lpwstrName);
                lpwstrName = IntPtr.Zero;

                return new STATPROPSTG
                {
                    lpwstrName = str,
                    propid = propid,
                    vt = vt
                };
            }
        }
    }
}
