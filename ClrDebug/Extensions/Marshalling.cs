#if GENERATED_MARSHALLING

using System;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.InteropServices;

//Facilities for enabling COM generated marshalling in .NET 8.0+ builds of ClrDebug

namespace ClrDebug
{
    public static partial class Extensions
    {
        internal static readonly StrategyBasedComWrappers DefaultMarshallingInstance = new StrategyBasedComWrappers();
    }

    /// <summary>
    /// Represents a fake <see cref="System.Runtime.InteropServices.InAttribute"/> for compatibility
    /// with <see cref="System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute"/>
    /// which does not allow this attribute.
    /// </summary>
    internal class InAttribute : Attribute
    {
    }

    /// <summary>
    /// Represents a fake <see cref="System.Runtime.InteropServices.OutAttribute"/> for compatibility
    /// with <see cref="System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute"/>
    /// which does not allow this attribute.
    /// </summary>
    internal class OutAttribute : Attribute
    {
    }

    #region Guid

    //Even though Guid is now considered "strictly blittable", it still doesn't natively work
    //https://github.com/dotnet/runtime/pull/88213

    [CustomMarshaller(typeof(Guid), MarshalMode.Default, typeof(GuidMarshaller))]
    public static unsafe class GuidMarshaller
    {
        public struct GuidNative
        {
            public int a;
            public short b;
            public short c;
            public byte d;
            public byte e;
            public byte f;
            public byte g;
            public byte h;
            public byte i;
            public byte j;
            public byte k;
        }

        public static GuidNative ConvertToUnmanaged(Guid managed) => *(GuidNative*)&managed;

        public static Guid ConvertToManaged(GuidNative unmanaged) => *(Guid*)&unmanaged;
    }

    #endregion
    #region VARIANT

    [CustomMarshaller(typeof(object), MarshalMode.Default, typeof(VariantMarshaller))]
    public static unsafe class VariantMarshaller
    {
        public static VARIANT ConvertToUnmanaged(object managed)
        {
            throw new NotImplementedException("Marshalling variants is not yet implemented.");
        }

        public static object ConvertToManaged(VARIANT variant)
        {
            throw new NotImplementedException("Marshalling variants is not yet implemented.");
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct VARIANT
        {
            //On x86, VARIANT is 16 bytes, while on x64 its 24 bytes.
            //A VARIANT consists of an 8 byte header followed by 2 pointers (tagBRECORD)
            //For our purposes, we don't really care about representing VARIANT properly,
            //all that amtters is that the size is right

            //8 bytes
            internal VARENUM vt;
            public ushort wReserved1;
            public ushort wReserved2;
            public ushort wReserved3;

            public IntPtr dummy1;
            public IntPtr dummy2;
        }
    }

    #endregion
}

#endif
