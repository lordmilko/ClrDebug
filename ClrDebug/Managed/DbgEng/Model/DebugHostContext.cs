using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a context of the debugger answers questions about (what session, process, thread).
    /// </summary>
    public class DebugHostContext : ComObject<IDebugHostContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostContext"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostContext(IDebugHostContext raw) : base(raw)
        {
        }

        #region IDebugHostContext
        #region IsEqualTo

        /// <summary>
        /// Returns whether two <see cref="IDebugHostContext"/> objects are equal by value. Note that there is no requirement for a debug host to have interface pointer equality for two contexts which are equivalent.<para/>
        /// The actual contexts can be compared through this method.
        /// </summary>
        /// <param name="pContext">The host context to compare against.</param>
        /// <returns>An indication of whether the values of the two objects are equal.</returns>
        public bool IsEqualTo(IDebugHostContext pContext)
        {
            bool pIsEqual;
            TryIsEqualTo(pContext, out pIsEqual).ThrowDbgEngNotOK();

            return pIsEqual;
        }

        /// <summary>
        /// Returns whether two <see cref="IDebugHostContext"/> objects are equal by value. Note that there is no requirement for a debug host to have interface pointer equality for two contexts which are equivalent.<para/>
        /// The actual contexts can be compared through this method.
        /// </summary>
        /// <param name="pContext">The host context to compare against.</param>
        /// <param name="pIsEqual">An indication of whether the values of the two objects are equal.</param>
        /// <returns>This method returns HRESULT.</returns>
        public HRESULT TryIsEqualTo(IDebugHostContext pContext, out bool pIsEqual)
        {
            /*HRESULT IsEqualTo(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext pContext,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsEqual);*/
            return Raw.IsEqualTo(pContext, out pIsEqual);
        }

        #endregion
        #endregion
        #region IDebugHostContext2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostContext2 Raw2 => (IDebugHostContext2) Raw;

        #region GetAddressSpaceRelation

        public AddressSpaceRelation GetAddressSpaceRelation(IDebugHostContext2 pContext)
        {
            AddressSpaceRelation pAddressSpaceRelation;
            TryGetAddressSpaceRelation(pContext, out pAddressSpaceRelation).ThrowDbgEngNotOK();

            return pAddressSpaceRelation;
        }

        public HRESULT TryGetAddressSpaceRelation(IDebugHostContext2 pContext, out AddressSpaceRelation pAddressSpaceRelation)
        {
            /*HRESULT GetAddressSpaceRelation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext2 pContext,
            [Out] out AddressSpaceRelation pAddressSpaceRelation);*/
            return Raw2.GetAddressSpaceRelation(pContext, out pAddressSpaceRelation);
        }

        #endregion
        #endregion
    }
}
