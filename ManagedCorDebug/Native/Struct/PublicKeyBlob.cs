namespace ManagedCorDebug
{
    /// <summary>
    /// Represents, in binary format, the public key of a public/private key pair.
    /// </summary>
    /// <remarks>
    /// The PublicKeyBlob structure is used by StrongNameGetPublicKey, StrongNameSignatureGeneration, and other strong
    /// name functions to represent the public key of a public/private key pair.
    /// </remarks>
    public unsafe struct PublicKeyBlob
    {
        /// <summary>
        /// The identifier for the signature algorithm (of type ALG_ID, as defined in WinCrypt.h) of the public key.
        /// </summary>
        public uint SigAlgId;

        /// <summary>
        /// The identifier for the hash algorithm (of type ALG_ID, as defined in WinCrypt.h) of the public key.
        /// </summary>
        public uint HashAlgId;

        /// <summary>
        /// The length of the key in bytes.
        /// </summary>
        public uint cbPublicKey;

        /// <summary>
        /// A variable-length byte array that contains the key value in the format returned by the CryptoAPI.
        /// </summary>
        public fixed char PublicKey[1];
    }
}