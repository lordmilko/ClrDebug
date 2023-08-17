using System;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

//Facilities for enabling COM generated marshalling in .NET 8.0+ builds of ClrDebug

namespace ClrDebug
{
#if GENERATED_MARSHALLING
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
    #region CrossPlatformString

    public static unsafe class CrossPlatformStringMarshaller
    {
        public static byte* ConvertToUnmanaged(string managed)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return (byte*) Utf16StringMarshaller.ConvertToUnmanaged(managed);

            return Utf8StringMarshaller.ConvertToUnmanaged(managed);
        }

        public static string ConvertToManaged(IntPtr unmanaged) =>
            ConvertToManaged((byte*) unmanaged);

        public static string ConvertToManaged(byte* unmanaged)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return Utf16StringMarshaller.ConvertToManaged((ushort*) unmanaged);

            return Utf8StringMarshaller.ConvertToManaged(unmanaged);
        }

        public static void Free(IntPtr unmanaged) =>
            Free((IntPtr) unmanaged);

        public static void Free(byte* unmanaged)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                Utf16StringMarshaller.Free((ushort*) unmanaged);

            Utf8StringMarshaller.Free(unmanaged);
        }
    }

    #endregion
    #region VARIANT

    [CustomMarshaller(typeof(object), MarshalMode.Default, typeof(VariantMarshaller))]
    public static unsafe class VariantMarshaller
    {
        public static VARIANT ConvertToUnmanaged(object managed)
        {
            var size = Marshal.SizeOf<VARIANT>();

            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                var typeData = (void*)(buffer + 8);
                var remaining = size - 8;

                VARENUM vt = VARENUM.VT_EMPTY;

                if (managed != null)
                {
                    var typeCode = Type.GetTypeCode(managed.GetType());

                    switch (typeCode)
                    {
                        case TypeCode.Byte:
                            vt = VARENUM.VT_UI1;
                            var u1 = (byte)managed;
                            Buffer.MemoryCopy(&u1, typeData, remaining, Marshal.SizeOf<byte>());
                            break;

                        case TypeCode.UInt16:
                            vt = VARENUM.VT_UI2;
                            var u2 = (ushort)managed;
                            Buffer.MemoryCopy(&u2, typeData, remaining, Marshal.SizeOf<ushort>());
                            break;

                        case TypeCode.UInt32:
                            vt = VARENUM.VT_UI4;
                            var u4 = (uint)managed;
                            Buffer.MemoryCopy(&u4, typeData, remaining, Marshal.SizeOf<uint>());
                            break;

                        case TypeCode.UInt64:
                            vt = VARENUM.VT_UI8;
                            var u8 = (ulong)managed;
                            Buffer.MemoryCopy(&u8, typeData, remaining, Marshal.SizeOf<ulong>());
                            break;

                        case TypeCode.SByte:
                            vt = VARENUM.VT_I1;
                            var i1 = (sbyte)managed;
                            Buffer.MemoryCopy(&i1, typeData, remaining, Marshal.SizeOf<sbyte>());
                            break;

                        case TypeCode.Int16:
                            vt = VARENUM.VT_I2;
                            var i2 = (short)managed;
                            Buffer.MemoryCopy(&i2, typeData, remaining, Marshal.SizeOf<short>());
                            break;

                        case TypeCode.Int32:
                            vt = VARENUM.VT_I4;
                            var i4 = (int)managed;
                            Buffer.MemoryCopy(&i4, typeData, remaining, Marshal.SizeOf<int>());
                            break;

                        case TypeCode.Int64:
                            vt = VARENUM.VT_I8;
                            var i8 = (long)managed;
                            Buffer.MemoryCopy(&i8, typeData, remaining, Marshal.SizeOf<long>());
                            break;

                        case TypeCode.Single:
                            vt = VARENUM.VT_R4;
                            var r4 = (float)managed;
                            Buffer.MemoryCopy(&r4, typeData, remaining, Marshal.SizeOf<float>());
                            break;

                        case TypeCode.Double:
                            vt = VARENUM.VT_R8;
                            var r8 = (double)managed;
                            Buffer.MemoryCopy(&r8, typeData, remaining, Marshal.SizeOf<double>());
                            break;

                        case TypeCode.Boolean:
                            vt = VARENUM.VT_BOOL;
                            var b = (bool)managed ? -1 : 0;
                            Buffer.MemoryCopy(&b, typeData, remaining, Marshal.SizeOf<int>());
                            break;

                        case TypeCode.String:
                            vt = VARENUM.VT_BSTR;
                            var bstr = BStrStringMarshaller.ConvertToUnmanaged((string)managed);
                            Buffer.MemoryCopy(&bstr, typeData, remaining, IntPtr.Size);
                            break;

                        default:
                            if (managed is DBNull)
                            {
                                vt = VARENUM.VT_NULL;
                                break;
                            }
                            else if (ComWrappers.TryGetComInstance(managed, out var unk))
                            {
                                vt = VARENUM.VT_UNKNOWN;
                                Buffer.MemoryCopy(&unk, typeData, remaining, IntPtr.Size);
                                break;
                            }
                            else
                                throw new NotImplementedException($"Marshalling variants for objects of type {managed.GetType().Name} is not yet implemented.");
                    }
                }

                *(VARENUM*)buffer = vt;

                var value = *(VARIANT*)buffer;                    

                return value;
            }
            finally
            {
                if (buffer != IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        public static object ConvertToManaged(VARIANT unmanaged)
        {
            var pVariant = (void*)&unmanaged;

            var data = ((byte*)pVariant + 8);

            switch (unmanaged.vt)
            {
                case VARENUM.VT_EMPTY:
                    return null;

                case VARENUM.VT_NULL:
                    return DBNull.Value;

                case VARENUM.VT_UI1:
                    return *(byte*)data;

                case VARENUM.VT_UI2:
                    return *(ushort*)data;

                case VARENUM.VT_UI4:
                    return *(uint*)data;

                case VARENUM.VT_UI8:
                    return *(ulong*)data;

                case VARENUM.VT_I1:
                    return *(sbyte*)data;

                case VARENUM.VT_I2:
                    return *(short*)data;

                case VARENUM.VT_I4:
                    return *(int*)data;

                case VARENUM.VT_I8:
                    return *(long*)data;

                case VARENUM.VT_R4:
                    return *(float*)data;

                case VARENUM.VT_R8:
                    return *(double*)data;

                case VARENUM.VT_BOOL:
                    return *(int*)data != 0;

                case VARENUM.VT_BSTR:
                    return BStrStringMarshaller.ConvertToManaged(*(ushort**)data);

                case VARENUM.VT_UNKNOWN:
                    return DefaultMarshallingInstance.GetOrCreateObjectForComInstance(*(nint*)data, CreateObjectFlags.None);

                default:
                    throw new NotImplementedException($"Marshalling objects for variants of type {unmanaged.vt} is not yet implemented.");
            }
        }

        public static void Free(VARIANT unmanaged)
        {
            var pVariant = (void*)&unmanaged;

            var data = ((byte*)pVariant + 8);

            switch (unmanaged.vt)
            {
                case VARENUM.VT_BSTR:
                    BStrStringMarshaller.Free(*(ushort**)data);
                    break;

                case VARENUM.VT_UNKNOWN:
                    var ptr = *(nint*)data;

                    if (ptr != IntPtr.Zero)
                        Marshal.Release(ptr);
                    break;
            }
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
#else
    public static unsafe class CrossPlatformStringMarshaller
    {
        public static string ConvertToManaged(IntPtr unmanaged) =>
            Marshal.PtrToStringUni(unmanaged);

        public static IntPtr ConvertToUnmanaged(string managed) =>
            Marshal.StringToHGlobalUni(managed);

        public static void Free(IntPtr unmanaged) =>
            Marshal.FreeCoTaskMem(unmanaged);
    }
#endif
}
