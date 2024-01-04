namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a module signature -- a definition which will match a set of modules by name and/or version.
    /// </summary>
    public class DebugHostModuleSignature : ComObject<IDebugHostModuleSignature>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostModuleSignature"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostModuleSignature(IDebugHostModuleSignature raw) : base(raw)
        {
        }

        #region IDebugHostModuleSignature
        #region IsMatch

        /// <summary>
        /// The IsMatch method compares a particular module (as given by an <see cref="IDebugHostModule"/> symbol) against a signature, comparing the module name and version to the name and version range indicated in the signature.<para/>
        /// An indication of whether the given module symbol matches the signature is returned.
        /// </summary>
        /// <param name="pModule">The module symbol to compare against the module signature.</param>
        /// <returns>An indication of whether the given module symbol matches the module signature is returned here.</returns>
        public bool IsMatch(IDebugHostModule pModule)
        {
            bool isMatch;
            TryIsMatch(pModule, out isMatch).ThrowDbgEngNotOK();

            return isMatch;
        }

        /// <summary>
        /// The IsMatch method compares a particular module (as given by an <see cref="IDebugHostModule"/> symbol) against a signature, comparing the module name and version to the name and version range indicated in the signature.<para/>
        /// An indication of whether the given module symbol matches the signature is returned.
        /// </summary>
        /// <param name="pModule">The module symbol to compare against the module signature.</param>
        /// <param name="isMatch">An indication of whether the given module symbol matches the module signature is returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryIsMatch(IDebugHostModule pModule, out bool isMatch)
        {
            /*HRESULT IsMatch(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostModule pModule,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isMatch);*/
            return Raw.IsMatch(pModule, out isMatch);
        }

        #endregion
        #endregion
    }
}
