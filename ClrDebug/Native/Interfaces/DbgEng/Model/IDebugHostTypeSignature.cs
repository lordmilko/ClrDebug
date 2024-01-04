using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a type signature against which type instances can be matched. A definition which will match a set of types by module and/or name.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3AADC353-2B14-4ABB-9893-5E03458E07EE")]
    [ComImport]
    public interface IDebugHostTypeSignature
    {
        /// <summary>
        /// The GetHashCode method returns a 32-bit hash code for the type signature. The debug host guarantees that there is synchronization in implementation between the hash code returned for type instances and the hash code returned for type signatures.<para/>
        /// With the exception of a global match, if a type instance is capable of matching a type signature, both will have the same 32-bit hash code.<para/>
        /// This allows an initial rapid comparison and match between a type instance and a plethora of type signatures registered with the data model manager.
        /// </summary>
        /// <param name="hashCode">A 32-bit hash code for the type signature is returned here. With the exception of a global match type signature, this hash code will be identical to the hash code of any type instance capable of matching this type signature.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetHashCode(
            [Out] out int hashCode);

        /// <summary>
        /// The IsMatch method returns an indication of whether a particular type instance matches the criteria specified in the type signature.<para/>
        /// If it does, an indication of this is returned as well as an enumerator which will indicate all of the specific portions of the type instance (as symbols) which matched wildcards in the type signature.
        /// </summary>
        /// <param name="type">The type instance to compare against the type signature.</param>
        /// <param name="isMatch">An indication of whether the type instance matches the type signature is returned here.</param>
        /// <param name="wildcardMatches">If the type instance matches the type signature, an enumerator will be returned here which will enumerate all the specific portions of the type instance (as symbols) which matched wildcards in the type signature.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT IsMatch(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType type,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isMatch,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator wildcardMatches);

        /// <summary>
        /// The CompareAgainst method compares the type signature to another type signature and returns how the two signatures compare.<para/>
        /// The comparison result which is returned is a member of the SignatureComparison enumeration which is defined as follows: Unrelated	- There is no relationship between the two signatures or types being compared.<para/>
        /// Ambiguous - One signature or type compares ambiguously against the other. For two type signatures, this means that there are potential type instances which could match either signature equally well.<para/>
        /// As an example, the two type signatures shown below are ambiguous: Signature 1: Signature 2: Because the type instance std::pair&lt;int, int&gt; matches either one equally well (both have one concrete and one wildcard match).<para/>
        /// LessSpecific - One signature or type is less specific than the other. Often, this means that the less specific signature has a wildcard where the more specific one has a concrete type.<para/>
        /// As an example, the first signature below is less specific than the second: Signature 1: Signature 2: Because it has a wildcard (the *) where the second has a concrete type (int).<para/>
        /// MoreSpecific - One signature or type is more specific than the other. Often, this means that the more specific signature has a concrete type where the less specific one has a wildcard.<para/>
        /// As an example, the first signature below is more specific than the second: Signature 1: Signature 2: Because it has a concrete type (int) where the second has a wildcard (the *).<para/>
        /// Identical - The two signatures or types are identical.
        /// </summary>
        /// <param name="typeSignature">The type signature to compare against.</param>
        /// <param name="result">An indication of the relationship between the two signatures is returned here -- whether they are unrelated or identical, one is more or less specific than the other, or they are ambiguous.<para/>
        /// Such relationship is given by a member of the SignatureComparison enumeration.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT CompareAgainst(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature,
            [Out] out SignatureComparison result);
    }
}
