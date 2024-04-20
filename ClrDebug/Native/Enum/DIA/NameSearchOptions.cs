using System;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Specifies the search options for symbol and file names.
    /// </summary>
    /// <remarks>
    /// The values from this enumeration are passed to the following methods:
    /// </remarks>
    [Flags]
    public enum NameSearchOptions
    {
        /// <summary>
        /// No options are specified.
        /// </summary>
        nsNone = 0,

        /// <summary>
        /// Applies a case-sensitive name match.
        /// </summary>
        nsfCaseSensitive = 0x1,

        //Applies a case-insensitive name match.
        nsfCaseInsensitive = 0x2,

        /// <summary>
        /// Treats names as paths and applies a filename.ext name match.
        /// </summary>
        nsfFNameExt = 0x4,

        /// <summary>
        /// Applies a case-sensitive name match using asterisks (*) and question marks (?) as wildcards.
        /// (Other common regular expression characters are not supported.)
        /// </summary>
        nsfRegularExpression = 0x8,

        /// <summary>
        /// Applies only to symbols that have both undecorated and decorated names.
        /// </summary>
        nsfUndecoratedName = 0x10,

        /// <summary>
        /// Provided for backward compatibility. Equivalent to <see cref="nsfCaseSensitive"/>.
        /// </summary>
        nsCaseSensitive = nsfCaseSensitive,

        /// <summary>
        /// Provided for backward compatibility. Equivalent to <see cref="nsfCaseInsensitive"/>.
        /// </summary>
        nsCaseInsensitive = nsfCaseInsensitive,

        nsFNameExt = nsfCaseInsensitive | nsfFNameExt,
        nsRegularExpression = nsfRegularExpression | nsfCaseSensitive,
        nsCaseInRegularExpression = nsfRegularExpression | nsfCaseInsensitive,
    }
}
