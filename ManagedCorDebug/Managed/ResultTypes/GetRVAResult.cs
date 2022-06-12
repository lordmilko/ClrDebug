namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetRVA"/> method.
    /// </summary>
    public struct GetRVAResult
    {
        /// <summary>
        /// [out] A pointer to the relative virtual address of the code object represented by the token.
        /// </summary>
        public int pulCodeRVA { get; }

        /// <summary>
        /// [out] A pointer to the implementation flags for the method. This value is a bitmask from the <see cref="CorMethodImpl"/> enumeration.<para/>
        /// The value of pdwImplFlags is valid only if tk is a MethodDef token.
        /// </summary>
        public CorMethodImpl pdwImplFlags { get; }

        public GetRVAResult(int pulCodeRVA, CorMethodImpl pdwImplFlags)
        {
            this.pulCodeRVA = pulCodeRVA;
            this.pdwImplFlags = pdwImplFlags;
        }
    }
}