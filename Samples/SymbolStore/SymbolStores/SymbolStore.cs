using System;
using System.Threading;
using System.Threading.Tasks;

namespace SymStore
{
    public abstract class SymbolStore : IDisposable
    {
        /// <summary>
        /// Next symbol store to chain if this store refuses the request
        /// </summary>
        public SymbolStore BackingStore { get; }

        /// <summary>
        /// Trace/logging source
        /// </summary>
        protected readonly ITracer Tracer;

        protected SymbolStore(ITracer tracer)
        {
            if (tracer == null)
                throw new ArgumentNullException(nameof(tracer));

            Tracer = tracer;
        }

        protected SymbolStore(ITracer tracer, SymbolStore backingStore) : this(tracer)
        {
            BackingStore = backingStore;
        }

        /// <summary>
        /// Downloads the file or retrieves it from a cache from the symbol store chain.
        /// </summary>
        /// <param name="key">symbol index to retrieve</param>
        /// <param name="token">to cancel requests</param>
        /// <returns>file or null if not found</returns>
        public async Task<SymbolStoreFile> GetFile(SymbolStoreKey key, CancellationToken token)
        {
            SymbolStoreFile file = await GetFileInner(key, token).ConfigureAwait(false);
            if (file == null)
            {
                if (BackingStore != null)
                {
                    file = await BackingStore.GetFile(key, token).ConfigureAwait(false);
                    if (file != null)
                    {
                        await WriteFileInner(key, file).ConfigureAwait(false);
                    }
                }
            }
            if (file != null)
            {
                // Reset stream to the beginning because the stream may have
                // been read or written by the symbol store implementation.
                file.Stream.Position = 0;
            }
            return file;
        }

        protected virtual Task<SymbolStoreFile> GetFileInner(SymbolStoreKey key, CancellationToken token)
        {
            return Task.FromResult<SymbolStoreFile>(null);
        }

        protected virtual Task WriteFileInner(SymbolStoreKey key, SymbolStoreFile file)
        {
            return Task.FromResult(0);
        }

        public virtual void Dispose()
        {
            if (BackingStore != null)
            {
                BackingStore.Dispose();
            }
        }

        /// <summary>
        /// Compares two file paths using OS specific casing.
        /// </summary>
        internal static bool IsPathEqual(string path1, string path2)
        {
/*#if !NET45
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return string.Equals(path1, path2);
            }
#endif*/
            return StringComparer.OrdinalIgnoreCase.Equals(path1, path2);
        }

        internal static int HashPath(string path)
        {
/*#if !NET45
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return path.GetHashCode();
            }
#endif*/
            return StringComparer.OrdinalIgnoreCase.GetHashCode(path);
        }
    }
}