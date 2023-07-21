using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.Tests
{
#if GENERATED_MARSHALLING
    //The COM source generator cannot tell if a struct can be used in managed code when it is defined in another assembly. As such,
    //we must redefine VARIANT here and forward to the real VariantMarshaller implementation in ClrDebug

    [CustomMarshaller(typeof(object), MarshalMode.Default, typeof(VariantMarshaller))]
    public static unsafe class VariantMarshaller
    {
        public static VARIANT ConvertToUnmanaged(object managed)
        {
            var lvar = ClrDebug.VariantMarshaller.ConvertToUnmanaged(managed);

            return *(VARIANT*)&lvar;
        }

        public static object ConvertToManaged(VARIANT variant) =>
            ClrDebug.VariantMarshaller.ConvertToManaged(*(ClrDebug.VariantMarshaller.VARIANT*)&variant);

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct VARIANT
        {
            //On x86, VARIANT is 16 bytes, while on x64 its 24 bytes.
            //A VARIANT consists of an 8 byte header followed by 2 pointers (tagBRECORD)
            //For our purposes, we don't really care about representing VARIANT properly,
            //all that amtters is that the size is right

            //8 bytes
            internal int vt;
            public ushort wReserved1;
            public ushort wReserved2;
            public ushort wReserved3;

            public IntPtr dummy1;
            public IntPtr dummy2;
        }
    }
#endif
}
