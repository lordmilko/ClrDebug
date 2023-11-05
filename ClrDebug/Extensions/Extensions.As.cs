using System;

namespace ClrDebug
{
    public static partial class Extensions
    {
        #region ClrDataAccess

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the mscordacwks!ClrDataAccess type.<para/>
        /// Possible conversions include <see cref="SOSDacInterface"/>, <see cref="XCLRDataProcess"/>
        /// and <see cref="CLRDataEnumMemoryRegions"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces ClrDataAccess supports.</typeparam>
        /// <param name="sosDacInterface">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this SOSDacInterface sosDacInterface) =>
            AsClrDataAccess<T, ISOSDacInterface>(sosDacInterface.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the mscordacwks!ClrDataAccess type.<para/>
        /// Possible conversions include <see cref="SOSDacInterface"/>, <see cref="XCLRDataProcess"/>
        /// and <see cref="CLRDataEnumMemoryRegions"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces ClrDataAccess supports.</typeparam>
        /// <param name="xclrDataProcess">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this XCLRDataProcess xclrDataProcess) =>
            AsClrDataAccess<T, IXCLRDataProcess>(xclrDataProcess.Raw);

        private static TResult AsClrDataAccess<TResult, TRaw>(object raw)
        {
            var t = typeof(TResult);
            object result;

            if (t == typeof(SOSDacInterface))
                result = new SOSDacInterface((ISOSDacInterface) raw);
            else if (t == typeof(XCLRDataProcess))
                result = new XCLRDataProcess((IXCLRDataProcess) raw);
            else if (t == typeof(CLRDataEnumMemoryRegions))
                result = new CLRDataEnumMemoryRegions((ICLRDataEnumMemoryRegions) raw);
            else
                throw GetAsNotSupportedException<TResult, TRaw>();

            return (TResult) result;
        }

        #endregion
        #region ClrDataModule

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the mscordacwks!ClrDataModule type.<para/>
        /// Possible conversions include <see cref="MetaDataImport"/> and <see cref="XCLRDataModule"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces ClrDataModule supports.</typeparam>
        /// <param name="xclrDataModule">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this XCLRDataModule xclrDataModule)
        {
            var t = typeof(T);
            object result;

            if (t == typeof(MetaDataImport))
                result = new MetaDataImport((IMetaDataImport) xclrDataModule.Raw);
            else if (t == typeof(XCLRDataModule))
                result = xclrDataModule;
            else
                throw GetAsNotSupportedException<T, IXCLRDataModule>();

            return (T) result;
        }

        #endregion
        #region RegMeta

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the clr!RegMeta type.<para/>
        /// Possible conversions include <see cref="MetaDataImport"/>, <see cref="MetaDataAssemblyImport"/>,
        /// <see cref="MetaDataEmit"/>, <see cref="MetaDataAssemblyEmit"/>, <see cref="MetaDataTables"/>
        /// and <see cref="MetaDataInfo"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces RegMeta supports.</typeparam>
        /// <param name="metaDataImport">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this MetaDataImport metaDataImport) =>
            AsRegMeta<T, IMetaDataImport>(metaDataImport.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the clr!RegMeta type.<para/>
        /// Possible conversions include <see cref="MetaDataImport"/>, <see cref="MetaDataAssemblyImport"/>,
        /// <see cref="MetaDataEmit"/>, <see cref="MetaDataAssemblyEmit"/>, <see cref="MetaDataTables"/>
        /// and <see cref="MetaDataInfo"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces RegMeta supports.</typeparam>
        /// <param name="metaDataAssemblyImport">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this MetaDataAssemblyImport metaDataAssemblyImport) =>
            AsRegMeta<T, IMetaDataAssemblyImport>(metaDataAssemblyImport.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the clr!RegMeta type.<para/>
        /// Possible conversions include <see cref="MetaDataImport"/>, <see cref="MetaDataAssemblyImport"/>,
        /// <see cref="MetaDataEmit"/>, <see cref="MetaDataAssemblyEmit"/>, <see cref="MetaDataTables"/>
        /// and <see cref="MetaDataInfo"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces RegMeta supports.</typeparam>
        /// <param name="metaDataEmit">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this MetaDataEmit metaDataEmit) =>
            AsRegMeta<T, IMetaDataEmit>(metaDataEmit.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the clr!RegMeta type.<para/>
        /// Possible conversions include <see cref="MetaDataImport"/>, <see cref="MetaDataAssemblyImport"/>,
        /// <see cref="MetaDataEmit"/>, <see cref="MetaDataAssemblyEmit"/>, <see cref="MetaDataTables"/>
        /// and <see cref="MetaDataInfo"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces RegMeta supports.</typeparam>
        /// <param name="metaDataAssemblyEmit">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this MetaDataAssemblyEmit metaDataAssemblyEmit) =>
            AsRegMeta<T, IMetaDataAssemblyEmit>(metaDataAssemblyEmit.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the clr!RegMeta type.<para/>
        /// Possible conversions include <see cref="MetaDataImport"/>, <see cref="MetaDataAssemblyImport"/>,
        /// <see cref="MetaDataEmit"/>, <see cref="MetaDataAssemblyEmit"/>, <see cref="MetaDataTables"/>
        /// and <see cref="MetaDataInfo"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces RegMeta supports.</typeparam>
        /// <param name="metaDataTables">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this MetaDataTables metaDataTables) =>
            AsRegMeta<T, IMetaDataTables>(metaDataTables.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the clr!RegMeta type.<para/>
        /// Possible conversions include <see cref="MetaDataImport"/>, <see cref="MetaDataAssemblyImport"/>,
        /// <see cref="MetaDataEmit"/>, <see cref="MetaDataAssemblyEmit"/>, <see cref="MetaDataTables"/>
        /// and <see cref="MetaDataInfo"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces RegMeta supports.</typeparam>
        /// <param name="metaDataInfo">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this MetaDataInfo metaDataInfo) =>
            AsRegMeta<T, IMetaDataInfo>(metaDataInfo.Raw);

        private static TResult AsRegMeta<TResult, TRaw>(object raw)
        {
            var t = typeof(TResult);
            object result;

            if (t == typeof(MetaDataImport))
                result = new MetaDataImport((IMetaDataImport) raw);
            else if (t == typeof(MetaDataAssemblyImport))
                result = new MetaDataAssemblyImport((IMetaDataAssemblyImport) raw);

            else if (t == typeof(MetaDataEmit))
                result = new MetaDataEmit((IMetaDataEmit) raw);
            else if (t == typeof(MetaDataAssemblyEmit))
                result = new MetaDataAssemblyEmit((IMetaDataAssemblyEmit) raw);

            else if (t == typeof(MetaDataTables))
                result = new MetaDataTables((IMetaDataTables) raw);
            else if (t == typeof(MetaDataInfo))
                result = new MetaDataInfo((IMetaDataInfo) raw);
            else
                throw GetAsNotSupportedException<TResult, TRaw>();

            return (TResult) result;
        }

        #endregion
        #region CorDebugValue

        //Visio diagram showing the relationships between the ICorDebugValue interfaces and their implementing types:
        //https://github.com/dotnet/runtime/blob/764d3e0cfab629bb6e594f3399c9ba7362a621c3/src/coreclr/debug/di/ICorDebugValueTypes.vsd

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by an object that derives from the mscordbi!CordbValue type.<para/>
        /// Supported conversions for a given object are shown in the debugger display of the object.<para/>
        /// Possible conversions include <see cref="CorDebugArrayValue"/>, <see cref="CorDebugBoxValue"/>,
        /// <see cref="CorDebugComObjectValue"/>, <see cref="CorDebugDelegateObjectValue"/>, <see cref="CorDebugGenericValue"/>,
        /// <see cref="CorDebugHandleValue"/>, <see cref="CorDebugHeapValue"/>, <see cref="CorDebugObjectValue"/>,
        /// <see cref="CorDebugReferenceValue"/>, <see cref="CorDebugStringValue"/> and <see cref="CorDebugValue"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces a type derived from CordbValue supports.</typeparam>
        /// <param name="corDebugValue">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        public static T As<T>(this CorDebugValue corDebugValue)
        {
            var t = typeof(T);
            object result;

            var raw = corDebugValue.Raw;

            //ICorDebugContext implements ICorDebugObjectValue, but derives from CordbBase,
            //not CordbValue. Not that it matters, because ICorDebugContext doesn't define any methods
            //and is never instantiated

            if (t == typeof(CorDebugArrayValue))
                result = new CorDebugArrayValue((ICorDebugArrayValue) raw);
            else if (t == typeof(CorDebugBoxValue))
                result = new CorDebugBoxValue((ICorDebugBoxValue) raw);
            else if (t == typeof(CorDebugComObjectValue))
                result = new CorDebugComObjectValue((ICorDebugComObjectValue) raw);
            else if (t == typeof(CorDebugDelegateObjectValue))
                result = new CorDebugDelegateObjectValue((ICorDebugDelegateObjectValue) raw);
            else if (t == typeof(CorDebugGenericValue))
                result = new CorDebugGenericValue((ICorDebugGenericValue) raw);
            else if (t == typeof(CorDebugHandleValue))
                result = new CorDebugHandleValue((ICorDebugHandleValue) raw);
            else if (t == typeof(CorDebugHeapValue))
                result = CorDebugHeapValue.New((ICorDebugHeapValue) raw);
            else if (t == typeof(CorDebugObjectValue))
                result = new CorDebugObjectValue((ICorDebugObjectValue) raw);
            else if (t == typeof(CorDebugReferenceValue))
                result = new CorDebugReferenceValue((ICorDebugReferenceValue) raw);
            else if (t == typeof(CorDebugStringValue))
                result = new CorDebugStringValue((ICorDebugStringValue) raw);
            else if (t == typeof(CorDebugValue))
                result = CorDebugValue.New(corDebugValue.Raw);
            else
                throw GetAsNotSupportedException<T, ICorDebugValue>();

            return (T) result;
        }

        #endregion

        internal static NotSupportedException GetAsNotSupportedException<TResult, TRaw>()
        {
            return new NotSupportedException($"Casting '{typeof(TRaw).Name}' to a wrapper of type '{typeof(TResult).Name}' is not supported. If {typeof(TRaw).Name} supports the wrapper's underlying interface, please construct the wrapper manually.");
        }
    }
}
