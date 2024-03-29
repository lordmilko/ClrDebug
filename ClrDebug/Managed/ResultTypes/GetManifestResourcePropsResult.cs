﻿using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataAssemblyImport.GetManifestResourceProps"/> method.
    /// </summary>
    [DebuggerDisplay("szName = {szName}, ptkImplementation = {ptkImplementation.ToString(),nq}, pdwOffset = {pdwOffset}, pdwResourceFlags = {pdwResourceFlags.ToString(),nq}")]
    public struct GetManifestResourcePropsResult
    {
        /// <summary>
        /// The name of the resource.
        /// </summary>
        public string szName { get; }

        /// <summary>
        /// A pointer to an <see cref="mdFile"/> token or an <see cref="mdAssemblyRef"/> token that represents the file or assembly, respectively, that contains the resource.
        /// </summary>
        public mdToken ptkImplementation { get; }

        /// <summary>
        /// A pointer to a value that specifies the offset to the beginning of the resource within the file.
        /// </summary>
        public int pdwOffset { get; }

        /// <summary>
        /// A pointer to flags that describe the metadata applied to a resource. The flags value is a combination of one or more <see cref="CorManifestResourceFlags"/> values.
        /// </summary>
        public CorManifestResourceFlags pdwResourceFlags { get; }

        public GetManifestResourcePropsResult(string szName, mdToken ptkImplementation, int pdwOffset, CorManifestResourceFlags pdwResourceFlags)
        {
            this.szName = szName;
            this.ptkImplementation = ptkImplementation;
            this.pdwOffset = pdwOffset;
            this.pdwResourceFlags = pdwResourceFlags;
        }
    }
}
