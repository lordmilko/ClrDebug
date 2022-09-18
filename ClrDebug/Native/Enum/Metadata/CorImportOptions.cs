using System;

namespace ClrDebug
{
    /// <summary>
    /// Contains flag values that control the behavior during importation of an assembly outside the current scope.<para/>
    /// Used with <see cref="MetaDataDispenserOption.MetaDataImportOption"/>.
    /// </summary>
    [Flags]
    public enum CorImportOptions : uint
    {
        /// <summary>
        /// Indicates the default behavior, which is to skip deleted records.
        /// </summary>
        MDImportOptionDefault = 0x00000000,   // default to skip over deleted records

        /// <summary>
        /// Indicates that all metadata should be enumerated.
        /// </summary>
        MDImportOptionAll = 0xFFFFFFFF,   // Enumerate everything

        /// <summary>
        /// Indicates that all TypeDefs, including deleted ones, should be enumerated.
        /// </summary>
        MDImportOptionAllTypeDefs = 0x00000001,   // all of the typedefs including the deleted typedef

        /// <summary>
        /// Indicates that all MethodDefs, including deleted ones, should be enumerated.
        /// </summary>
        MDImportOptionAllMethodDefs = 0x00000002,   // all of the methoddefs including the deleted ones

        /// <summary>
        /// Indicates that all FieldDefs, including deleted ones, should be enumerated.
        /// </summary>
        MDImportOptionAllFieldDefs = 0x00000004,   // all of the fielddefs including the deleted ones

        /// <summary>
        /// Indicates that all PropertyDefs, including deleted ones, should be enumerated.
        /// </summary>
        MDImportOptionAllProperties = 0x00000008,   // all of the properties including the deleted ones

        /// <summary>
        /// Indicates that all EventDefs, including deleted ones, should be enumerated.
        /// </summary>
        MDImportOptionAllEvents = 0x00000010,   // all of the events including the deleted ones

        /// <summary>
        /// Indicates that all custom attributes, including deleted ones, should be enumerated.
        /// </summary>
        MDImportOptionAllCustomAttributes = 0x00000020, // all of the custom attributes including the deleted ones

        /// <summary>
        /// Indicates that all exported types, including deleted ones, should be enumerated.
        /// </summary>
        MDImportOptionAllExportedTypes = 0x00000040,   // all of the ExportedTypes including the deleted ones
    }
}
