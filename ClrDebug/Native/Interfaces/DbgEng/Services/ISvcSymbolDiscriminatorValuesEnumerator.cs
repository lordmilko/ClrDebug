using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("80450742-C0A5-4160-8430-90B2212E132C")]
    [ComImport]
    public interface ISvcSymbolDiscriminatorValuesEnumerator
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
            [Out, MarshalAs(UnmanagedType.Struct)] out object pLowValue,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pHighValue);
    }
}
