namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes the type of location for a symbol. This does *NOT* correspond to definitions in the data model.
    /// </summary>
    public enum SvcSymbolLocationKind : uint
    {
        SvcSymbolLocationNone,

        /// <summary>
        /// The location is complex and cannot be described by another SvcLocation* constant. Within a particular scope frame, the location may be evaluated -- but it cannot be described in more simple terms.<para/>
        /// Offset : unused RegInfo: unused.
        /// </summary>
        SvcSymbolLocationComplex,

        /// <summary>
        /// The location is an offset within the image (an RVA) Offset : [unsigned] the offset (RVA) within the containing image.<para/>
        /// RegInfo: unused ISvcSymbol::GetOffset() will return Offset in this case.
        /// </summary>
        SvcSymbolLocationImageOffset,

        /// <summary>
        /// The location is a register. Offset is unused. RegInfo.Number Offset : unused RegInfo: Number = &lt;opaque number&gt;, Size = register size, ContextOffset = offset into context record ISvcSymbol::GetOffset() will fail in this case.
        /// </summary>
        SvcSymbolLocationRegister,

        /// <summary>
        /// The location is register relative Offset : [signed] offset from register described in RegInfo RegInfo: Number = &lt;opaque number&gt;, Size = register size, ContextOffset = offset into context record ISvcSymbol::GetOffset() will fail in this case.
        /// </summary>
        SvcSymbolLocationRegisterRelative,

        /// <summary>
        /// The location is relative to the start of a data structure Offset : [unsigned] offset from the start of the structure (this pointer) RegInfo: unused ISvcSymbol::GetOffset() will return the structure offset in this case.
        /// </summary>
        SvcSymbolLocationStructureRelative,

        /// <summary>
        /// The location is a virtual address computed by means that cannot be described in a simple symbol location (this might be a linearlization of SvcLocationComplex) Offset : [unsigned] the virtual address RegInfo: unused ISvcSymbol::GetOffset() will fail in this case.
        /// </summary>
        SvcSymbolLocationVirtualAddress,

        /// <summary>
        /// The symbol has no "location"; rather, it has a constant value. ISvcSymbol::GetOffset() will fail in this case.
        /// </summary>
        SvcSymbolLocationConstantValue,

        /// <summary>
        /// The location is offset from an indirect read of a register relative location. In essence, the location is [@reg + PreOffset] + PostOffset PreOffset : [signed] offset from the register described in RegInfo where the indirect read occurs PostOffset: [signed] offset from the indirectly read value RegInfo : Number = &lt;opaque number&gt;, Size = register size, ContextOffset = offset into context record.
        /// </summary>
        SvcSymbolLocationRegisterRelativeIndirectOffset,

        /// <summary>
        /// The location is relative to the start of a data structure but is a bitfield. BitField.Offset : [unsigned] offset from the start of the structure (this pointer) BitField.FieldPosition : [unsigned] the bit position within the type BitField.FieldSize : [unsigned] the number of bits in the field BitField.Reserved : Reserved.<para/>
        /// Must be zero.
        /// </summary>
        SvcSymbolLocationStructureRelativeBitField,

        /// <summary>
        /// The location is an offset from the structure. The offset is determined by an entry in a table. TableOffsets.TableOffset : [signed] offset from the start of the structure (this pointer) where the table is located TableOffsets.TableSlot : [signed] slot in the table where the offset is located TableOffsets.SlotSize : [signed] ABS(SlotSize) == size in bytes of the offset entry in the table &lt;0: offsets are signed, &gt;0: offsets are unsigned This form of description is often used to describe the offset of a virtual base class from its parent class in lieu of an SvcSymbolLocationComplex descriptor.
        /// </summary>
        SvcSymbolLocationStructureRelativeTableOffset,

        /// <summary>
        /// The location is an offset within the TLS block Offset : [unsigned] the offset (RVA) within the TLS block. RegInfo: unused ISvcSymbol::GetOffset() will return Offset in this case.
        /// </summary>
        SvcSymbolLocationTLSOffset,

        SvcSymbolLocationMultipleLocations
    }
}
