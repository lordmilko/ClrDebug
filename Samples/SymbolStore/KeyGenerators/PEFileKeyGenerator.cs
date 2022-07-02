using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using PEReader.PE;
using ManagedCorDebug;

namespace SymStore
{
    public class PEFileKeyGenerator : KeyGenerator
    {
        private const string CoreClrFileName = "coreclr.dll";

        private static readonly HashSet<string> s_longNameBinaryPrefixes = new HashSet<string>(new string[] { "mscordaccore_", "sos_" });
        private static readonly HashSet<string> s_daclongNameBinaryPrefixes = new HashSet<string>(new string[] { "mscordaccore_" });

        private static readonly string[] s_specialFiles = new string[] { "mscordaccore.dll", "mscordbi.dll" };
        private static readonly string[] s_sosSpecialFiles = new string[] { "sos.dll", "SOS.NETCore.dll" };

        private static readonly HashSet<string> s_coreClrSpecialFiles = new HashSet<string>(s_specialFiles.Concat(s_sosSpecialFiles));
        private static readonly HashSet<string> s_dacdbiSpecialFiles = new HashSet<string>(s_specialFiles);

        private readonly PEFile _peFile;
        private readonly string _path;

        public PEFileKeyGenerator(ITracer tracer, PEFile peFile, string path)
            : base(tracer)
        {
            _peFile = peFile;
            _path = path;
        }

        public PEFileKeyGenerator(ITracer tracer, SymbolStoreFile file) : this(tracer, new PEFile(file.Stream, false), file.FileName)
        {
        }

        public override bool IsValid() => true;

        public override IEnumerable<SymbolStoreKey> GetKeys(KeyTypeFlags flags)
        {
            if (IsValid())
            {
                if ((flags & KeyTypeFlags.IdentityKey) != 0)
                {
                    yield return GetKey(_path, _peFile.FileHeader.TimeDateStamp, _peFile.OptionalHeader.SizeOfImage);
                }
                if ((flags & KeyTypeFlags.RuntimeKeys) != 0 && GetFileName(_path) == CoreClrFileName)
                {
                    yield return GetKey(_path, _peFile.FileHeader.TimeDateStamp, _peFile.OptionalHeader.SizeOfImage);
                }
                if ((flags & KeyTypeFlags.SymbolKey) != 0)
                {
                    var pdbs = _peFile.DebugDirectoryInfo.CodeViews;

                    foreach (var pdb in pdbs)
                    {
                        yield return GetPDBKey(pdb.Path, pdb.Signature, pdb.Age);
                    }
                }

                if ((flags & (KeyTypeFlags.ClrKeys | KeyTypeFlags.DacDbiKeys)) != 0)
                {
                    if (GetFileName(_path) == CoreClrFileName)
                    {
                        string coreclrId = string.Format("{0:X8}{1:x}", _peFile.FileHeader.TimeDateStamp, _peFile.OptionalHeader.SizeOfImage);
                        foreach (string specialFileName in GetSpecialFiles(flags))
                        {
                            yield return BuildKey(specialFileName, coreclrId);
                        }
                    }
                }
            }
        }

        private IEnumerable<string> GetSpecialFiles(KeyTypeFlags flags)
        {
            var specialFiles = new List<string>((flags & KeyTypeFlags.ClrKeys) != 0 ? s_coreClrSpecialFiles : s_dacdbiSpecialFiles);

            var fileVersion = _peFile.ResourceDirectoryInfo.Version?.Value;
            if (fileVersion != null)
            {
                ushort major = fileVersion.ProductVersionMajor;
                ushort minor = fileVersion.ProductVersionMinor;
                ushort build = fileVersion.ProductVersionBuild;
                ushort revision = fileVersion.ProductVersionRevision;

                var hostArchitectures = new List<string>();
                string targetArchitecture = null;

                var machine = _peFile.FileHeader.Machine;
                switch (machine)
                {
                    case IMAGE_FILE_MACHINE.AMD64:
                        targetArchitecture = "amd64";
                        break;

                    case IMAGE_FILE_MACHINE.I386:
                        targetArchitecture = "x86";
                        break;

                    case IMAGE_FILE_MACHINE.ARMNT:
                        targetArchitecture = "arm";
                        hostArchitectures.Add("x86");
                        break;

                    case IMAGE_FILE_MACHINE.ARM64:
                        targetArchitecture = "arm64";
                        hostArchitectures.Add("amd64");
                        break;
                }

                if (targetArchitecture != null)
                {
                    hostArchitectures.Add(targetArchitecture);

                    foreach (string hostArchitecture in hostArchitectures)
                    {
                        string buildFlavor = "";

                        if ((fileVersion.FileFlags & FileInfoFlags.Debug) != 0)
                        {
                            if ((fileVersion.FileFlags & FileInfoFlags.SpecialBuild) != 0)
                            {
                                buildFlavor = ".dbg";
                            }
                            else
                            {
                                buildFlavor = ".chk";
                            }
                        }

                        foreach (string name in (flags & KeyTypeFlags.ClrKeys) != 0 ? s_longNameBinaryPrefixes : s_daclongNameBinaryPrefixes)
                        {
                            // The name prefixes include the trailing "_".
                            string longName = string.Format("{0}{1}_{2}_{3}.{4}.{5}.{6:00}{7}.dll",
                                name, hostArchitecture, targetArchitecture, major, minor, build, revision, buildFlavor);
                            specialFiles.Add(longName);
                        }
                    }
                }
            }
            else
            {
                Tracer.Warning("{0} has no version resource", _path);
            }

            return specialFiles;
        }

        /// <summary>
        /// Create a symbol store key for a Windows PDB.
        /// </summary>
        /// <param name="path">file name and path</param>
        /// <param name="signature">mvid guid</param>
        /// <param name="age">pdb age</param>
        /// <returns>symbol store key</returns>
        public static SymbolStoreKey GetPDBKey(string path, Guid signature, int age)
        {
            Debug.Assert(path != null);
            Debug.Assert(signature != null);
            return BuildKey(path, string.Format("{0}{1:x}", signature.ToString("N"), age));
        }

        /// <summary>
        /// Creates a PE file symbol store key identity key.
        /// </summary>
        /// <param name="path">file name and path</param>
        /// <param name="timestamp">time stamp of pe image</param>
        /// <param name="sizeOfImage">size of pe image</param>
        /// <returns>symbol store keys (or empty enumeration)</returns>
        public static SymbolStoreKey GetKey(string path, int timestamp, int sizeOfImage)
        {
            Debug.Assert(path != null);

            // The clr special file flag can not be based on the GetSpecialFiles() list because 
            // that is only valid when "path" is the coreclr.dll.
            string fileName = GetFileName(path);
            bool clrSpecialFile = s_coreClrSpecialFiles.Contains(fileName) ||
                                  (s_longNameBinaryPrefixes.Any((prefix) => fileName.StartsWith(prefix)) && Path.GetExtension(fileName) == ".dll");

            string id = string.Format("{0:X8}{1:x}", timestamp, sizeOfImage);
            return BuildKey(path, id, clrSpecialFile);
        }
    }
}