using System;
using static ClrDebug.Extensions;

namespace ClrDebug
{
    public partial class MetaDataDispenserEx
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaDataDispenserEx"/> class from the "MetaDataGetDispenser" export of the CLR in the current process.<para/>
        /// This constructor cannot be used in NativeAOT.
        /// </summary>
        public MetaDataDispenserEx() : this(MetaDataGetDispenser())
        {
        }
    }

    public static partial class Extensions
    {
        #region DefineScope

        /// <summary>
        /// Creates a new area in memory in which you can create new metadata.
        /// </summary>
        /// <typeparam name="T">The desired metadata interface to be returned. This can be either a raw interface or wrapper type.</typeparam>
        /// <param name="metaDataDispenser">The <see cref="MetaDataDispenser"/> in which the scope should be defined.</param>
        /// <returns>The pointer to the returned interface.</returns>
        public static T DefineScope<T>(this MetaDataDispenser metaDataDispenser)
        {
            T ppIUnk;
            TryDefineScope(metaDataDispenser, out ppIUnk).ThrowOnNotOK();
            return ppIUnk;
        }

        /// <summary>
        /// Creates a new area in memory in which you can create new metadata.
        /// </summary>
        /// <typeparam name="T">The desired wrapper type or raw metadata interface to be returned. This can be either a raw interface or wrapper type.</typeparam>
        /// <param name="metaDataDispenser">The <see cref="MetaDataDispenser"/> in which the scope should be defined.</param>
        /// <param name="rclsid">The CLSID of the version of metadata structures to be created. This value must be CLSID_CorMetaDataRuntime for the .NET Framework version 2.0.</param>
        /// <param name="dwCreateFlags">Flags that specify options. This value must be zero for the .NET Framework 2.0.</param>
        /// <returns>The pointer to the returned interface.</returns>
        public static T DefineScope<T>(this MetaDataDispenser metaDataDispenser, Guid rclsid, int dwCreateFlags)
        {
            T ppIUnk;
            TryDefineScope(metaDataDispenser, rclsid, dwCreateFlags, out ppIUnk).ThrowOnNotOK();
            return ppIUnk;
        }

        /// <summary>
        /// Tries to create a new area in memory in which you can create new metadata.
        /// </summary>
        /// <typeparam name="T">The desired wrapper type or raw metadata interface to be returned. This can be either a raw interface or wrapper type.</typeparam>
        /// <param name="metaDataDispenser">The <see cref="MetaDataDispenser"/> in which the scope should be defined.</param>
        /// <param name="ppIUnk">The pointer to the returned interface.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryDefineScope<T>(this MetaDataDispenser metaDataDispenser, out T ppIUnk) =>
            TryDefineScope(metaDataDispenser, CLSID_CorMetaDataRuntime, 0, out ppIUnk);

        /// <summary>
        /// Tries to create a new area in memory in which you can create new metadata.
        /// </summary>
        /// <typeparam name="T">The desired wrapper type or raw metadata interface to be returned. This can be either a raw interface or wrapper type.</typeparam>
        /// <param name="metaDataDispenser">The <see cref="MetaDataDispenser"/> in which the scope should be defined.</param>
        /// <param name="rclsid">The CLSID of the version of metadata structures to be created. This value must be CLSID_CorMetaDataRuntime for the .NET Framework version 2.0.</param>
        /// <param name="dwCreateFlags">Flags that specify options. This value must be zero for the .NET Framework 2.0.</param>
        /// <param name="ppIUnk">The pointer to the returned interface.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryDefineScope<T>(
            this MetaDataDispenser metaDataDispenser,
            Guid rclsid,
            int dwCreateFlags, out T ppIUnk)
        {
            var hr = metaDataDispenser.TryDefineScope(rclsid, dwCreateFlags, GetMetaDataGuid<T>(), out var raw);

            if (hr == HRESULT.S_OK)
                ppIUnk = GetMetaDataWrapper<T>(raw);
            else
                ppIUnk = default(T);

            return hr;
        }

        #endregion
        #region OpenScope

        /// <summary>
        /// Opens an existing, on-disk file and maps its metadata into memory.
        /// </summary>
        /// <typeparam name="T">The desired wrapper type or raw metadata interface to be returned; the caller will use the interface to import (read) or emit (write) metadata.</typeparam>
        /// <param name="metaDataDispenser">The <see cref="MetaDataDispenser"/> in which the scope should be opened.</param>
        /// <param name="szScope">The name of the file to be opened. The file must contain common language runtime (CLR) metadata.</param>
        /// <param name="dwOpenFlags">A value of the <see cref="CorOpenFlags"/> enumeration to specify the mode (read, write, and so on) for opening.</param>
        /// <returns>The pointer to the returned interface.</returns>
        public static T OpenScope<T>(
            this MetaDataDispenser metaDataDispenser,
            string szScope,
            CorOpenFlags dwOpenFlags)
        {
            T ppIUnk;
            TryOpenScope(metaDataDispenser, szScope, dwOpenFlags, out ppIUnk).ThrowOnNotOK();
            return ppIUnk;
        }

        /// <summary>
        /// Tries to open an existing, on-disk file and maps its metadata into memory.
        /// </summary>
        /// <typeparam name="T">The desired wrapper type or raw metadata interface to be returned; the caller will use the interface to import (read) or emit (write) metadata.</typeparam>
        /// <param name="metaDataDispenser">The <see cref="MetaDataDispenser"/> in which the scope should be opened.</param>
        /// <param name="szScope">The name of the file to be opened. The file must contain common language runtime (CLR) metadata.</param>
        /// <param name="dwOpenFlags">A value of the <see cref="CorOpenFlags"/> enumeration to specify the mode (read, write, and so on) for opening.</param>
        /// <param name="ppIUnk">The pointer to the returned interface.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryOpenScope<T>(
            this MetaDataDispenser metaDataDispenser,
            string szScope,
            CorOpenFlags dwOpenFlags,
            out T ppIUnk)
        {
            var hr = metaDataDispenser.TryOpenScope(szScope, dwOpenFlags, GetMetaDataGuid<T>(), out var raw);

            if (hr == HRESULT.S_OK)
                ppIUnk = GetMetaDataWrapper<T>(raw);
            else
                ppIUnk = default(T);

            return hr;
        }

        #endregion
        #region OpenScopeOnMemory

        /// <summary>
        /// Opens an area of memory that contains existing metadata. That is, this method opens a specified area of memory in which the existing data is treated as metadata.
        /// </summary>
        /// <typeparam name="T">The desired wrapper type or raw metadata interface to be returned; the caller will use the interface to import (read) or emit (write) metadata.</typeparam>
        /// <param name="metaDataDispenser">The <see cref="MetaDataDispenser"/> in which the scope should be opened.</param>
        /// <param name="pData">A pointer that specifies the starting address of the memory area.</param>
        /// <param name="cbData">The size of the memory area, in bytes.</param>
        /// <param name="dwOpenFlags">A value of the <see cref="CorOpenFlags"/> enumeration to specify the mode (read, write, and so on) for opening.</param>
        /// <returns>The pointer to the returned interface.</returns>
        public static T OpenScopeOnMemory<T>(
            this MetaDataDispenser metaDataDispenser,
            IntPtr pData,
            int cbData,
            CorOpenFlags dwOpenFlags)
        {
            T ppIUnk;
            TryOpenScopeOnMemory(metaDataDispenser, pData, cbData, dwOpenFlags, out ppIUnk).ThrowOnNotOK();
            return ppIUnk;
        }

        /// <summary>
        /// Tries to open an area of memory that contains existing metadata. That is, this method opens a specified area of memory in which the existing data is treated as metadata.
        /// </summary>
        /// <typeparam name="T">The desired wrapper type or raw metadata interface to be returned; the caller will use the interface to import (read) or emit (write) metadata.</typeparam>
        /// <param name="metaDataDispenser">The <see cref="MetaDataDispenser"/> in which the scope should be opened.</param>
        /// <param name="pData">A pointer that specifies the starting address of the memory area.</param>
        /// <param name="cbData">The size of the memory area, in bytes.</param>
        /// <param name="dwOpenFlags">A value of the <see cref="CorOpenFlags"/> enumeration to specify the mode (read, write, and so on) for opening.</param>
        /// <param name="ppIUnk">The pointer to the returned interface.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryOpenScopeOnMemory<T>(
            this MetaDataDispenser metaDataDispenser,
            IntPtr pData,
            int cbData,
            CorOpenFlags dwOpenFlags,
            out T ppIUnk)
        {
            var hr = metaDataDispenser.TryOpenScopeOnMemory(pData, cbData, dwOpenFlags, GetMetaDataGuid<T>(), out var raw);

            if (hr == HRESULT.S_OK)
                ppIUnk = GetMetaDataWrapper<T>(raw);
            else
                ppIUnk = default(T);

            return hr;
        }

        #endregion
        #region GetOption

        /// <summary>
        /// Gets the value of the specified option for the current metadata scope. The option controls how calls to the current metadata scope are handled.
        /// </summary>
        /// <typeparam name="T">The type of value returned by the option. See the members of <see cref="MetaDataDispenserOption"/> for information on the type of value each option returns.</typeparam>
        /// <param name="metaDataDispenser">The <see cref="IMetaDataDispenserEx"/> to use to retrieve the option.</param>
        /// <param name="optionId">A pointer to a GUID that specifies the option to be retrieved. For possible values see <see cref="MetaDataDispenserOption"/>.</param>
        /// <returns>The value of the returned option.</returns>
        public static T GetOption<T>(this MetaDataDispenserEx metaDataDispenser, Guid optionId) =>
            (T) metaDataDispenser.GetOption(optionId);

        /// <summary>
        /// Tries to get the value of the specified option for the current metadata scope. The option controls how calls to the current metadata scope are handled.
        /// </summary>
        /// <typeparam name="T">The type of value returned by the option. See the members of <see cref="MetaDataDispenserOption"/> for information on the type of value each option returns.</typeparam>
        /// <param name="metaDataDispenser">The <see cref="IMetaDataDispenserEx"/> to use to retrieve the option.</param>
        /// <param name="optionId">A pointer to a GUID that specifies the option to be retrieved. For possible values see <see cref="MetaDataDispenserOption"/>.</param>
        /// <param name="value">The value of the returned option.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetOption<T>(this MetaDataDispenserEx metaDataDispenser, Guid optionId, out T value)
        {
            var hr = metaDataDispenser.TryGetOption(optionId, out var pValue);

            if (hr == HRESULT.S_OK)
                value = (T) pValue;
            else
                value = default(T);

            return hr;
        }

        #endregion

        private static Guid GetMetaDataGuid<T>()
        {
            var t = typeof(T);

            if (t == typeof(MetaDataImport))
                return typeof(IMetaDataImport).GUID;

            if (t == typeof(MetaDataEmit))
                return typeof(IMetaDataEmit).GUID;

            if (t == typeof(MetaDataAssemblyImport))
                return typeof(IMetaDataAssemblyImport).GUID;

            if (t == typeof(MetaDataAssemblyEmit))
                return typeof(IMetaDataAssemblyEmit).GUID;

            if (t == typeof(MetaDataDispenser))
                return typeof(IMetaDataDispenser).GUID;

            if (t == typeof(MetaDataDispenserEx))
                return typeof(IMetaDataDispenserEx).GUID;

            return t.GUID;
        }

        private static T GetMetaDataWrapper<T>(object raw)
        {
            var t = typeof(T);
            object ppIUnk;

            if (t == typeof(MetaDataImport))
                ppIUnk = new MetaDataImport((IMetaDataImport) raw);
            else if (t == typeof(MetaDataAssemblyImport))
                ppIUnk = new MetaDataAssemblyImport((IMetaDataAssemblyImport) raw);
            else if (t == typeof(MetaDataEmit))
                ppIUnk = new MetaDataEmit((IMetaDataEmit) raw);
            else if (t == typeof(MetaDataAssemblyEmit))
                ppIUnk = new MetaDataAssemblyEmit((IMetaDataAssemblyEmit) raw);
            else if (t == typeof(MetaDataDispenser))
                ppIUnk = new MetaDataDispenser((IMetaDataDispenser) raw);
            else if (t == typeof(MetaDataDispenserEx))
                ppIUnk = new MetaDataDispenserEx((IMetaDataDispenserEx)raw);
            else
                ppIUnk = raw;

            return (T)ppIUnk;
        }
    }
}
