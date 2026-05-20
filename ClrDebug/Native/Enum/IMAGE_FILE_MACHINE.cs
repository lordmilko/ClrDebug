namespace ClrDebug
{
    public enum IMAGE_FILE_MACHINE : uint
    {
        IMAGE_FILE_MACHINE_UNKNOWN = 0,
        IMAGE_FILE_MACHINE_TARGET_HOST = 1, //Useful for indicating we want to interact with the host and not a WoW guest

        IMAGE_FILE_MACHINE_I386 = 0x014c, // Intel 386
        IMAGE_FILE_MACHINE_R3000BE = 0x160, //MIPS I compatible 32-bit big endian
        IMAGE_FILE_MACHINE_R3000 = 0x0162, // MIPS little-endian, 0x160 big-endian
        IMAGE_FILE_MACHINE_R4000 = 0x0166, // MIPS little-endian
        IMAGE_FILE_MACHINE_R10000 = 0x0168, // MIPS little-endian
        IMAGE_FILE_MACHINE_WCEMIPSV2 = 0x0169, // MIPS little-endian WCE v2
        IMAGE_FILE_MACHINE_ALPHA = 0x0184, // Alpha_AXP
        IMAGE_FILE_MACHINE_SH3 = 0x01a2, // SH3 little-endian
        IMAGE_FILE_MACHINE_SH3DSP = 0x01a3,
        IMAGE_FILE_MACHINE_SH3E = 0x01a4, // SH3E little-endian
        IMAGE_FILE_MACHINE_SH4 = 0x01a6, // SH4 little-endian
        IMAGE_FILE_MACHINE_SH5 = 0x01a8, // SH5
        IMAGE_FILE_MACHINE_ARM = 0x01c0, // ARM Little-Endian
        IMAGE_FILE_MACHINE_THUMB = 0x01c2,
        IMAGE_FILE_MACHINE_ARMNT = 0x1c4,
        IMAGE_FILE_MACHINE_AM33 = 0x01d3,
        IMAGE_FILE_MACHINE_POWERPC = 0x01F0, // IBM PowerPC Little-Endian
        IMAGE_FILE_MACHINE_POWERPCFP = 0x01f1,
        IMAGE_FILE_MACHINE_IA64 = 0x0200, // Intel 64
        IMAGE_FILE_MACHINE_MIPS16 = 0x0266, // MIPS
        IMAGE_FILE_MACHINE_M68K = 0x0268, // Macintosh
        IMAGE_FILE_MACHINE_AXP64 = 0x0284,
        IMAGE_FILE_MACHINE_ALPHA64 = 0x0284, // ALPHA64
        IMAGE_FILE_MACHINE_MIPSFPU = 0x0366, // MIPS

        //msdia140!COptDbgLocalTrav::getScopeSymbolInfo references a machine type 0x3A64, which gets mapped to CV_CFL_HYBRID_X86_ARM64

        IMAGE_FILE_MACHINE_MIPSFPU16 = 0x0466, // MIPS

        IMAGE_FILE_MACHINE_TRICORE = 0x0520, // Infineon
        IMAGE_FILE_MACHINE_MPPC_601 = 0x601, // PowerPC 601
        IMAGE_FILE_MACHINE_CEF = 0x0CEF,
        IMAGE_FILE_MACHINE_EBC = 0x0EBC, // EFI Byte Code

        IMAGE_FILE_MACHINE_RISCV32 = 0x5032, //RISC-V 32-bit address space
        IMAGE_FILE_MACHINE_RISCV64 = 0x5064, //RISC-V 64-bit address space
        IMAGE_FILE_MACHINE_RISCV128 = 0x5128, //RISC-V 128-bit address space

        IMAGE_FILE_MACHINE_LOONGARCH32 = 0x6232, //LoongArch 32-bit processor family
        IMAGE_FILE_MACHINE_LOONGARCH64 = 0x6264, //LoongArch 64-bit processor family

        IMAGE_FILE_MACHINE_AMD64 = 0x8664, // AMD64 (K8)
        IMAGE_FILE_MACHINE_M32R = 0x9041, // M32R little-endian

        IMAGE_FILE_MACHINE_ARM64EC = 0xA641, //ABI that enables interoperability between native ARM64 and emulated x64 code
        IMAGE_FILE_MACHINE_ARM64X = 0xA64E, //Binary format that allows both native ARM64 and ARM64EC code to coexist in the same file

        IMAGE_FILE_MACHINE_ARM64 = 0xAA64,
        IMAGE_FILE_MACHINE_CEE = 0xC0EE,
    }
}
