// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the License.txt file in the project root for more information.

using System;

namespace ClrDebug
{
    /// <summary>
    /// Specifies the policy to be used when doing a search for a symbol reader. These constants are used by the <see cref="ISymUnmanagedBinder2.GetReaderForFile2"/> and <see cref="ISymUnmanagedBinder3.GetReaderFromCallback"/> methods.
    /// </summary>
    [Flags]
    public enum CorSymSearchPolicyAttributes
    {
        /// <summary>
        /// Queries the registry for symbol search paths.
        /// </summary>
        AllowRegistryAccess = 0x1,

        /// <summary>
        /// Accesses a symbol server.
        /// </summary>
        AllowSymbolServerAccess = 0x2,

        /// <summary>
        /// Searches the path specified in the Debug directory.
        /// </summary>
        AllowOriginalPathAccess = 0x4,

        /// <summary>
        /// Searches for the PDB in the place where the .exe file is.
        /// </summary>
        AllowReferencePathAccess = 0x8
    }
}
