using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SymStore
{
    /// <summary>
    /// The base class for all the key generators. They can be for individual files
    /// or a group of file types.
    /// </summary>
    public abstract class KeyGenerator
    {
        /// <summary>
        /// Trace/logging source
        /// </summary>
        protected readonly ITracer Tracer;

        /// <summary>
        /// Key generator base class.
        /// </summary>
        /// <param name="tracer">logging</param>
        protected KeyGenerator(ITracer tracer)
        {
            Tracer = tracer;
        }

        /// <summary>
        /// Returns true if the key generator can get keys for this file or binary.
        /// </summary>
        public abstract bool IsValid();

        /// <summary>
        /// Returns true if file is a mini or core dump.
        /// </summary>
        public virtual bool IsDump()
        {
            return false;
        }

        /// <summary>
        /// Returns the symbol store keys for this file or binary.
        /// </summary>
        /// <param name="flags">what keys to get</param>
        public abstract IEnumerable<SymbolStoreKey> GetKeys(KeyTypeFlags flags);

        /// <summary>
        /// Key building helper for "file_name/string_id/file_name" formats.
        /// </summary>
        /// <param name="path">full path of file or binary</param>
        /// <param name="id">id string</param>
        /// <param name="clrSpecialFile">if true, the file is one the clr special files</param>
        /// <returns>key</returns>
        protected static SymbolStoreKey BuildKey(string path, string id, bool clrSpecialFile = false)
        {
            string file = GetFileName(path).ToLowerInvariant();
            return BuildKey(path, null, id, file, clrSpecialFile);
        }

        /// <summary>
        /// Key building helper for "prefix/string_id/file_name" formats.
        /// </summary>
        /// <param name="path">full path of file or binary</param>
        /// <param name="prefix">optional id prefix</param>
        /// <param name="id">build id or uuid</param>
        /// <param name="clrSpecialFile">if true, the file is one the clr special files</param>
        /// <returns>key</returns>
        protected static SymbolStoreKey BuildKey(string path, string prefix, byte[] id, bool clrSpecialFile = false)
        {
            string file = GetFileName(path).ToLowerInvariant();
            return BuildKey(path, prefix, id, file, clrSpecialFile);
        }

        /// <summary>
        /// Key building helper for "prefix/byte_sequence_id/file_name" formats.
        /// </summary>
        /// <param name="path">full path of file or binary</param>
        /// <param name="prefix">optional id prefix</param>
        /// <param name="id">build id or uuid</param>
        /// <param name="file">file name only</param>
        /// <param name="clrSpecialFile">if true, the file is one the clr special files</param>
        /// <returns>key</returns>
        protected static SymbolStoreKey BuildKey(string path, string prefix, byte[] id, string file, bool clrSpecialFile = false)
        {
            return BuildKey(path, prefix, ToHexString(id), file, clrSpecialFile);
        }

        /// <summary>
        /// Key building helper for "prefix/byte_sequence_id/file_name" formats.
        /// </summary>
        /// <param name="path">full path of file or binary</param>
        /// <param name="prefix">optional id prefix</param>
        /// <param name="id">build id or uuid</param>
        /// <param name="file">file name only</param>
        /// <param name="clrSpecialFile">if true, the file is one the clr special files</param>
        /// <returns>key</returns>
        protected static SymbolStoreKey BuildKey(string path, string prefix, string id, string file, bool clrSpecialFile = false)
        {
            var key = new StringBuilder();
            key.Append(file);
            key.Append("/");
            if (prefix != null)
            {
                key.Append(prefix);
                key.Append("-");
            }
            key.Append(id);
            key.Append("/");
            key.Append(file);
            return new SymbolStoreKey(key.ToString(), path, clrSpecialFile);
        }

        /// <summary>
        /// Convert an array of bytes to a lower case hex string.
        /// </summary>
        /// <param name="bytes">array of bytes</param>
        /// <returns>hex string</returns>
        public static string ToHexString(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            return string.Concat(bytes.Select(b => b.ToString("x2")));
        }

        /// <summary>
        /// The back slashes are changed to forward slashes because Path.GetFileName doesn't work 
        /// on Linux /MacOS if there are backslashes. Both back and forward slashes work on Windows.
        /// </summary>
        /// <param name="path">possible windows path</param>
        /// <returns>just the file name</returns>
        internal static string GetFileName(string path)
        {
            return Path.GetFileName(path.Replace('\\', '/'));
        }
    }
}
