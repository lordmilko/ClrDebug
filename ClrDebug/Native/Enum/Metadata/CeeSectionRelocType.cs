namespace ClrDebug
{
    /// <summary>
    /// Provides values to influence the type of reloc instruction emitted in a call to <see cref="ICeeGen.AddSectionReloc"/>.
    /// </summary>
    public enum CeeSectionRelocType
    {
        /// <summary>
        /// Generates only a section-relative reloc, sending nothing into a .reloc section.
        /// </summary>
        srRelocAbsolute,

        /// <summary>
        /// Generates a reloc for a pointer-sized location. This is transformed into BASED_HIGHLOW or BASED_DIR64 depending on the platform.
        /// </summary>
        srRelocHighLow = 3,

        /// <summary>
        /// Generates a reloc for the top 16 bits of a 32-bit number, where the bottom 16 bits are included in the next word in the .reloc table.
        /// </summary>
        srRelocHighAdj,     // Never Used

        /// <summary>
        /// Generates a token map relocation, sending nothing into a .reloc section.
        /// </summary>
        srRelocMapToken,

        /// <summary>
        /// Indicates that the value is a relative address fixup.
        /// </summary>
        srRelocRelative,

        /// <summary>
        /// Generates only a section-relative reloc, sending nothing into a .reloc section. This reloc is relative to the file position of the section, not the section's virtual address.
        /// </summary>
        srRelocFilePos,

        /// <summary>
        /// Specifies a code-relative address fixup.
        /// </summary>
        srRelocCodeRelative,

        /// <summary>
        /// Generates a reloc for a 64 bit address in an ia64 movl instruction.
        /// </summary>
        srRelocIA64Imm64,

        /// <summary>
        /// Generates a reloc for a 64-bit address.
        /// </summary>
        srRelocDir64,

        /// <summary>
        /// Generate a reloc for a 25-bit PC-relative address in an ia64 br.call instruction.
        /// </summary>
        srRelocIA64PcRel25,

        /// <summary>
        /// Generates a reloc for a 64-bit PC-relative address in an ia64 brl.call instruction.
        /// </summary>
        srRelocIA64PcRel64,

        /// <summary>
        /// Generates a 30-bit section-relative reloc, used for tagged pointer values.
        /// </summary>
        srRelocAbsoluteTagged,

        /// <summary>
        /// A sentinel value to help ensure any additions to this enum are reflected to the internal reloc name array.
        /// </summary>
        srRelocSentinel,

        /// <summary>
        /// Specifies not to emit a base reloc.
        /// </summary>
        srNoBaseReloc = 0x4000,

        /// <summary>
        /// A value indicating that the pre-fixup contents of memory are a pointer rather than a section offset.
        /// </summary>
        srRelocPtr = 0x8000,

        /// <summary>
        /// Generates only a section-relative reloc, sending nothing into a .reloc section.
        /// </summary>
        srRelocAbsolutePtr = srRelocPtr + srRelocAbsolute,

        /// <summary>
        /// Generates a reloc for a pointer-sized location. This is transformed into BASED_HIGHLOW or BASED_DIR64 depending on the platform.
        /// </summary>
        srRelocHighLowPtr = srRelocPtr + srRelocHighLow,

        /// <summary>
        /// Indicates that the value is a relative address fixup.
        /// </summary>
        srRelocRelativePtr = srRelocPtr + srRelocRelative,

        /// <summary>
        /// Generates a reloc for a 64 bit address in an ia64 movl instruction.
        /// </summary>
        srRelocIA64Imm64Ptr = srRelocPtr + srRelocIA64Imm64,

        /// <summary>
        /// Generates a reloc for a 64-bit address.
        /// </summary>
        srRelocDir64Ptr = srRelocPtr + srRelocDir64,

    }
}