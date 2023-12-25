namespace ClrDebug.DIA
{
    public static partial class DiaExtensions
    {
        /// <summary>
        /// Retrieves corresponding string names for given property identifiers.
        /// </summary>
        /// <param name="diaPropertyStorage">The <see cref="DiaPropertyStorage"/> to use to retrieve property names.</param>
        /// <param name="rgpropid">Array of property ids for which to get the names (PROPID is defined in WTypes.h as a ULONG).</param>
        /// <returns>Array of property names for the specified property ids.</returns>
        public static string[] ReadPropertyNames(
            this DiaPropertyStorage diaPropertyStorage,
            params int[] rgpropid)
        {
            string[] rglpwstrName;
            diaPropertyStorage.TryReadPropertyNames(rgpropid, out rglpwstrName).ThrowOnNotOK();
            return rglpwstrName;
        }

        /// <summary>
        /// Tries to retrieve corresponding string names for given property identifiers.
        /// </summary>
        /// <param name="diaPropertyStorage">The <see cref="DiaPropertyStorage"/> to use to retrieve property names.</param>
        /// <param name="rgpropid">Array of property ids for which to get the names (PROPID is defined in WTypes.h as a ULONG).</param>
        /// <param name="rglpwstrName">Array of property names for the specified property ids.</param>
        /// <returns>If successful, returns S_OK; otherwise returns an error code.</returns>
        public static HRESULT TryReadPropertyNames(
            this DiaPropertyStorage diaPropertyStorage,
            int[] rgpropid,
            out string[] rglpwstrName)
        {
            return diaPropertyStorage.TryReadPropertyNames(rgpropid.Length, rgpropid, out rglpwstrName);
        }
    }
}
