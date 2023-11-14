namespace ClrDebug.DIA
{
    /// <summary>
    /// Specifies the scope of visibility (access level) of member functions and variables.
    /// </summary>
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
