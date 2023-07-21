using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.Tests
{

    [Guid("BB5760D0-1345-494E-A92D-D36E753693A3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    partial interface IVariantTest
    {
        #region Get

#if GENERATED_MARSHALLING
        [return: MarshalUsing(typeof(VariantMarshaller))]
#else
        [return: MarshalAs(UnmanagedType.Struct)]
#endif
        object GetEmpty();

#if GENERATED_MARSHALLING
        [return: MarshalUsing(typeof(VariantMarshaller))]
#else
        [return: MarshalAs(UnmanagedType.Struct)]
#endif
        object GetNull();

#if GENERATED_MARSHALLING
        [return: MarshalUsing(typeof(VariantMarshaller))]
#else
        [return: MarshalAs(UnmanagedType.Struct)]
#endif
        object GetU1();

#if GENERATED_MARSHALLING
        [return: MarshalUsing(typeof(VariantMarshaller))]
#else
        [return: MarshalAs(UnmanagedType.Struct)]
#endif
        object GetU2();

#if GENERATED_MARSHALLING
        [return: MarshalUsing(typeof(VariantMarshaller))]
#else
        [return: MarshalAs(UnmanagedType.Struct)]
#endif
        object GetU4();

#if GENERATED_MARSHALLING
        [return: MarshalUsing(typeof(VariantMarshaller))]
#else
        [return: MarshalAs(UnmanagedType.Struct)]
#endif
        object GetU8();

#if GENERATED_MARSHALLING
        [return: MarshalUsing(typeof(VariantMarshaller))]
#else
        [return: MarshalAs(UnmanagedType.Struct)]
#endif
        object GetI1();

#if GENERATED_MARSHALLING
        [return: MarshalUsing(typeof(VariantMarshaller))]
#else
        [return: MarshalAs(UnmanagedType.Struct)]
#endif
        object GetI2();

#if GENERATED_MARSHALLING
        [return: MarshalUsing(typeof(VariantMarshaller))]
#else
        [return: MarshalAs(UnmanagedType.Struct)]
#endif
        object GetI4();

#if GENERATED_MARSHALLING
        [return: MarshalUsing(typeof(VariantMarshaller))]
#else
        [return: MarshalAs(UnmanagedType.Struct)]
#endif
        object GetI8();

#if GENERATED_MARSHALLING
        [return: MarshalUsing(typeof(VariantMarshaller))]
#else
        [return: MarshalAs(UnmanagedType.Struct)]
#endif
        object GetBStr();

#if GENERATED_MARSHALLING
        [return: MarshalUsing(typeof(VariantMarshaller))]
#else
        [return: MarshalAs(UnmanagedType.Struct)]
#endif
        object GetBool();

#if GENERATED_MARSHALLING
        [return: MarshalUsing(typeof(VariantMarshaller))]
#else
        [return: MarshalAs(UnmanagedType.Struct)]
#endif
        object GetUnknown();

        //#if GENERATED_MARSHALLING
        //        [return: MarshalUsing(typeof(VariantMarshaller))]
        //#else
        //        [return: MarshalAs(UnmanagedType.Struct)]
        //#endif
        //object GetVoid();

#if GENERATED_MARSHALLING
        [return: MarshalUsing(typeof(VariantMarshaller))]
#else
        [return: MarshalAs(UnmanagedType.Struct)]
#endif
        object GetFloat();

#if GENERATED_MARSHALLING
        [return: MarshalUsing(typeof(VariantMarshaller))]
#else
        [return: MarshalAs(UnmanagedType.Struct)]
#endif
        object GetDouble();

        #endregion
        #region Set

        [PreserveSig]
        HRESULT SetEmpty(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);

        [PreserveSig]
        HRESULT SetNull(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);

        [PreserveSig]
        HRESULT SetU1(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);

        [PreserveSig]
        HRESULT SetU2(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);

        [PreserveSig]
        HRESULT SetU4(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);

        [PreserveSig]
        HRESULT SetU8(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);

        [PreserveSig]
        HRESULT SetI1(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);

        [PreserveSig]
        HRESULT SetI2(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);

        [PreserveSig]
        HRESULT SetI4(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);

        [PreserveSig]
        HRESULT SetI8(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);

        [PreserveSig]
        HRESULT SetBStr(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);

        [PreserveSig]
        HRESULT SetBool(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);

        [PreserveSig]
        HRESULT SetUnknown(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);

        /*[PreserveSig]
        HRESULT SetVoid(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);*/

        [PreserveSig]
        HRESULT SetFloat(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);

        [PreserveSig]
        HRESULT SetDouble(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object v);

        #endregion
    }
}
