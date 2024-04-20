namespace ClrDebug.DIA
{
    /// <summary>
    /// Specifies the scope of visibility (access level) of member functions and variables.
    /// </summary>
    /// <remarks>
    /// The friend access specifier is not included here because it is typically used by non-member functions that have
    /// access to both private and protected elements of the class. Use the <see cref="IDiaSymbol.get_symTag"/> method
    /// to find symbols with SymTagFriend access.
    /// </remarks>
    public enum CV_access_e
    {
        /// <summary>
        /// Member has private access.
        /// </summary>
        CV_private = 1,

        /// <summary>
        /// Member has protected access.
        /// </summary>
        CV_protected = 2,

        /// <summary>
        /// Member has public access.
        /// </summary>
        CV_public = 3,
    }
}
