using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any symbol which represents a variant part of a data structure (whether the discriminator or a discriminant) should implement ISvcSymbolVariantInfo.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B886A5F0-96CA-4086-B7EB-24458283C4C1")]
    [ComImport]
    public interface ISvcSymbolVariantInfo
    {
        /// <summary>
        /// Indicates whether this *TYPE* has variant members or is a variant record.
        /// </summary>
        [PreserveSig]
        HRESULT HasVariantMembers(
            [Out, MarshalAs(UnmanagedType.U1)] out bool pHasVariantMembers);

        /// <summary>
        /// Indicates whether this member/field is a discriminator for a variant record.
        /// </summary>
        [PreserveSig]
        HRESULT IsDiscriminator(
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsDiscriminator);

        /// <summary>
        /// Indicates whether this member/field is conditional based on the value of the discriminator. This can also optionally return the discriminator symbol.
        /// </summary>
        [PreserveSig]
        HRESULT IsDiscriminated(
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsDiscriminated,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol ppDiscriminator);

        /// <summary>
        /// Indicates the set of discriminator values for which this field/member is valid. This can return one of several things - Two variants that are both empty: The discriminator is a default discriminator (used if no other discriminator matches) - One variant (pLowRange) and one empty variant: The discriminator is a single value "pLowRange" - Two variants of identical type: The discriminator values are a range [pLowRange, pHighRange) Either of the above with a return value of S_FALSE: The set of discriminator values is disjoint and cannot be expressed by a single range.<para/>
        /// In this case, you must call EnumerateDiscriminatorValues to get a full accounting of discriminator values for which this field/member is valid.
        /// </summary>
        [PreserveSig]
        HRESULT GetDiscriminatorValues(
            [Out, MarshalAs(UnmanagedType.Struct)] out object pLowRange,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pHighRange);

        /// <summary>
        /// Enumerates all discriminator values for which this field/member is valid. While this function always works, it only NEEDS to be used if GetDiscriminatorValues returns S_FALSE as an indication that there are disjoint values.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateDiscriminatorValues(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolDiscriminatorValuesEnumerator ppEnum);
    }
}
