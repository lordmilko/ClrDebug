using System;
using System.Collections.Generic;

namespace ClrDebug.DbgEng
{
    public class ModelObject_GetConceptResult<T>
    {
        /// <summary>
        /// The interface defined by conceptId will be returned in this argument.
        /// </summary>
        public T conceptInterface { get; }

        /// <summary>
        /// The metadata store associated with this concept will be optionally returned in this argument
        /// </summary>
        public KeyStore conceptMetadata { get; }

        public ModelObject_GetConceptResult(T conceptInterface, KeyStore conceptMetadata)
        {
            this.conceptInterface = conceptInterface;
            this.conceptMetadata = conceptMetadata;
        }
    }

    public static partial class DbgEngExtensions
    {
        public static ModelObjectConceptInterfaces GetConcept(this ModelObject modelObject) =>
            new ModelObjectConceptInterfaces(modelObject);

        public class ModelObjectConceptInterfaces
        {
            private ModelObject modelObject;

            public ModelObjectConceptInterfaces(ModelObject modelObject)
            {
                this.modelObject = modelObject;
            }

            public ModelObject_GetConceptResult<ActionableConcept> Actionable => GetConcept<IActionableConcept, ActionableConcept>();
            public ModelObject_GetConceptResult<ActionQueryConcept> ActionQuery => GetConcept<IActionQueryConcept, ActionQueryConcept>();
            public ModelObject_GetConceptResult<CodeAddressConcept> CodeAddress => GetConcept<ICodeAddressConcept, CodeAddressConcept>();
            public ModelObject_GetConceptResult<ComparableConcept> Comparable => GetConcept<IComparableConcept, ComparableConcept>();
            public ModelObject_GetConceptResult<ConstructableConcept> Constructable => GetConcept<IConstructableConcept, ConstructableConcept>();
            public ModelObject_GetConceptResult<DataModelConcept> DataModel => GetConcept<IDataModelConcept, DataModelConcept>();
            public ModelObject_GetConceptResult<DeconstructableConcept> Deconstructable => GetConcept<IDeconstructableConcept, DeconstructableConcept>();
            public ModelObject_GetConceptResult<DynamicConceptProviderConcept> DynamicConceptProvider => GetConcept<IDynamicConceptProviderConcept, DynamicConceptProviderConcept>();
            public ModelObject_GetConceptResult<DynamicKeyProviderConcept> DynamicKeyProvider => GetConcept<IDynamicKeyProviderConcept, DynamicKeyProviderConcept>();
            public ModelObject_GetConceptResult<EquatableConcept> Equatable => GetConcept<IEquatableConcept, EquatableConcept>();
            public ModelObject_GetConceptResult<IndexableConcept> Indexable => GetConcept<IIndexableConcept, IndexableConcept>();
            public ModelObject_GetConceptResult<IterableConcept> Iterable => GetConcept<IIterableConcept, IterableConcept>();
            public ModelObject_GetConceptResult<ObjectWrapperConcept> ObjectWrapper => GetConcept<IObjectWrapperConcept, ObjectWrapperConcept>();
            public ModelObject_GetConceptResult<PreferredRuntimeTypeConcept> PreferredRuntimeType => GetConcept<IPreferredRuntimeTypeConcept, PreferredRuntimeTypeConcept>();
            public ModelObject_GetConceptResult<StringDisplayableConcept> StringDisplayable => GetConcept<IStringDisplayableConcept, StringDisplayableConcept>();

            private ModelObject_GetConceptResult<TWrapper> GetConcept<TInterface, TWrapper>()
            {
                if (modelObject.TryGetConcept(typeof(TInterface).GUID, out var result) == HRESULT.S_OK)
                {
                    var t = typeof(TWrapper);
                    object wrapper;

                    if (t == typeof(ActionableConcept))
                        wrapper = new ActionableConcept((IActionableConcept) result.conceptInterface);
                    else if (t == typeof(ActionQueryConcept))
                        wrapper = new ActionQueryConcept((IActionQueryConcept) result.conceptInterface);
                    else if (t == typeof(CodeAddressConcept))
                        wrapper = new CodeAddressConcept((ICodeAddressConcept) result.conceptInterface);
                    else if (t == typeof(ComparableConcept))
                        wrapper = new ComparableConcept((IComparableConcept) result.conceptInterface);
                    else if (t == typeof(ConstructableConcept))
                        wrapper = new ConstructableConcept((IConstructableConcept) result.conceptInterface);
                    else if (t == typeof(DataModelConcept))
                        wrapper = new DataModelConcept((IDataModelConcept) result.conceptInterface);
                    else if (t == typeof(DeconstructableConcept))
                        wrapper = new DeconstructableConcept((IDeconstructableConcept) result.conceptInterface);
                    else if (t == typeof(DynamicConceptProviderConcept))
                        wrapper = new DynamicConceptProviderConcept((IDynamicConceptProviderConcept) result.conceptInterface);
                    else if (t == typeof(DynamicKeyProviderConcept))
                        wrapper = new DynamicKeyProviderConcept((IDynamicKeyProviderConcept) result.conceptInterface);
                    else if (t == typeof(EquatableConcept))
                        wrapper = new EquatableConcept((IEquatableConcept) result.conceptInterface);
                    else if (t == typeof(IndexableConcept))
                        wrapper = new IndexableConcept((IIndexableConcept) result.conceptInterface);
                    else if (t == typeof(IterableConcept))
                        wrapper = new IterableConcept((IIterableConcept) result.conceptInterface);
                    else if (t == typeof(ObjectWrapperConcept))
                        wrapper = new ObjectWrapperConcept((IObjectWrapperConcept) result.conceptInterface);
                    else if (t == typeof(PreferredRuntimeTypeConcept))
                        wrapper = new PreferredRuntimeTypeConcept((IPreferredRuntimeTypeConcept) result.conceptInterface);
                    else if (t == typeof(StringDisplayableConcept))
                        wrapper = new StringDisplayableConcept((IStringDisplayableConcept) result.conceptInterface);
                    else
                        throw new NotImplementedException();

                    return new ModelObject_GetConceptResult<TWrapper>((TWrapper) wrapper, result.conceptMetadata);
                }

                return default;
            }
        }
    }

    public partial class ModelObject
    {
        //todo: comwrappers needs to be able to support "e_bounds" style enumerators that dbgmodel uses.
        //then, comwrappers should automatically generate a normal property that calls toarray on the enumerator

        public DbgEngExtensions.ModelObjectConceptInterfaces Concept => this.GetConcept();

        public KeyEnumerator_GetNextResult[] KeyValues
        {
            get
            {
                HRESULT hr;
                var results = new List<KeyEnumerator_GetNextResult>();

                var enumerator = EnumerateKeyValues();

                while ((hr = enumerator.TryGetNext(out var value)) != HRESULT.E_BOUNDS)
                {
                    hr.ThrowDbgEngNotOK();

                    results.Add(value);
                }

                return results.ToArray();
            }
        }

        public KeyEnumerator_GetNextResult[] Keys
        {
            get
            {
                HRESULT hr;
                var results = new List<KeyEnumerator_GetNextResult>();

                var enumerator = EnumerateKeys();

                while ((hr = enumerator.TryGetNext(out var value)) != HRESULT.E_BOUNDS)
                {
                    hr.ThrowDbgEngNotOK();

                    results.Add(value);
                }

                return results.ToArray();
            }
        }

        public KeyEnumerator_GetNextResult[] KeyReferences
        {
            get
            {
                HRESULT hr;
                var results = new List<KeyEnumerator_GetNextResult>();

                var enumerator = EnumerateKeyReferences();

                while ((hr = enumerator.TryGetNext(out var value)) != HRESULT.E_BOUNDS)
                {
                    hr.ThrowDbgEngNotOK();

                    results.Add(value);
                }

                return results.ToArray();
            }
        }

        public KeyEnumerator_GetNextResult[] OwnKeyValues
        {
            get
            {
                HRESULT hr;
                var results = new List<KeyEnumerator_GetNextResult>();

                var enumerator = EnumerateOwnKeyValues();

                while ((hr = enumerator.TryGetNext(out var value)) != HRESULT.E_BOUNDS)
                {
                    hr.ThrowDbgEngNotOK();

                    results.Add(value);
                }

                return results.ToArray();
            }
        }

        public KeyEnumerator_GetNextResult[] OwnKeys
        {
            get
            {
                HRESULT hr;
                var results = new List<KeyEnumerator_GetNextResult>();

                var enumerator = EnumerateOwnKeys();

                while ((hr = enumerator.TryGetNext(out var value)) != HRESULT.E_BOUNDS)
                {
                    hr.ThrowDbgEngNotOK();

                    results.Add(value);
                }

                return results.ToArray();
            }
        }

        public KeyEnumerator_GetNextResult[] OwnKeyReferences
        {
            get
            {
                HRESULT hr;
                var results = new List<KeyEnumerator_GetNextResult>();

                var enumerator = EnumerateOwnKeyReferences();

                while ((hr = enumerator.TryGetNext(out var value)) != HRESULT.E_BOUNDS)
                {
                    hr.ThrowDbgEngNotOK();

                    results.Add(value);
                }

                return results.ToArray();
            }
        }
    }
}
