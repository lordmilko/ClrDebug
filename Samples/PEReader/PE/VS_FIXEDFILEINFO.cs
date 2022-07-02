using System;
using System.Diagnostics;

namespace PEReader.PE
{
    [DebuggerDisplay("File = {FileVersion.ToString(),nq}, Product = {ProductVersion.ToString(),nq}")]
    public class VS_FIXEDFILEINFO
    {
        public const uint FixedFileInfoSignature = 0xFEEF04BD;

        public uint Signature;          // e.g. 0xfeef04bd
        public uint StrucVersion;       // e.g. 0x00000042 = "0.42"
        public ushort FileVersionMinor;
        public ushort FileVersionMajor;
        public ushort FileVersionRevision;
        public ushort FileVersionBuild;
        public ushort ProductVersionMinor;
        public ushort ProductVersionMajor;
        public ushort ProductVersionRevision;
        public ushort ProductVersionBuild;
        public uint FileFlagsMask;      // = 0x3F for version "0.42"
        public FileInfoFlags FileFlags;
        public uint FileOS;             // e.g. VOS_DOS_WINDOWS16
        public uint FileType;           // e.g. VFT_DRIVER
        public uint FileSubtype;        // e.g. VFT2_DRV_KEYBOARD
        public uint FileDateMS;         // e.g. 0
        public uint FileDateLS;         // e.g. 0

        public Version FileVersion => new Version(FileVersionMajor, FileVersionMinor, FileVersionBuild, FileVersionRevision);

        public Version ProductVersion => new Version(ProductVersionMajor, ProductVersionMinor, ProductVersionBuild, ProductVersionRevision);

        internal VS_FIXEDFILEINFO(PEBinaryReader reader)
        {
            Signature = reader.ReadUInt32();
            StrucVersion = reader.ReadUInt32();
            FileVersionMinor = reader.ReadUInt16();
            FileVersionMajor = reader.ReadUInt16();
            FileVersionRevision = reader.ReadUInt16();
            FileVersionBuild = reader.ReadUInt16();
            ProductVersionMinor = reader.ReadUInt16();
            ProductVersionMajor = reader.ReadUInt16();
            ProductVersionRevision = reader.ReadUInt16();
            ProductVersionBuild = reader.ReadUInt16();
            FileFlagsMask = reader.ReadUInt32();
            FileFlags = (FileInfoFlags) reader.ReadUInt32();
            FileOS = reader.ReadUInt32();
            FileType = reader.ReadUInt32();
            FileSubtype = reader.ReadUInt32();
            FileDateMS = reader.ReadUInt32();
            FileDateLS = reader.ReadUInt32();
        }
    }
}