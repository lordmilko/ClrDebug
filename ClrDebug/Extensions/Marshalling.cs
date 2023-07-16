#if GENERATED_MARSHALLING

using System;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.InteropServices;

//Facilities for enabling COM generated marshalling in .NET 8.0+ builds of ClrDebug

namespace ClrDebug
{
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

        public static GuidNative ConvertToUnmanaged(Guid managed) => Convert<Guid, GuidNative>(managed);

        public static Guid ConvertToManaged(GuidNative unmanaged) => Convert<GuidNative, Guid>(unmanaged);

        private static TOut Convert<TIn, TOut>(TIn value)
        {
            var buffer = Marshal.AllocHGlobal(Marshal.SizeOf<TIn>());

            try
            {
                Marshal.StructureToPtr(value, buffer, false);

                var converted = Marshal.PtrToStructure<TOut>(buffer);

                return converted;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
    }

    #endregion
}

#endif
