using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using SymStore;

namespace ClrDebug.Tests
{
    /// <summary>
    /// Retrieves PDBs from an online or local symbol store.
    /// </summary>
    internal class SymbolClient
    {
        private ITracer tracer;

        /// <summary>
        /// Gets the chain of symbol stores to search through to locate PDBs
        /// </summary>
        public SymbolStore StoreChain { get; }

        /// <summary>
        /// Gets the cache store at the beginning at the chain where any downloaded PDBs will be saved.<para/>
        /// Due to the fact symsrv.dll is implicitly unavailable (by virtue of the fact we're using our own symbol store in the first place),
        /// there MUST be a <see cref="CacheSymbolStore"/> at the beginning of the chain, else we won't be able to explicitly tell DbgHelp where to look
        /// in order to find symbols.
        /// </summary>
        public CacheSymbolStore CacheStore { get; }

        public SymbolClient()
        {
            tracer = new Tracer();

            StoreChain = BuildSymbolStore();
            CacheStore = GetCacheStore();
        }

        public string GetPdb(string modulePath)
        {
            using (var fileStream = File.Open(modulePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                //SymbolStoreFile is IDisposable, but all it does is dispose the filestream, which we're already disposing anyway
                var symbolStoreFile = new SymbolStoreFile(fileStream, modulePath);

                var keyGenerator = new PEFileKeyGenerator(tracer, symbolStoreFile);

                //These flags are the default flags that dotnet/symstore -> SymClient uses
                var flags =
                    KeyTypeFlags.IdentityKey | //Download the binary itself
                    KeyTypeFlags.SymbolKey |   //Download the symbols for the binary, if applicable
                    KeyTypeFlags.ClrKeys;      //Download the SOS/DAC of the module, if applicable. It's very important to use the right DAC for a given binary

                //Get the relative paths to each file we might download. e.g. kernel32.pdb/035E6BB05110717C09CA1EE13F816FE61/kernel32.pdb
                var keys = keyGenerator.GetKeys(flags).ToArray();

                var results = new List<string>();

                foreach (var key in keys)
                {
                    //In this sample we're synchronous, however in a real debugger while doing a stack trace you could potentially
                    //run special logic symbols for all modules you see in the stack simultaneously. You know when a module is present
                    //by looking up an address between the bounds of all modules you know about
                    var file = StoreChain.GetFile(key, CancellationToken.None).GetAwaiter().GetResult();

                    var result = GetCachedFile(key.Index);

                    if (result != null)
                        results.Add(result);
                }

                if (results.Count == 0)
                    return null;

                if (results.Count == 1)
                    return results[0];

                return GetBestResult(results);
            }
        }

        private SymbolStore BuildSymbolStore()
        {
            var ntSymbolPath = Environment.GetEnvironmentVariable("_NT_SYMBOL_PATH");

            SymbolStore store = null;

            if (ntSymbolPath != null)
            {
                var split = ntSymbolPath.Split(new[] { '*' }, StringSplitOptions.RemoveEmptyEntries);

                //Each store specifies the store that "backs" it; in the typical _NT_SYMBOL_PATH search pattern however,
                //entries towards the left are "preferred" over entries to the right. This is simply the opposite way of saying the same thing
                foreach (var entry in split.Reverse())
                {
                    if (StringComparer.OrdinalIgnoreCase.Equals("srv", entry))
                        continue;

                    if (entry.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || entry.StartsWith("https://", StringComparison.OrdinalIgnoreCase) || entry.StartsWith("ftp://", StringComparison.OrdinalIgnoreCase))
                    {
                        var str = entry;

                        //Due to how the Microsoft.SymbolStore package constructs URLs, if the URL does not end in a / this will cause
                        //the last component of the URL to be ommitted - e.g. http://msdl.microsoft.com/download/symbols would become
                        //http://msdl.microsoft.com/download
                        if (!str.EndsWith("/"))
                            str += "/";

                        store = new HttpSymbolStore(tracer, store, new Uri(str));
                    }
                    else
                    {
                        store = new CacheSymbolStore(tracer, store, entry);
                    }
                }
            }
            else
            {
                //We need to download the file somewhere, 
                store = new CacheSymbolStore(
                    tracer,
                    //As mentioned above, it's very important the URI has a trailing slash, or HttpSymbolStore will build the wrong URL to download the file
                    new HttpSymbolStore(tracer, null, new Uri("http://msdl.microsoft.com/download/symbols/")),
                    GetDefaultSymbolCache()
                );
            }

            return store;
        }

        private CacheSymbolStore GetCacheStore()
        {
            CacheSymbolStore cacheSymbolStore = null;

            var store = StoreChain;

            //Get the left most CacheSymbolStore, which will be used to save any files we need to download
            while (store != null)
            {
                if (store is CacheSymbolStore)
                    cacheSymbolStore = (CacheSymbolStore)store;

                store = store.BackingStore;
            }

            if (cacheSymbolStore != null)
                return cacheSymbolStore;

            throw new InvalidOperationException("Could not find a valid cache store");
        }

        private string GetCachedFile(string relativePath)
        {
            //Microsoft.SymbolStore will automatically cache any files downloaded into your CacheSymbolStore. It doesn't give us the path to said file however, so it's up to us
            //to retrieve it ourselves.
            var destinationFile = Path.GetFullPath(Path.Combine(CacheStore.CacheDirectory, relativePath));

            //The file _should_ have downloaded. Ignoring the situation where something terrible has gone wrong, another possible explanation
            //is its a local file with an embedded PDB path, in which case DbgHelp will be able to locate this via the PE file's metadata
            if (!File.Exists(destinationFile))
                return null;

            return destinationFile;
        }

        private string GetBestResult(List<string> results)
        {
            var pdbs = results.Where(r => Path.GetExtension(r).Equals(".pdb", StringComparison.OrdinalIgnoreCase)).ToArray();

            if (pdbs.Length == 1)
                return pdbs[0];

            //Just use the first one I guess?
            return pdbs.First();
        }

        private string GetDefaultSymbolCache()
        {
            var temp = Environment.GetEnvironmentVariable("temp");

            return Path.Combine(temp, "symbols");
        }
    }
}
