using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("80450742-C0A5-4160-8430-90B2212E132C")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcSymbolDiscriminatorValuesEnumerator
    {
        /// <summary>
        /// Resets the enumerator.
        /// </summary>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Gets the next range of discriminator values in the enumerator. Note that this has identical semantics to ISvcSymbolVariantInfo::GetDescriminatorValues in terms of pLowValue and pHighValue.
        /// </summary>
        [PreserveSig]
        HRESULT GetNext(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#endif
            [Out] out object pLowValue,
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#endif
            [Out] out object pHighValue);
    }
}
