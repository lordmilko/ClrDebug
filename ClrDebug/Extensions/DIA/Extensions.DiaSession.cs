using System;

namespace ClrDebug.DIA
{
    public static partial class DiaExtensions
    {
        /// <summary>
        /// Locates the table that implements the specified enumerator type from the specified <see cref="DiaSession"/>.<para/>
        /// Possible tables include <see cref="DiaEnumSymbols"/>, <see cref="DiaEnumSourceFiles"/>, <see cref="DiaEnumLineNumbers"/>,
        /// <see cref="DiaEnumSectionContribs"/>, <see cref="DiaEnumSegments"/>, <see cref="DiaEnumInjectedSources"/>, <see cref="DiaEnumInputAssemblyFiles"/>
        /// and <see cref="DiaEnumFrameData"/>.
        /// </summary>
        /// <typeparam name="T">The type of table to retrieve.</typeparam>
        /// <param name="diaSession">The session to get the table from.</param>
        /// <returns>The specified enumerator wrapper.</returns>
        public static T GetTable<T>(this DiaSession diaSession)
        {
            /* The IDiaSession.getEnumTables member is special. Contrary to what you might think, it doesn't
             * return a mere collection of "table objects"; rather, it returns a collection of "table enumerators".
             * You iterate over this collection of table enumerators to find the specific table enumerator you're
             * after. e.g. if you want to get information source files, you ask for the source file enumerator table.
             * Once you've found the enumerator table you're after, thats it */

            TInterface getTableInternal<TInterface>(DiaEnumTables tables) where TInterface : class
            {
                foreach (var table in tables)
                {
                    if (table.Raw is TInterface qi)
                        return qi;
                }

                throw new NotSupportedException($"Could not find an {nameof(IDiaTable)} that implements interface {typeof(TInterface).Name}");
            }

            var t = typeof(T);
            object result;

            var enumTables = diaSession.EnumTables;

            if (t == typeof(DiaEnumSymbols))
                result = new DiaEnumSymbols(getTableInternal<IDiaEnumSymbols>(enumTables));
            else if (t == typeof(DiaEnumSourceFiles))
                result = new DiaEnumSourceFiles(getTableInternal<IDiaEnumSourceFiles>(enumTables));
            else if (t == typeof(DiaEnumLineNumbers))
                result = new DiaEnumLineNumbers(getTableInternal<IDiaEnumLineNumbers>(enumTables));
            else if (t == typeof(DiaEnumSectionContribs))
                result = new DiaEnumSectionContribs(getTableInternal<IDiaEnumSectionContribs>(enumTables));
            else if (t == typeof(DiaEnumSegments))
                result = new DiaEnumSegments(getTableInternal<IDiaEnumSegments>(enumTables));
            else if (t == typeof(DiaEnumInjectedSources))
                result = new DiaEnumInjectedSources(getTableInternal<IDiaEnumInjectedSources>(enumTables));
            else if (t == typeof(DiaEnumInputAssemblyFiles))
                result = new DiaEnumInputAssemblyFiles(getTableInternal<IDiaEnumInputAssemblyFiles>(enumTables));
            else if (t == typeof(DiaEnumFrameData))
                result = new DiaEnumFrameData(getTableInternal<IDiaEnumFrameData>(enumTables));
            else
                throw Extensions.GetAsNotSupportedException<T, IDiaTable>();

            return (T) result;
        }
    }
}
