namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugSymbolProvider.GetMethodProps"/> method.
    /// </summary>
    public struct GetMethodPropsResult
    {
        /// <summary>
        /// [out] A pointer to the method's metadata token.
        /// </summary>
        public int pMethodToken { get; }

        /// <summary>
        /// [out] A pointer to the number of generic parameters associated with this method.
        /// </summary>
        public int pcGenericParams { get; }

        /// <summary>
        /// [out] A pointer to the size of the returned signature array.
        /// </summary>
        public int pcbSignature { get; }

        /// <summary>
        /// [out] A buffer that holds the typespec signatures of all generic parameters.
        /// </summary>
        public byte[] signature { get; }

        public GetMethodPropsResult(int pMethodToken, int pcGenericParams, int pcbSignature, byte[] signature)
        {
            this.pMethodToken = pMethodToken;
            this.pcGenericParams = pcGenericParams;
            this.pcbSignature = pcbSignature;
            this.signature = signature;
        }
    }
}