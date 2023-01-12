using System;

namespace ClrDebug
{
    public static class MetaDataDispenserOption
    {
        /// <summary>
        /// Controls which items are checked for duplicates. Value: A bitwise combination of <see cref="CorCheckDuplicatesFor"/> values as a variant of type UI4.<para/>
        /// Each time you call an <see cref="IMetaDataEmit"/> method that creates a new item, you can ask the method to check whether the item already exists in the current scope.<para/>
        /// For example, you can check for the existence of <see cref="mdMethodDef"/> items; in this case, when you call <see cref="IMetaDataEmit.DefineMethod"/>, it will check that the method does not already exist in the current scope.<para/>
        /// This check uses the key that uniquely identifies a given method: parent type, name, and signature.
        /// </summary>
        public static readonly Guid MetaDataCheckDuplicatesFor = new Guid("30FE7BE8-D7D9-11D2-9F80-00C04F79A0A3");

        /// <summary>
        /// Controls which referenced items are converted to definitions. Value: a bitwise combination of <see cref="CorRefToDefCheck"/> values as a variant of type UI4.<para/>
        /// By default, the metadata engine will optimize the code by converting a referenced item to its definition if the referenced item is actually defined in the current scope.
        /// </summary>
        public static readonly Guid MetaDataRefToDefCheck = new Guid("DE3856F8-D7D9-11D2-9F80-00C04F79A0A3");

        /// <summary>
        /// Controls which token remaps occurring during a metadata merge generate callbacks. Value: a bitwise combination of <see cref="CorNotificationForTokenMovement"/> values.<para/>
        /// Use the <see cref="IMetaDataEmit.SetHandler"/> method to establish your <see cref="IMapToken"/> interface.    
        /// </summary>
        public static readonly Guid MetaDataNotificationForTokenMovement = new Guid("E5D71A4C-D7DA-11D2-9F80-00C04F79A0A3");

        /// <summary>
        /// Controls the behavior of edit-and-continue (ENC). Only one mode of behavior can be set at a time. Value: a <see cref="CorSetENC"/> value as a variant of type UI4.
        /// </summary>
        public static readonly Guid MetaDataSetENC = new Guid("2eee315c-d7db-11d2-9f80-00c04f79a0a3");

        /// <summary>
        /// Controls which emitted-out-of-order errors generate callbacks. Value: a bitwise combination of <see cref="CorErrorIfEmitOutOfOrder"/> values as a variant of type UI4.
        /// Emitting metadata out of order is not fatal; however, if you emit metadata in an order that is favored by the metadata engine, the metadata is more compact and therefore can be more efficiently searched.
        /// Use the <see cref="IMetaDataEmit.SetHandler"/> method to establish your <see cref="IMetaDataError"/> interface.    
        /// </summary>
        public static readonly Guid MetaDataErrorIfEmitOutOfOrder = new Guid("1547872D-DC03-11d2-9420-0000F8083460");

        /// <summary>
        /// Controls which kinds of items that were deleted during an ENC are retrieved by an enumerator. Value: a bitwise combination of <see cref="CorImportOptions"/> values as a variant of type UI4.
        /// </summary>
        public static readonly Guid MetaDataImportOption = new Guid("79700F36-4AAC-11d3-84C3-009027868CB1");

        /// <summary>
        /// Controls whether the metadata engine obtains reader/writer locks, thereby ensuring thread safety. Value: a <see cref="CorThreadSafetyOptions"/> value as a variant of type UI4.<para/>
        /// By default, the engine assumes that access is single-threaded by the caller, so no locks are obtained.<para/>
        /// Clients are responsible for maintaining proper thread synchronization when using the metadata API.    
        /// </summary>
        public static readonly Guid MetaDataThreadSafetyOptions = new Guid("F7559806-F266-42ea-8C63-0ADB45E8B234");

        /// <summary>
        /// Controls whether the type library importer should generate the tightly coupled event (TCE) adapters for COM connection point containers. Value: a variant of type <see cref="bool"/>.
        /// </summary>
        public static readonly Guid MetaDataGenerateTCEAdapters = new Guid("DCC9DE90-4151-11d3-88D6-00902754C43A");

        /// <summary>
        /// Specifies a non-default namespace for the type library that is being imported. Value: must be either a null value or a variant of type BSTR.<para/>
        /// If pValue is a null value, the current namespace is set to null; otherwise, the current namespace is set to the string that is held in the variant's BSTR type.
        /// </summary>
        public static readonly Guid MetaDataTypeLibImportNamespace = new Guid("F17FF889-5A63-11d3-9FF2-00C04FF7431A");

        /// <summary>
        /// Controls whether the linker should generate an assembly or a .NET Framework module file. Value: a bitwise combination of <see cref="CorLinkerOptions"/> values as a variant of type UI4.
        /// </summary>
        public static readonly Guid MetaDataLinkerOptions = new Guid("47E099B6-AE7C-4797-8317-B48AA645B8F9");

        /// <summary>
        /// Specifies the version of the common language runtime against which this image was built. Value: must be a null value, a VT_EMPTY value, or a variant of type BSTR.<para/>
        /// If pValue is null, the runtime version is set to null. If pValue is VT_EMPTY, the version is set to a default value, which is drawn from the version of Mscorwks.dll within which the metadata code is running.<para/>
        /// Otherwise, the runtime version is set to the string that is held in the variant's BSTR type.<para/>
        /// The version is stored as a string, such as "v1.0.3705".
        /// </summary>
        public static readonly Guid MetaDataRuntimeVersion = new Guid("47E099B7-AE7C-4797-8317-B48AA645B8F9");

        /// <summary>
        /// Specifies options for merging metadata. Value: a bitwise combination of <see cref="MergeFlags"/> values as a variant of type UI4.
        /// </summary>
        public static readonly Guid MetaDataMergerOptions = new Guid("132D3A6E-B35D-464e-951A-42EFB9FB6601");

        /// <summary>
        /// Disables optimizing local references into definitions. Value: a bitwise combination of <see cref="CorLocalRefPreservation"/> values.
        /// </summary>
        public static readonly Guid MetaDataPreserveLocalRefs = new Guid("a55c0354-e91b-468b-8648-7cc31035d533");

    }
}
