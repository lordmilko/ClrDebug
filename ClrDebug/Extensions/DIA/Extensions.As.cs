using System;

namespace ClrDebug.DIA
{
    public static partial class DiaExtensions
    {
        #region DiaEnumDebugStreamData

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the <see cref="IDiaEnumDebugStreamData"/> interface.<para/>
        /// Possible conversions include <see cref="DiaImageData"/> and <see cref="DiaEnumDebugStreamData"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces <see cref="IDiaEnumDebugStreamData"/> supports.</typeparam>
        /// <param name="diaEnumDebugStreamData">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DiaEnumDebugStreamData diaEnumDebugStreamData)
        {
            var t = typeof(T);
            object result;

            var raw = diaEnumDebugStreamData.Raw;

            if (t == typeof(DiaImageData))
                result = new DiaImageData((IDiaImageData) raw);
            else if (t == typeof(DiaEnumDebugStreamData))
                result = diaEnumDebugStreamData;
            else
                throw Extensions.GetAsNotSupportedException<T, IDiaEnumDebugStreamData>();

            return (T) result;
        }

        #endregion
        #region DiaSession

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the <see cref="IDiaSession"/> interface.<para/>
        /// Possible conversions include <see cref="DiaAddressMap"/> and <see cref="DiaSession"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces <see cref="IDiaSession"/> supports.</typeparam>
        /// <param name="diaSession">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DiaSession diaSession)
        {
            var t = typeof(T);
            object result;

            var raw = diaSession.Raw;

            if (t == typeof(DiaAddressMap))
                result = new DiaAddressMap((IDiaAddressMap) raw);
            else if (t == typeof(DiaSession))
                result = diaSession;
            else
                throw Extensions.GetAsNotSupportedException<T, IDiaEnumDebugStreamData>();

            return (T) result;
        }

        #endregion
        #region As<DiaPropertyStorage>

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the <see cref="IDiaSectionContrib"/> interface.<para/>
        /// The only supported conversion is <see cref="DiaPropertyStorage"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="DiaPropertyStorage"/> type.</typeparam>
        /// <param name="diaSectionContrib">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DiaSectionContrib diaSectionContrib) where T : DiaPropertyStorage =>
            (T) AsDiaPropertyStorage(diaSectionContrib.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the <see cref="IDiaSegment"/> interface.<para/>
        /// The only supported conversion is <see cref="DiaPropertyStorage"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="DiaPropertyStorage"/> type.</typeparam>
        /// <param name="diaSegment">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DiaSegment diaSegment) where T : DiaPropertyStorage =>
            (T) AsDiaPropertyStorage(diaSegment.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the <see cref="IDiaInjectedSource"/> interface.<para/>
        /// The only supported conversion is <see cref="DiaPropertyStorage"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="DiaPropertyStorage"/> type.</typeparam>
        /// <param name="diaInjectedSource">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DiaInjectedSource diaInjectedSource) where T : DiaPropertyStorage =>
            (T) AsDiaPropertyStorage(diaInjectedSource.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the <see cref="IDiaFrameData"/> interface.<para/>
        /// The only supported conversion is <see cref="DiaPropertyStorage"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="DiaPropertyStorage"/> type.</typeparam>
        /// <param name="diaFrameData">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DiaFrameData diaFrameData) where T : DiaPropertyStorage =>
            (T) AsDiaPropertyStorage(diaFrameData.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the <see cref="IDiaSymbol"/> interface.<para/>
        /// The only supported conversion is <see cref="DiaPropertyStorage"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="DiaPropertyStorage"/> type.</typeparam>
        /// <param name="diaSymbol">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DiaSymbol diaSymbol) where T : DiaPropertyStorage =>
            (T) AsDiaPropertyStorage(diaSymbol.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the <see cref="IDiaSourceFile"/> interface.<para/>
        /// The only supported conversion is <see cref="DiaPropertyStorage"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="DiaPropertyStorage"/> type.</typeparam>
        /// <param name="diaSourceFile">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DiaSourceFile diaSourceFile) where T : DiaPropertyStorage =>
            (T) AsDiaPropertyStorage(diaSourceFile.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the <see cref="IDiaLineNumber"/> interface.<para/>
        /// The only supported conversion is <see cref="DiaPropertyStorage"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="DiaPropertyStorage"/> type.</typeparam>
        /// <param name="diaLineNumber">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DiaLineNumber diaLineNumber) where T : DiaPropertyStorage =>
            (T) AsDiaPropertyStorage(diaLineNumber.Raw);

        private static object AsDiaPropertyStorage<T>(T value) =>
            new DiaPropertyStorage((IDiaPropertyStorage) value);

        #endregion
        #region DiaTable

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the <see cref="IDiaTable"/> interface.<para/>
        /// Each <see cref="IDiaTable"/> instance is in fact an enumerator for iterating over one and only one type of resource.
        /// To locate the <see cref="IDiaTable"/> that implements given enumerator interface, see the <see cref="GetTable{T}(DiaSession)"/> extension
        /// method. This method should only be used when you already know for certain which enumerator a given <see cref="IDiaTable"/> represents.
        /// Possible conversions include <see cref="DiaEnumSymbols"/>, <see cref="DiaEnumSourceFiles"/>, <see cref="DiaEnumLineNumbers"/>,
        /// <see cref="DiaEnumSectionContribs"/>, <see cref="DiaEnumSegments"/>, <see cref="DiaEnumInjectedSources"/>
        /// and <see cref="DiaEnumFrameData"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces <see cref="IDiaTable"/> supports.</typeparam>
        /// <param name="diaTable">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        private static T As<T>(this DiaTable diaTable)
        {
            //This method is implemented for completeness, however due to the fact that each IDiaTable exclusively implements one of the available
            //enumerator interfaces, it is inherently unsafe to forcefully cast an IDiaTable to a given interface. To locate the IDiaTable
            //that implements a given enumerator, use the GetTable<T>() extension method.

            var t = typeof(T);
            object result;

            var raw = diaTable.Raw;

            Exception invalidTable<TInterface>()
            {
                throw new InvalidCastException(
                    $"Cannot convert the specified {nameof(IDiaTable)} instance to type '{typeof(TInterface).Name}': interface '{typeof(TInterface).Name}' is not supported. " +
                    $"Each {nameof(IDiaTable)} represents a specific type of enumerator. To locate the {nameof(IDiaTable)} that contains a specific " +
                    $"type of enumerator, please see the {nameof(GetTable)}<T>() extension method."
                );
            }

            if (t == typeof(DiaEnumSymbols))
            {
                if (raw is IDiaEnumSymbols i)
                    result = new DiaEnumSymbols(i);
                else
                    throw invalidTable<IDiaEnumSymbols>();
            }
            else if (t == typeof(DiaEnumSourceFiles))
            {
                if (raw is IDiaEnumSourceFiles i)
                    result = new DiaEnumSourceFiles(i);
                else
                    throw invalidTable<IDiaEnumSymbols>();
            }
                
            else if (t == typeof(DiaEnumLineNumbers))
            {
                if (raw is IDiaEnumLineNumbers i)
                    result = new DiaEnumLineNumbers(i);
                else
                    throw invalidTable<IDiaEnumSymbols>();
            }
                
            else if (t == typeof(DiaEnumSectionContribs))
            {
                if (raw is IDiaEnumSectionContribs i)
                    result = new DiaEnumSectionContribs(i);
                else
                    throw invalidTable<IDiaEnumSymbols>();
            }
                
            else if (t == typeof(DiaEnumSegments))
            {
                if (raw is IDiaEnumSegments i)
                    result = new DiaEnumSegments(i);
                else
                    throw invalidTable<IDiaEnumSymbols>();
            }
                
            else if (t == typeof(DiaEnumInjectedSources))
            {
                if (raw is IDiaEnumInjectedSources i)
                    result = new DiaEnumInjectedSources(i);
                else
                    throw invalidTable<IDiaEnumSymbols>();
            }
                
            else if (t == typeof(DiaEnumFrameData))
            {
                if (raw is IDiaEnumFrameData i)
                    result = new DiaEnumFrameData(i);
                else
                    throw invalidTable<IDiaEnumSymbols>();
            }
            else
                throw Extensions.GetAsNotSupportedException<T, IDiaTable>();

            return (T) result;
        }

        #endregion
    }
}
