using System;

namespace ClrDebug
{
    public static partial class Extensions
    {
        #region GetTokenAndMetaDataFromFunction

        /// <summary>
        ///  Gets the metadata token and a metadata interface instance that can be used against the token for the specified function.
        /// </summary>
        /// <typeparam name="T">The desired wrapper type or raw metadata interface to be returned. This can be either a raw interface or wrapper type.</typeparam>
        /// <param name="corProfilerInfo">The <see cref="CorProfilerInfo"/> to use to retrieve the metadata interface and function token.</param>
        /// <param name="functionId">The ID of the function for which to get the metadata token and metadata interface.</param>
        /// <returns>A tuple containing the metadata interface and function token.</returns>
        public static ValueTuple<T, mdToken> GetTokenAndMetaDataFromFunction<T>(
            this CorProfilerInfo corProfilerInfo,
            FunctionID functionId)
        {
            ValueTuple<T, mdToken> result;
            TryGetTokenAndMetaDataFromFunction(corProfilerInfo, functionId, out result).ThrowOnNotOK();
            return result;
        }

        /// <summary>
        /// Tries to get the metadata token and a metadata interface instance that can be used against the token for the specified function.
        /// </summary>
        /// <typeparam name="T">The desired wrapper type or raw metadata interface to be returned. This can be either a raw interface or wrapper type.</typeparam>
        /// <param name="corProfilerInfo">The <see cref="CorProfilerInfo"/> to use to retrieve the metadata interface and function token.</param>
        /// <param name="functionId">The ID of the function for which to get the metadata token and metadata interface.</param>
        /// <param name="result">A tuple containing the metadata interface and function token.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetTokenAndMetaDataFromFunction<T>(
            this CorProfilerInfo corProfilerInfo,
            FunctionID functionId,
            out ValueTuple<T, mdToken> result)
        {
            GetTokenAndMetaDataFromFunctionResult rawResult;
            var hr = corProfilerInfo.TryGetTokenAndMetaDataFromFunction(functionId, GetMetaDataGuid<T>(), out rawResult);

            if (hr == HRESULT.S_OK)
                result = ValueTuple.Create(GetMetaDataWrapper<T>(rawResult.ppImport), rawResult.pToken);
            else
                result = default(ValueTuple<T, mdToken>);

            return hr;
        }

        #endregion
        #region GetModuleMetaData

        /// <summary>
        /// Gets a metadata interface instance that maps to the specified module.
        /// </summary>
        /// <typeparam name="T">The desired wrapper type or raw metadata interface to be returned. This can be either a raw interface or wrapper type.</typeparam>
        /// <param name="corProfilerInfo">The <see cref="CorProfilerInfo"/> to use to retrieve the metadata interface and function token.</param>
        /// <param name="moduleId">The ID of the module to which the interface instance will be mapped.</param>
        /// <param name="dwOpenFlags">A value of the CorOpenFlags enumeration that specifies the mode for opening manifest files. Only the ofRead, ofWrite and ofNoTransform bits are valid.</param>
        /// <returns>The pointer to the returned interface.</returns>
        public static T GetModuleMetaData<T>(
            this CorProfilerInfo corProfilerInfo,
            ModuleID moduleId,
            CorOpenFlags dwOpenFlags)
        {
            T ppOut;
            TryGetModuleMetaData(corProfilerInfo, moduleId, dwOpenFlags, out ppOut).ThrowOnNotOK();
            return ppOut;
        }

        /// <summary>
        /// Tries to get a metadata interface instance that maps to the specified module.
        /// </summary>
        /// <typeparam name="T">The desired wrapper type or raw metadata interface to be returned. This can be either a raw interface or wrapper type.</typeparam>
        /// <param name="corProfilerInfo">The <see cref="CorProfilerInfo"/> to use to retrieve the metadata interface and function token.</param>
        /// <param name="moduleId">The ID of the module to which the interface instance will be mapped.</param>
        /// <param name="dwOpenFlags">A value of the CorOpenFlags enumeration that specifies the mode for opening manifest files. Only the ofRead, ofWrite and ofNoTransform bits are valid.</param>
        /// <param name="ppOut">The pointer to the returned interface.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetModuleMetaData<T>(
            this CorProfilerInfo corProfilerInfo,
            ModuleID moduleId,
            CorOpenFlags dwOpenFlags,
            out T ppOut)
        {
            object raw;
            var hr = corProfilerInfo.TryGetModuleMetaData(moduleId, dwOpenFlags, GetMetaDataGuid<T>(), out raw);

            if (hr == HRESULT.S_OK)
                ppOut = GetMetaDataWrapper<T>(raw);
            else
                ppOut = default(T);

            return hr;
        }

        #endregion
    }
}
