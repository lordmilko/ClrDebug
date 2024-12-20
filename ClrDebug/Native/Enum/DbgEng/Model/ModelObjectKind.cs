namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes what an <see cref="IModelObject"/> is intrinsically.
    /// </summary>
    public enum ModelObjectKind : uint
    {
        //The types listed here describe what type of value should be specified when you create an object using IDataModelManager::CreateIntrinsicObject

        ObjectPropertyAccessor, //IModelPropertyAccessor
        ObjectContext,          //IDebugHostContext
        ObjectTargetObject,
        ObjectTargetObjectReference,
        ObjectSynthetic,
        ObjectNoValue,
        ObjectError,
        ObjectIntrinsic,        //Any value that needs to be forwarded along
        ObjectMethod,           //IModelMethod
        ObjectKeyReference      //IModelKeyReference
    }
}
